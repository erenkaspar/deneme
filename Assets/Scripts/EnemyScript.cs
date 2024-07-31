using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyScript : MonoBehaviour
{

    GameObject player;
    public float moveSpeed;
    public Vector3 direction;
    GameManagerScript gmScript;

    void Start()
    {
        player = GameObject.Find("Player");
        direction = (player.transform.position - transform.position).normalized;

        gmScript = GameObject.FindObjectOfType<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gmScript.gameIsEnabled) {
            transform.position += direction * moveSpeed * Time.deltaTime;
        }

        if( Mathf.Abs(transform.position.x) > 15 || Mathf.Abs(transform.position.y) > 11) {
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            gmScript.HitPlayer();
            Destroy(gameObject);
        }
    }
}
