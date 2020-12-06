using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public float minTime = 0f;
    public float maxTime = 0f;

    private float spawnTime; //Random time to spawn an object
    private float time; //Current time

    public GameObject anObject; //spawn this object
    private Score score;
   
    // Use this for initialization
    void Start () {
        setRandomTime(); //This is going to set the RANDOM TIME for the SPAWNTIME!
        time = 0;
        score = FindObjectOfType<Score>();
	}
	
	// Update is called once per frame
	void Update () {
        if(score.scoreCount >= 100f) {
            minTime = 1.5f;
            maxTime = 2.0f;
        }

        if (score.scoreCount >= 350f) {
            minTime = 0.5f;
            maxTime = 1.0f;
        }

        time += Time.deltaTime; //This will count up! Until it reaches 4, it will trigger the "if" statement BELOW when its between any of the numbers, INCLUDING 2 (cuz time is set to "minTime")

        if(time >= spawnTime) { //Checks to see if its the right time to spawn! (SEE THE THING ABOVEE!!) If spawn time is 3, and time is 2 (because minTime is 2) then Time.deltaTime will add +1 to "time"
            SpawnObject();     //Which will make it equals to whatever "spawnTime" is, in this case, it'll be 3!
            setRandomTime();
        }

		
	}
    private void setRandomTime() {
        spawnTime = Random.Range(minTime, maxTime);  //picks a RANDOM TIME between _____ and _____ (INCLUSIVE = INCLUDED)!
    }

    private void SpawnObject() {
        time = 0; //Setting time to 0 so it'll add up again
        Instantiate(anObject, transform.position, anObject.transform.rotation);
    }
    //TODO: !TAKE NOTES ON ALL THIS SINCE THIS IS VERY IMPORTANT! Note that this can be used for any SPAWNER, but it recommended to use it when spawning ONE object at a RANDOM TIME!
}
