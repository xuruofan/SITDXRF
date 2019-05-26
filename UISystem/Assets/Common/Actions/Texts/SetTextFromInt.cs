using Shimmer.Common.Variables;
using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Shimmer.Common.Actions.Texts
{
	[Serializable]
	public class SetTextFromInt : Action
	{
		public Text Text;
		public IntReference Value;
		
		public static string MenuName
		{
			get
			{
				return "Texts/Set text from Int";
			}
		}

		public override void Execute(MonoBehaviour _behaviour)
		{
			Assert.IsNotNull(Text, "Please set a Text component");

			int value = Value.GetValue();

			Text.text = value.ToString();
		}
	}

}