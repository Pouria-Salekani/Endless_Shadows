using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    
    private float timeBtwShots; //Shots per second
    private Rigidbody2D rb;
    private Animator anim;
    private bool isGround;
    private float randomNumber; //this is used for the pickup thingy!

    public float jumpForce;
    public float radius;
    public LayerMask whatIsGround;
    public Transform footPos;
    public GameObject destroyEffect;

    private AudioSource jumpNoise;

    public bool isDead = false; //If player died, it changes to "TRUE"
    public GameObject gameOver; //This is used when the PLAYER DIES and the "GAMEOVER PANEL" shows up!


    public GameObject projectile; //The shooting picture
    public Transform shotPoint; //The position of where the shooting comes out from
    public float startTimeBtwShots; //SHOOT A PROJECTILE EVERY ____ SECONDS!

    private Renderer renderer;
    private Score score;
 
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jumpNoise = GetComponent<AudioSource>();
        renderer = GetComponent<Renderer>();
        score = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update() {
        if(score.scoreCount >= 100) {
            startTimeBtwShots = 0.65f;
        }

        if(score.scoreCount >= 350f) {
            startTimeBtwShots = 0.45f;
        }

        foreach (Touch touch in Input.touches) {
            if (touch.position.x < Screen.width / 2) {
                isGround = Physics2D.OverlapCircle(footPos.position, radius, whatIsGround);
                if (isGround) {
                    anim.SetTrigger("Jumpe");
                    jumpNoise.Play();
                    rb.velocity = jumpForce * Vector2.up;
                }
            }
            else if (touch.position.x > Screen.width / 2) {
                if (timeBtwShots <= 0) {
                    Instantiate(projectile, shotPoint.position, transform.rotation);
                    timeBtwShots = startTimeBtwShots;
                }
                else {
                    timeBtwShots -= Time.deltaTime;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            DestroyPlayer();
        }
    }

    private void DestroyPlayer() {
        isDead = true;
        Instantiate(destroyEffect, transform.position, Quaternion.identity); //TODO: "Quaterion.identity" means NO ROTATION!  
        renderer.enabled = false;
    }
}
