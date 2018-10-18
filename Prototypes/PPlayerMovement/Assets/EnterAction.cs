using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterAction : StateMachineBehaviour {
	public override void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		base.OnStateEnter (animator, stateInfo, layerIndex);

		Rigidbody2D playerBody = animator.GetComponentInParent<Rigidbody2D> ();
		PlayerController controller = animator.GetComponentInParent<PlayerController> ();

		Vector3 position = playerBody.transform.position;
		playerBody.transform.position = new Vector3(position.x, position.y, -3.0f);
		playerBody.velocity = new Vector2 (controller.maxXSpeed, controller.maxYSpeed);
		controller.bIsFacingRight = true;
	}
	 //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		base.OnStateEnter (animator, stateInfo, layerIndex);
		if (Input.touchCount == 1 && Input.GetTouch (0).phase == TouchPhase.Ended) {
			animator.SetTrigger ("tStartGame");
		}
	}
}
