using UnityEngine;
using System.Collections;

// Jackson Garinger

public class PlayerMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("w")) // Move Forward
            transform.Translate(0.0f, 1.0f, 0.0f);

        if (Input.GetKeyDown("s")) // Move Backward
            transform.Translate(0.0f, -1.0f, 0.0f);

        if (Input.GetKeyDown("a")) // Move Left
            transform.Translate(-1.0f, 0.0f, 0.0f);

        if (Input.GetKeyDown("d")) // Move Right
            transform.Translate(1.0f, 0.0f, 0.0f);

        if (Input.GetKeyDown("q")) // Move Forward-Left Diagonal
            transform.Translate(-1.0f, 1.0f, 0.0f);

        if (Input.GetKeyDown("e")) // Move Forward-Right Diagonal
            transform.Translate(1.0f, 1.0f, 0.0f);

        if (Input.GetKeyDown("z")) // Move Backward-Left Diagonal
            transform.Translate(-1.0f, -1.0f, 0.0f);

        if (Input.GetKeyDown("c")) // Move Backward-Right Diagonal
            transform.Translate(1.0f, -1.0f, 0.0f);

    }
}
