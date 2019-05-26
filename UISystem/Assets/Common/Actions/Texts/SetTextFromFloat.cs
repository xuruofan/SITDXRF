using Shimmer.Common.Variables;
using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Shimmer.Common.Actions.Texts
{
	[Serializable]
	public class SetTextFromFloat : Action
	{
		public Text Text;
		public FloatReference Value;
		public StringReference Format;

		public static string MenuName
		{
			get
			{
				return "Texts/Set text from float";
			}
		}

		public override void Execute(MonoBehaviour _behaviour)
		{
			Assert.IsNotNull(Text, "Please set a Text component");

			float value = Value.GetValue();

			Text.text = string.Format(Format.GetValue(), value);
		}
	}

}