using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    public float speed;
    public GameObject bloco;
    private int x ;
    private PlayerControl player;
    private bool passou;
    private bool velocidade = true;
    private SpawnObject spawn;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType (typeof(PlayerControl)) as PlayerControl;
        spawn = FindObjectOfType (typeof(SpawnObject)) as SpawnObject;
        x = 100;

    }

    // Update is called once per frame
    void Update()
    {
        if (player.score % 100 == 0 && velocidade && player.score != 0) {
            speed -= 0.5f;
            spawn.rateSpawn -= 0.05f;
            velocidade = false;
        }
        else if (player.score == 30 ) {
            speed = -11;
            spawn.rateSpawn = 0.6f;
        }
        else if (player.score== 20) {
            speed = -9.5f;
            spawn.rateSpawn = 0.7f;
        }
        else if (player.score == 10) {
            speed = -8;
            spawn.rateSpawn = 0.8f;
        }
        else if (player.score % 50 == 0 && player.score > x) {
            velocidade = true;  
            x += 100;
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
