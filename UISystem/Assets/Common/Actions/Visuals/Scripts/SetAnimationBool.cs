using Shimmer.Common.Variables;
using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Shimmer.Common.Actions.Visuals
{
	[Serializable]
	public class SetAnimationBool : Action
	{
		public Animator Animator;
		public string Parameter;
		public BoolReference IsTrue;

		public static string MenuName
		{
			get
			{
				return "Visuals/Set Animation Bool";
			}
		}

		public override void Execute(MonoBehaviour _behaviour)
		{
			Assert.IsNotNull(Animator, "Animator is null");
			Assert.IsFalse(string.IsNullOrEmpty(Parameter), "Animation parameter is empty");

			Animator.SetBool(Parameter, IsTrue.GetValue());
		}
	}

}