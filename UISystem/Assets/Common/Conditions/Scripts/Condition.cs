using System;
using Shimmer.Tools;
using UnityEngine;

namespace Shimmer.Common.Conditions
{
	public abstract class Condition
	{
		public virtual void Subscribe() { }
		public virtual void Unsubscribe() { }
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

		public void Subscribe()
		{
			foreach (var item in Items)
			{
				Condition condition = item;
				if (condition != null)
				{
					condition.Subscribe();
				}
			}
		}

		public void Unsubscribe()
		{
			foreach (var item in Items)
			{
				Condition condition = item;
				if (condition != null)
				{
					condition.Unsubscribe();
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