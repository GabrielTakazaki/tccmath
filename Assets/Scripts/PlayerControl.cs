using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public GameObject player;
    
    public float maxHeight;
    public float minHeight;    
    public float maxWidth;
    public float minWidth;
    public float speedHeight;
    public float speedWidth;

    public TextMesh pontos;
    public TextMesh record;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("score");
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speedHeight;
        float translationW = Input.GetAxis("Horizontal") * speedWidth;
        player.transform.Translate(translationW,translation, 0);
        
        if(player.transform.position.y > maxHeight) {
            player.transform.position = new Vector2(player.transform.position.x, maxHeight);
        }            
        if(player.transform.position.y < minHeight) {
            player.transform.position = new Vector2(player.transform.position.x, minHeight);
        }
        if(player.transform.position.x > maxWidth) {
            player.transform.position = new Vector2(maxWidth, player.transform.position.y);
        }            
        if(player.transform.position.x < minWidth) {
            player.transform.position = new Vector2(minWidth, player.transform.position.y);
        }
        pontos.text = score.ToString ();
        record.text = PlayerPrefs.GetInt("recorde").ToString();
    }
    void OnTriggerEnter2D(Collider2D col) {
        if (score > PlayerPrefs.GetInt("recorde")) {
            PlayerPrefs.SetInt("recorde", score);
        }
        PlayerPrefs.SetInt("score", score);
        SceneManager.LoadScene("mathematic");
    }
    public void addScore() {
        score++;
    }
}
