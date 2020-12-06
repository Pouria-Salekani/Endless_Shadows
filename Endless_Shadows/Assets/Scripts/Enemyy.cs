using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyy : MonoBehaviour {

    public float speed;
    private int health = 1;

    private Score realScore;

     void Start() {
        realScore = FindObjectOfType<Score>();
    }


    // Update is called once per frame
    void Update () {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if(health <= 0) {
            Destroy(gameObject);
        }

        if(realScore.scoreCount >= 100f) {
            speed = 6f;           
        }

        if (realScore.scoreCount >= 350f) {
            speed = 10f;
        }
	}

    public void TakeDamage(int damage) {
        health -= damage;
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }

    //TODO: !REMEMBER TO SET "isTrigger" ON THE COLLIDERS ON THE INSPECTORS SO THE TRIGGERS GET ACTIVATED!
}
