using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    
    public TextMesh recorde;
    // Start is called before the first frame update
    void Start()
    {        
        recorde.text = PlayerPrefs.GetInt("recorde").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            SceneManager.LoadScene("playgame");
        }
    }
}
