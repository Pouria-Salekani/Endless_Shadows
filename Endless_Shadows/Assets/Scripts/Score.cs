using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public float scoreCount;
    private float highScoreCount;
    private FreeParallax getSpeedRatio; //Using this to reference a PUBLIC VARIABLE in a different script
    //TODO: This is how to get a REFERENCE TO ANOTHER CLASS/SCRIPT!

    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOver; //The panel for GameOver
    public float pointsPerSecond;
  

    private Player player; //This is going to be used so we can use the VARIABLES from the other SCRIPT!
    private Spawner spawn;


    void Start() {
        getSpeedRatio = FindObjectOfType<FreeParallax>();
        player = FindObjectOfType<Player>();
        spawn = FindObjectOfType<Spawner>();
       

        highScoreCount = PlayerPrefs.GetFloat("HighScoree", 0);  //TODO: !This should always be on START, this LOADS up the data, hence the "GetFloat()"

    }
    // Update is called once per frame
    void Update() {

        //TODO: if the "player" is NOT dead, the score will keep on going
        if (player.isDead == false) {
            scoreCount += pointsPerSecond * Time.deltaTime;  //The score count will be based on POINTSPERSECOND and the "Time.deltaTime" for smooth fps
            scoreText.text = scoreCount.ToString("0"); //This will ROUND the number to a whole number AND will convert the NUMBER TO A STRING!
        }

        //TODO: else, the "player" IS DEAD IS TRUE!, then the SCORE WILL STOP!
        else if (player.isDead == true) {
            CheckHighScore();
            scoreText.text = scoreCount.ToString("0"); //Sets the REGULAR score
            highScoreText.text = highScoreCount.ToString("0");  //Sets the HIGH score
            gameOver.SetActive(true);
        }

        //TODO: !FIX THE AUDIO BECAUSE THE AUDIO KEEPS ON MESSING UP FOR NO REASON!
        
         if (scoreCount >= 100f) {             //change this later on based on other factors
            getSpeedRatio.Speed = -300f;
            pointsPerSecond = 6f;          
             
        }
         if(scoreCount >= 350f) {
            getSpeedRatio.Speed = -400f;
            pointsPerSecond = 10f;          
        }
    }

    private void CheckHighScore() { //Checks to see if the NEW score is HIGHER than the OLD score. (highscore checker)
        if(scoreCount > highScoreCount) {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScoree", highScoreCount);  //TODO: !The value "highscoreCount" gets STORED in "HighScoree". This basically SAVES the data.    
        }
    }
}
