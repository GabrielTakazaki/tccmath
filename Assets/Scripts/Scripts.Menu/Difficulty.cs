using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulty : MonoBehaviour
{
    private GameObject[] Dificuldade;
    // Start is called before the first frame update
    void Start()
    {
        Dificuldade = GameObject.FindGameObjectsWithTag("Dificuldade");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void verificaDificuldade(int posicao){
        PlayerPrefs.SetInt("dificuldade", posicao);
        SceneManager.LoadScene("playgame");        
    }
}
