using Shimmer.Common.Variables;
using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Shimmer.Common.Actions.Texts
{
	[Serializable]
	public class SetText : Action
	{
		public Text Text;
		public StringReference Content;

		public static string MenuName
		{
			get
			{
				return "Texts/Set text";
			}
		}

		public override void Execute(MonoBehaviour _behaviour)
		{
			Assert.IsNotNull(Text);

			Text.text = Content.GetValue();
		}
	}

}