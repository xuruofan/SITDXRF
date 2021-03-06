﻿using Shimmer.Common.Variables;
using System;

namespace Shimmer.Common.Conditions.Variables
{
	[Serializable]
	public class Changed : Condition
	{
		public static string MenuName
		{
			get
			{
				return "Variables/Changed";
			}
		}

		public Variable Variable;

		public override bool Evaluate()
		{
			return Variable.Changed.IsRaised();
		}

		public override void Subscribe(Callback _callback)
		{
			Variable.Subscribe(_callback);
		}

		public override void Unsubscribe(Callback _callback)
		{
			Variable.Unsubscribe(_callback);
		}
	}
}