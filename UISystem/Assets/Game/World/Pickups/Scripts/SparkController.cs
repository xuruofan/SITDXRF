namespace Shimmer.Game.World.Pickups
{
	public class SparkController : PickupControllerBase
	{
		protected override void ApplyEffect(Player.Player _player)
		{
			base.ApplyEffect(_player);

			_player.CollectSpark();
		}
	}
}