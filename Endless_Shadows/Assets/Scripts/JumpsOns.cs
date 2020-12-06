using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpsOns : MonoBehaviour {

    public float amplitude = 0.5f;
    public float frequency = 1f;
    private Vector3 tempPos = new Vector3();
    private Vector3 startPos = new Vector3();

    private void Start() {
        startPos = transform.position;
    }


    // Update is called once per frame
    void FixedUpdate () {
        tempPos = startPos;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = tempPos;
	}
}
