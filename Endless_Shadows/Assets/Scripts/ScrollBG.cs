using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBG : MonoBehaviour {

    [Range(1f, 20f)]
    public float scrollspeed = 1f;

    public float scrollOffset;

     Vector2 startPos;
     float newPos;

	// Use this for initialization
	void Start () {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        newPos = Mathf.Repeat(Time.time * - scrollspeed, scrollOffset);

        transform.position = startPos + Vector2.right * newPos;
	}
}
