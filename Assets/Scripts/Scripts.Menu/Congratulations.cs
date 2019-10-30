using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Congratulations : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void verificaContinue(int posicao){
        if (posicao == 1) {
            SceneManager.LoadScene("playgame");        
        } else if (posicao == 2) {
            SceneManager.LoadScene("homegame");
        }
    }
}
