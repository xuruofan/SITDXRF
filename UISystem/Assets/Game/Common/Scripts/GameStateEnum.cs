using Shimmer.Common.Variables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shimmer.Game.Common
{
	public enum EGameState
	{
		Countdown,
		Started,
		Ended
	}

	[CreateAssetMenu(fileName = "E_NewEGameState", menuName = "Shimmer/Game/Common/EGameState")]
	public class GameStateEnum : EnumOf<EGameState>
	{
	}
}