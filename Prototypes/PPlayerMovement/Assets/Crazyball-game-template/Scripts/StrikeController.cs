using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeController : MonoBehaviour {
	void OnCollisionExit2D() {
		Destroy (this.gameObject);
	}
}
