using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {

    //TODO: make a timer if you want
    public void OnMouseDown() {
        SceneManager.LoadScene("Game");

    }
}
