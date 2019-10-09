using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    public float speed;
    public GameObject bloco;

    private PlayerControl player;
    private bool passou;

    private SpawnObject spawn;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType (typeof(PlayerControl)) as PlayerControl;
        spawn = FindObjectOfType (typeof(SpawnObject)) as SpawnObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (player.score > 30 ) {
            speed = -14;
            spawn.rateSpawn = 0.2f;
        }
        else if (player.score > 20) {
            speed = -12;
            spawn.rateSpawn = 0.4f;
        }
        else if (player.score > 10) {
            speed = -10;
            spawn.rateSpawn = 0.6f;
        }

        transform.position += new Vector3 (speed, 0, transform.position.y) * Time.deltaTime;

        if (transform.position.x < player.transform.position.x && !passou) {
            player.addScore();
            passou = true;
        }

        if (transform.position.x < -5.93f) {
            bloco.SetActive (false);
        }
    }
    void OnEnable () {
        passou = false;
    }
}
