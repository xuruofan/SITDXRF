using System;
using UnityEngine;

namespace Shimmer.Common.Actions.Texts
{
	[Serializable]
	public class PrintLog : Action
	{
		public string Log;

		public static string MenuName
		{
			get
			{
				return "Texts/Print log";
			}
		}

		public override void Execute()
		{
			if (Log != null)
			{
				Debug.Log(Log);
			}
		}
	}

}