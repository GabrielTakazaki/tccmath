using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionGame : MonoBehaviour
{
    private GameObject[] TipoDeJogo;
    // Start is called before the first frame update
    void Start()
    {
        TipoDeJogo = GameObject.FindGameObjectsWithTag("Tipo");
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void verificaOperacao(int posicao){
        PlayerPrefs.SetInt("tipo", posicao);
        SceneManager.LoadScene("operacoes");        
    }
}
