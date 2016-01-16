using UnityEngine;
using System.Collections;

// Jackson Garinger

public class PlayerMove : MonoBehaviour {

	public bool canMoveLeft;
	public bool canMoveRight;
	public bool canMoveUp;
	public bool canMoveDown;
	public bool canMoveLeftUp;
	public bool canMoveLeftDown;
	public bool canMoveRightUp;
	public bool canMoveRightDown;

	// Use this for initialization
	void Start () {
		calculateMoves ();
	}
	bool isRockAtPosition(Vector3 position) {
		var objs = GameObject.FindGameObjectsWithTag("rock");
		foreach (GameObject go in objs) {
			if (go.transform.position.x == position.x && go.transform.position.y == position.y) {
				return true;
			}
		}
		return false;
	}

	void calculateMoves() {
		var position = this.transform.position;
		var left 	= new Vector3(position.x - 1.5f, position.y, 0.0f);
		var right 	= new Vector3(position.x + 1.5f, position.y, 0.0f);
		var up 		= new Vector3(position.x, position.y + 1.5f, 0.0f);
		var down 	= new Vector3(position.x, position.y - 1.5f, 0.0f);
		
		var leftUp 		= new Vector3(position.x - 1.5f, position.y + 1.5f, 0.0f);
		var rightUp 	= new Vector3(position.x + 1.5f, position.y + 1.5f, 0.0f);
		var leftDown 	= new Vector3(position.x - 1.5f, position.y - 1.5f, 0.0f);
		var rightDown 	= new Vector3(position.x + 1.5f, position.y - 1.5f, 0.0f);
		
		canMoveLeft = isRockAtPosition (left);
		canMoveRight = isRockAtPosition (right);
		canMoveUp = isRockAtPosition (up);
		canMoveDown = isRockAtPosition (down);
		canMoveLeftUp = isRockAtPosition (leftUp);
		canMoveRightUp = isRockAtPosition (rightUp);
		canMoveLeftDown = isRockAtPosition (leftDown);
		canMoveRightDown = isRockAtPosition (rightDown);
	}
	// Update is called once per frame
	void Update () {
		if (!Input.anyKeyDown)
			return;

		if (canMoveUp && Input.GetKeyDown("w")) // Move Forward
            transform.Translate(0.0f, 1.5f, 0.0f);

        if (canMoveDown && (Input.GetKeyDown("s") || Input.GetKeyDown("x"))) // Move Backward
            transform.Translate(0.0f, -1.5f, 0.0f);

        if (canMoveLeft && Input.GetKeyDown("a")) // Move Left
            transform.Translate(-1.5f, 0.0f, 0.0f);

        if (canMoveRight && Input.GetKeyDown("d")) // Move Right
            transform.Translate(1.5f, 0.0f, 0.0f);

        if (canMoveLeftUp && Input.GetKeyDown("q")) // Move Forward-Left Diagonal
            transform.Translate(-1.5f, 1.5f, 0.0f);

        if (canMoveRightUp && Input.GetKeyDown("e")) // Move Forward-Right Diagonal
            transform.Translate(1.5f, 1.5f, 0.0f);

        if (canMoveLeftDown && Input.GetKeyDown("z")) // Move Backward-Left Diagonal
            transform.Translate(-1.5f, -1.5f, 0.0f);

        if (canMoveRightDown && Input.GetKeyDown("c")) // Move Backward-Right Diagonal
            transform.Translate(1.5f, -1.5f, 0.0f);

		calculateMoves ();
	}
}
