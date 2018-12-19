using System;
using UnityEngine;

namespace Shimmer.Common.Actions.Text
{
	[Serializable]
	public class PrintLog : Action
	{
		public string Log;

		public static string MenuName
		{
			get
			{
				return "Text/Print log";
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