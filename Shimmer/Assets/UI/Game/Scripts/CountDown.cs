using Shimmer.Common.Actions;
using UnityEngine;
using UnityEngine.UI;

namespace Shimmer.UI.Game
{
	public class CountDown : MonoBehaviour
	{
		public int CountdownTime;
		public Text TimerText;
		public float DelayActionInSeconds;
		public ActionList OnCountdownFinished;

		private float m_remainingTime;
		
		// Use this for initialization
		void Start()
		{
			m_remainingTime = CountdownTime;
			TimerText.text = Mathf.CeilToInt(m_remainingTime).ToString();
		}

		// Update is called once per frame
		void Update()
		{
			m_remainingTime -= Time.deltaTime;
			TimerText.text = Mathf.CeilToInt(m_remainingTime).ToString();
			if (m_remainingTime <= 0)
			{
				Invoke("OnEvent", DelayActionInSeconds);
				enabled = false;
			}
		}

		void OnEvent()
		{
			OnCountdownFinished.Execute(this);
		}
	}
}
