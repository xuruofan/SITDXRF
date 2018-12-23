using Shimmer.Common.Variables;
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