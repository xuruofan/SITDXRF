using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : StateMachineBehaviour {
	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		Rigidbody2D playerBody = animator.GetComponentInParent<Rigidbody2D> ();
		PlayerController playerController = animator.GetComponentInParent<PlayerController> ();

		// Keep horizontal speed constant and vertical speed within a limit
		float yVelocity = playerBody.velocity.y;
		float xVelocity = playerBody.velocity.x;
		if (yVelocity > playerController.maxYSpeed) {
			yVelocity = playerController.maxYSpeed;
		} else if (yVelocity < -playerController.maxYSpeed) {
			yVelocity = -playerController.maxYSpeed;
		}
		bool bMovingRight = xVelocity > 0;
		xVelocity = bMovingRight ? playerController.maxXSpeed : -playerController.maxXSpeed;
		playerBody.velocity = new Vector2 (xVelocity, yVelocity);

		// Keep angular 0
		playerBody.angularVelocity = 0;
	}
}
