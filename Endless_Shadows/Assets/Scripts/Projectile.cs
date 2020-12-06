using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public LayerMask whatIsEnemy;
    public float distance;
    public GameObject destroyEffect;


    private int damage = 1;


    // Update is called once per frame
    void Update () {
        transform.Translate(Vector2.right * speed * Time.deltaTime); //Makes the projectile go the RIGHT! 

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, distance, whatIsEnemy); //TODO: This is used to ATTACK THE ENEMIES! and INFLICT DAMAGE!
        if(hit.collider != null) {  //If it detects SOMETHING
            if (hit.collider.CompareTag("Enemy")) {  //if the object has the TAG OF "ENEMY
                hit.collider.GetComponent<Enemyy>().TakeDamage(damage);
                DestroyProjectile();
            }
        }
	}
   private void OnBecameInvisible() {  //TODO: This is gets TRIGGERED when an OBJECT goes OUT OF THE CAMERA BOUNDS! Really helpful and important! This is an EVENT METHOD!
        Destroy(gameObject);
    }

    private void DestroyProjectile() {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

