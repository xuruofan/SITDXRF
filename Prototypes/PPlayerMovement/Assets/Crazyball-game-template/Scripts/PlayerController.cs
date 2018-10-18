using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	/// <summary>
	/// Player Controller class
	/// This class handles player movement. 
	/// It always follows player's input (Mouse or Touch)
	/// </summary>

	public float maxXSpeed = 1.0f;
	public float maxYSpeed = 2.0f;
	public float xVelocity;
	public float yVelocity;
	//Private internal variables
	private Vector3 screenToWorldVector;

	private Rigidbody2D playerRigidBody;
	public bool bIsFacingRight;

	public GameObject Strike;

	void Awake() {
		SimpleGesture.On4AxisFlickSwipeDown (this.OnVerticalFlickDown);
		SimpleGesture.On4AxisFlickSwipeUp (this.OnVerticalFlickUp);
		SimpleGesture.On4AxisFlickSwipeRight (this.OnHorizontalFlickRight);
		SimpleGesture.On4AxisFlickSwipeLeft (this.OnHorizontalFlickLeft);
	}

	void Start() {
	}

	void Update() {
		if(!GameController.gameOver) {
			if (Input.touchCount > 0) {
				OnTouchHold ();
			}
		}
	}
	
	
	///***********************************************************************
	/// Control ball's position with touch position parameters
	///***********************************************************************
	void OnVerticalFlickUp(GestureInfoSwipe GestureInfo) {
		GameObject StrikeObject = Instantiate (Strike) as GameObject;
		Vector3 Position = Camera.main.ScreenToWorldPoint(GestureInfo.firstPosition);
		Position.z = -3.0f;
		StrikeObject.transform.position = Position;
		StrikeObject.transform.RotateAround(Position, new Vector3 (0, 0, 1), 90);
	}

	void OnVerticalFlickDown(GestureInfoSwipe GestureInfo) {
		GameObject StrikeObject = Instantiate (Strike) as GameObject;
		Vector3 Position = Camera.main.ScreenToWorldPoint(GestureInfo.firstPosition);
		Position.z = -3.0f;
		StrikeObject.transform.position = Position;
		StrikeObject.transform.RotateAround(Position, new Vector3 (0, 0, 1), -90);
	}

	void OnHorizontalFlickRight(GestureInfoSwipe GestureInfo) {
		GameObject StrikeObject = Instantiate (Strike) as GameObject;
		Vector3 Position = Camera.main.ScreenToWorldPoint(GestureInfo.firstPosition);
		Position.z = -3.0f;
		StrikeObject.transform.position = Position;
	}

	void OnHorizontalFlickLeft(GestureInfoSwipe GestureInfo) {
		GameObject StrikeObject = Instantiate (Strike) as GameObject;
		Vector3 Position = Camera.main.ScreenToWorldPoint(GestureInfo.firstPosition);
		Position.z = -3.0f;
		StrikeObject.transform.position = Position;
		Vector3 NewScale = StrikeObject.transform.localScale;
		NewScale.x = -NewScale.x;
		StrikeObject.transform.localScale = NewScale;
	}

	void OnTouchHold() {
		Vector3 TouchPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch (0).position);
		TouchPoint.z = -3.0f;
		Vector3 PlayerToPointVector = TouchPoint - transform.position;
		Vector2 PlayerToPoint2DVector = new Vector2 (PlayerToPointVector.x, PlayerToPointVector.y);
		bool bShouldMoveClockwise = Vector2.SignedAngle (PlayerToPoint2DVector, playerRigidBody.velocity) < 0;	// move clockwise when the angle from PlayerToPoint2DVector to velocity is anti-clockwise
		Vector3 DirectionVector = Quaternion.AngleAxis (bShouldMoveClockwise ? -90 : 90, new Vector3 (0, 0, 1)) * PlayerToPointVector;
		DirectionVector = DirectionVector.normalized * 5.0f;
		DirectionVector = (new Vector2(DirectionVector.x, DirectionVector.y) + playerRigidBody.velocity) / 2;
		playerRigidBody.velocity = DirectionVector;
	}
}
