using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour {

    public void OnMouseDown() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  //TODO: !Used to LOAD the CURRENT scene!
    }
}
