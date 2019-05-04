using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Shimmer.Common.Actions.Visuals
{
	[Serializable]
	public class SetAnimationTrigger : Action
	{
		public Animator Animator;
		public string Trigger;

		public static string MenuName
		{
			get
			{
				return "Visuals/Set Animation Trigger";
			}
		}

		public override void Execute(MonoBehaviour _behaviour)
		{
			Assert.IsNotNull(Animator, "Animator is null");
			Assert.IsFalse(string.IsNullOrEmpty(Trigger), "Animation trigger is empty or null");

			Animator.SetTrigger(Trigger);
		}
	}

}