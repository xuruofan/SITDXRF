using UnityEngine;
using System.Collections;
using Shimmer.Common.Variables;

namespace Shimmer.Game.World.Enemies
{
	public class HarmfulObject : MonoBehaviour
	{
		[SerializeField]
		private StringReference[] m_Messages;
		[SerializeField]
		private IntReference m_Damage;

		public string GetMessage()
		{
			string message = string.Empty;

			int count = m_Messages.Length;
			if (count > 0)
			{
				message = m_Messages[Random.Range(0, count)].GetValue();
			}

			return message;
		}

		public int GetDamage()
		{
			return m_Damage.GetValue();
		}
	}
}
