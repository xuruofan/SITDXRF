using Shimmer.Tools;
using System;
using UnityEngine;

namespace Shimmer.Common.Actions
{
	public abstract class Action
	{
		public abstract void Execute();
	}

	[Serializable]
	public class ActionList : ReorderableList<ActionOptions>
	{
		public void Execute()
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
							action.Execute();
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
