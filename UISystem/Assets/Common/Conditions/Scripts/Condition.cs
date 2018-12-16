using System;
using Shimmer.Common.Variables;
using Shimmer.Tools;
using UnityEngine;

namespace Shimmer.Common.Conditions
{
	public abstract class Condition
	{
		public virtual void Subscribe(Callback _callback) { }
		public virtual void Unsubscribe(Callback _callback) { }
		public abstract bool Evaluate();
	}

	[Serializable]
	public class ConditionList : ReorderableList<ConditionOptions>
	{
		public delegate void Callback(bool _result);

		public enum OperatorSelection
		{
			Or,
			And
		}

		[Tooltip("Empty condition list returns FALSE for OR and TRUE for AND")]
		public OperatorSelection Operator = OperatorSelection.Or;

		private Callback m_Callback;

		public void Enable(Callback _callback)
		{
			m_Callback = _callback;
			Subscribe();
		}

		public void Disable()
		{
			m_Callback = null;
			Unsubscribe();
		}

		private void Subscribe()
		{
			foreach (var item in Items)
			{
				Condition condition = item;
				if (condition != null)
				{
					condition.Subscribe(OnConditionChanged);
				}
			}
		}

		private void Unsubscribe()
		{
			foreach (var item in Items)
			{
				Condition condition = item;
				if (condition != null)
				{
					condition.Unsubscribe(OnConditionChanged);
				}
			}
		}

		private void OnConditionChanged()
		{
			try
			{
				m_Callback(Evaluate());
			}
			catch (Exception e)
			{
				Debug.LogError($"Exception in Event: {e.Message}");
			}
		}

		private bool Evaluate()
		{
			switch (Operator)
			{
				case OperatorSelection.Or:
					return EvaluateOR();
				case OperatorSelection.And:
					return EvaluateAND();
				default:
					return false;
			}
		}

		private bool EvaluateOR()
		{
			foreach (var item in Items)
			{
				Condition condition = item;
				if (condition != null && condition.Evaluate())
				{
					return true;
				}
			}
			return false;
		}

		private bool EvaluateAND()
		{
			foreach (var item in Items)
			{
				Condition condition = item;
				if (condition == null || !condition.Evaluate())
				{
					return false;
				}
			}
			return true;
		}
	}
}