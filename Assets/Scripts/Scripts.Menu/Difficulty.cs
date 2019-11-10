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
    public void verificaDificuldade(int posicao)
    {
        if (posicao == 4) {
            SceneManager.LoadScene("operacoes");
        }
        else {
            PlayerPrefs.SetInt("dificuldade", posicao);
            if (PlayerPrefs.GetInt("tipo") == 1)
            {
                SceneManager.LoadScene("playgame");
            } else {
                SceneManager.LoadScene("mathematic");
            }
        }
    }
}
