using Shimmer.Tools;
using System;
using UnityEngine;

namespace Shimmer.Common.Actions
{
	public abstract class Action
	{
		public abstract void Execute(MonoBehaviour _behaviour);
	}

	[Serializable]
	public class ActionList : ReorderableList<ActionOptions>
	{
		public void Execute(MonoBehaviour _behaviour)
		{
			if (Items != null)
			{
				foreach (var item in Items)
				{
					Action action = item;
					if (action != null)
					{
						try
						{
							action.Execute(_behaviour);
						}
						catch (Exception e)
						{
							Debug.LogError($"Action failed: {e.Message}");
						}
					}
				}
			}
		}

	}
}
