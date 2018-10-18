using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMotion : StateMachineBehaviour {
	private bool bAlignToPath;

	public override void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		base.OnStateEnter (animator, stateInfo, layerIndex);

		bAlignToPath = false;
	}

	public override void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		base.OnStateUpdate (animator, stateInfo, layerIndex);

		// Player releases touch, enter free fall motion
		if (Input.touchCount == 0) {
			animator.SetTrigger ("tJump");
		}

		if (bAlignToPath) {
			RotateAroundTouchPoint ();
		} else {
			AlignToPath ();
		}
	}

	private void AlignToPath() {

	}

	private void RotateAroundTouchPoint() {

	}
}
