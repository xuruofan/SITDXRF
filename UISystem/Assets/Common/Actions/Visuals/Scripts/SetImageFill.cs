using Shimmer.Common.Variables;
using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Shimmer.Common.Actions.Visuals
{
	[Serializable]
	public class SetImageFill : Action
	{
		public Image Image;
		public FloatReference Amount;
		public FloatReference Full;

		public static string MenuName
		{
			get
			{
				return "Visuals/Set Image Fill";
			}
		}

		public override void Execute()
		{
			Assert.IsNotNull(Image, "Please set an image");

			float fraction = Amount.GetValue() / Full.GetValue();
			fraction = Mathf.Clamp(fraction, 0, 1);

			Image.fillAmount = fraction;
		}
	}

}