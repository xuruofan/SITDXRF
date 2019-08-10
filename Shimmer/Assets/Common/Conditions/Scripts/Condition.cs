using System;
using System.Collections.Generic;
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
		public enum OperatorSelection
		{
			Or,
			And
		}

		[Tooltip("Empty condition list returns FALSE for OR and TRUE for AND")]
		public OperatorSelection Operator = OperatorSelection.Or;

		public void Enable(Callback _callback)
		{
			Subscribe(_callback);
		}

		public void Disable(Callback _callback)
		{
			Unsubscribe(_callback);
		}

		private void Subscribe(Callback _callback)
		{
			foreach (var item in Items)
			{
				Condition condition = item;
				if (condition != null)
				{
					condition.Subscribe(_callback);
				}
			}
		}

		private void Unsubscribe(Callback _callback)
		{
			foreach (var item in Items)
			{
				Condition condition = item;
				if (condition != null)
				{
					condition.Unsubscribe(_callback);
				}
			}
		}

		public bool Evaluate()
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