using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : StateMachineBehaviour {
	public override void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		// There are two types of collisions:
		// 1. Colliding vertically causes the player to flip direction and jump up
		// 2. Colliding horizontally causes the player to continue jumping in the same direction

		Rigidbody2D player = animator.GetComponentInParent<Rigidbody2D> ();
		PlayerController controller = animator.GetComponentInParent<PlayerController> ();

		bool bIsMovingRight = player.velocity.x > 0;
		bool bHasFlipped = controller.bIsFacingRight != bIsMovingRight;
		if (bHasFlipped) {
			// Case 1 collision
			float newVelocityY = controller.maxYSpeed;
			player.velocity = new Vector2 (player.velocity.x, newVelocityY);
			controller.bIsFacingRight = bIsMovingRight;
		}

		animator.SetTrigger ("tJump");
	}
}
