using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{

    public GameManagerScript gmScript;

    void Start() {
        gmScript = GameObject.FindObjectOfType<GameManagerScript>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player") {
            gmScript.AddScore();
            gmScript.ScoreSpawn();
            Destroy(gameObject);
        }
    }


}
