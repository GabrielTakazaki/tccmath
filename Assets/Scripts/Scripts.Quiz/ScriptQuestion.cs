using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScriptQuestion : MonoBehaviour{

    public Text questionText, timeText;
    private GameObject[] opcoes;
    private int val1, val2, resp;
    private int[] op;
    private float time = 10;

    // Start is called before the first frame update
    void Start(){
        op = new int[3];
        newQuestion();
        time = 5;
    }
    
    private void newQuestion (){
        opcoes = GameObject.FindGameObjectsWithTag("opcoes");
        time = 20;
        val1 = Random.Range (0, 11);
        val2 = Random.Range (0, 11);
        questionText.text = "Quanto é " + val1 + " + " + val2;
        resp = val1 + val2;  
        op[0] = resp;   
        int var = 0; 
        
        do{
            var = Random.Range (0, 23);
        }while(var == resp);
        op[1] = var;

        do{
            var = Random.Range (0, 23);
        }while(var == resp || var == op[1]);

        op[2] = var;   
        Shuffle();

        opcoes[0].GetComponentInChildren<Text>().text = ""+op[0];
        opcoes[1].GetComponentInChildren<Text>().text = ""+op[1];
        opcoes[2].GetComponentInChildren<Text>().text = ""+op[2];
    }
    // Update is called once per frame
    void Update(){   
        timeText.text = "Tempo: " + time.ToString("F0") ;
        
            time -= Time.deltaTime;
            if(time < 0){
                print("Time" + time);
               SceneManager.LoadScene("gameover"); 
            }
    }

    public void verificaResposta(int posicao){
        if(opcoes[posicao].GetComponentInChildren<Text>().text == resp.ToString()){
            print("acertou");
            SceneManager.LoadScene("playgame");
        }
        else{
            print("Errou");
            SceneManager.LoadScene("gameover");    
        }
    }

    public void Shuffle() {
         for (int i = 0; i < op.Length; i++) {
             int rnd = Random.Range(0, op.Length);
             int tempGO = op[rnd];
             op[rnd] = op[i];
             op[i] = tempGO;
         }
     }
}
