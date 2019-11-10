using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Operations : MonoBehaviour
{
    private GameObject[] Operacoes;

    // Start is called before the first frame update
    void Start()
    {
        Operacoes = GameObject.FindGameObjectsWithTag("Operacoes");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void verificaOperacao(int posicao){
        if (posicao == 5) {
            SceneManager.LoadScene("gameoption");
        }
        else {
            PlayerPrefs.SetInt("operacoes", posicao);
            SceneManager.LoadScene("dificulty"); 
        }
               
    }
}
