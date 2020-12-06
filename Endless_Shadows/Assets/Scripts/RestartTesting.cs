using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartTesting : MonoBehaviour {

    private Player player;  
    private Renderer renderer; //we want the "Player" renderer component!
    private int limit;

    void Start() {
        player = FindObjectOfType<Player>();  //Accessing the "Player" SCRIPT
        renderer = player.GetComponent<Renderer>(); //TODO: This is how you get ANOTHER "GameObject's" COMPONENT!
    }

    void Update() {
        if(limit >= 1) { //This is used for the REWARD AD BUTTON!
            Destroy(gameObject); //When the user clicks the reward button to watch an ad, they respawn BUT THEY ONLY HAVE 1 TRY!
        }
    }

    public void OnMouseDown() {
        player.isDead = false;
        renderer.enabled = true;
        limit++;
    }
}
