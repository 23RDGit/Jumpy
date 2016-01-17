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
		calculateKeyboardMoves ();
	}
	
    // Update is called once per frame
	void Update() {
		HandleKeyBoardMoves();
		HandleMouseMoves();
	}
    
 	void HandleMouseMoves() {
        //bail if mouse is not down
		if (!Input.GetMouseButtonDown (0)) 
			return;

        // get mouse position
		var mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        var x = Mathf.Round(mousePos.x);
        var y = Mathf.Round(mousePos.y);
        
        // get player position
        var playerX = this.transform.position.x;
        var playerY = this.transform.position.y;
        
        // bail unless mouse pos is adjacent to player
        if (!(x <= playerX + 2f && y <= playerY + 2f) ||
            !(x >= playerX - 2f && y >= playerY - 2f))
            return;
        
        // check for a rock at this postion and
        // then move player to rock         
        var pos = new Vector3(x, y, 0f);       
        if (isRockAtPosition(pos))
            this.transform.position = pos;

        // refresh possible keyboard moves
		calculateKeyboardMoves ();

	}
    
	void HandleKeyBoardMoves () {
        // bail if key is not down
		if (!Input.anyKeyDown)
			return;

        // move to a rock
		if (canMoveUp && Input.GetKeyDown("w")) // Move up
            transform.Translate(0.0f, 2f, 0.0f);

        if (canMoveDown && (Input.GetKeyDown("s") || Input.GetKeyDown("x"))) // Move down
            transform.Translate(0.0f, -2f, 0.0f);

        if (canMoveLeft && Input.GetKeyDown("a")) // Move Left
            transform.Translate(-2f, 0.0f, 0.0f);

        if (canMoveRight && Input.GetKeyDown("d")) // Move Right
            transform.Translate(2f, 0.0f, 0.0f);

        if (canMoveLeftUp && Input.GetKeyDown("q")) // Move Left-up Diagonal
            transform.Translate(-2f, 2f, 0.0f);

        if (canMoveRightUp && Input.GetKeyDown("e")) // Move Right-up Diagonal
            transform.Translate(2f, 2f, 0.0f);

        if (canMoveLeftDown && Input.GetKeyDown("z")) // Move Left-down Diagonal
            transform.Translate(-2f, -2f, 0.0f);

        if (canMoveRightDown && Input.GetKeyDown("c")) // Move Right-down Diagonal
            transform.Translate(2f, -2f, 0.0f);

        // refresh possible keyboard moves
		calculateKeyboardMoves ();
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

	void calculateKeyboardMoves() {
		var position = this.transform.position;
		var left 	= new Vector3(position.x - 2f, position.y, 0.0f);
		var right 	= new Vector3(position.x + 2f, position.y, 0.0f);
		var up 		= new Vector3(position.x, position.y + 2f, 0.0f);
		var down 	= new Vector3(position.x, position.y - 2f, 0.0f);
		
		var leftUp 		= new Vector3(position.x - 2f, position.y + 2f, 0.0f);
		var rightUp 	= new Vector3(position.x + 2f, position.y + 2f, 0.0f);
		var leftDown 	= new Vector3(position.x - 2f, position.y - 2f, 0.0f);
		var rightDown 	= new Vector3(position.x + 2f, position.y - 2f, 0.0f);
		
		canMoveLeft = isRockAtPosition (left);
		canMoveRight = isRockAtPosition (right);
		canMoveUp = isRockAtPosition (up);
		canMoveDown = isRockAtPosition (down);
		canMoveLeftUp = isRockAtPosition (leftUp);
		canMoveRightUp = isRockAtPosition (rightUp);
		canMoveLeftDown = isRockAtPosition (leftDown);
		canMoveRightDown = isRockAtPosition (rightDown);
	}
}
