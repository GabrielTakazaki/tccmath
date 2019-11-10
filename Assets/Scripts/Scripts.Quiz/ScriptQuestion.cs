using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScriptQuestion : MonoBehaviour
{

    public Text questionText, timeText, pontuacao;
    private GameObject[] opcoes;
    private int val1, val2, resp, ini, fim, tipoOperacao;
    private int[] op, resposta;
    private float tempojogado;
    private float time = 10;

    // Start is called before the first frame update
    void Start()
    {
        tempojogado = PlayerPrefs.GetFloat("tempoJogado");
        tipoOperacao = PlayerPrefs.GetInt("operacoes");
        op = new int[3];
        newQuestion();
        time = 10;
    }

    private void newQuestion()
    {
        opcoes = GameObject.FindGameObjectsWithTag("opcoes");
        dificuldade();
        operacao();
        op[0] = resp;
        rangeQuestion();
        Shuffle();

        opcoes[0].GetComponentInChildren<Text>().text = "" + op[0];
        opcoes[1].GetComponentInChildren<Text>().text = "" + op[1];
        opcoes[2].GetComponentInChildren<Text>().text = "" + op[2];
    }
    // 0 = Facil, 1 = Medio, 2 = Dificil
    private void dificuldade()
    {
        if (PlayerPrefs.GetInt("dificuldade") == 1)
        {
            ini = 0;
            fim = 11;
            val1 = Random.Range(0, 11);
            val2 = Random.Range(0, 11);
        }
        if (PlayerPrefs.GetInt("dificuldade") == 2)
        {
            ini = 0;
            fim = 50;
            val1 = Random.Range(0, 50);
            val2 = Random.Range(0, 50);
        }
        if (PlayerPrefs.GetInt("dificuldade") == 3)
        {
            ini = 0;
            fim = 1000;
            val1 = Random.Range(0, 1000);
            val2 = Random.Range(0, 1000);
        }
    }
    // 0 = adicao, 1 = subtracao, 2 divisao, 3 multiplicacao
    private void operacao()
    {
        if (tipoOperacao == 1)
        {
            questionText.text = "Quanto é " + val1 + " + " + val2;
            resp = val1 + val2;
        }
        if (tipoOperacao == 2)
        {
            questionText.text = "Quanto é " + val1 + " - " + val2;
            resp = val1 - val2;
        }
        if (tipoOperacao == 3)
        {
            resposta = geraDivisao(val1, val2);
            questionText.text = "Quanto é " + resposta[0] + " ÷ " + resposta[1];
            resp = resposta[0]/resposta[1];
            
        }
        if (tipoOperacao == 4)
        {
            questionText.text = "Quanto é " + val1 + " x " + val2;
            resp = val1 * val2;
        }
    }
    private void rangeQuestion()
    {
        int var = 0;
        do
        {
            var = numeroAleatorio();
        } while (var == resp);
        op[1] = var;
        do
        {
            var = numeroAleatorio();
        } while (var == resp || var == op[1]);
        op[2] = var;
    }

    // Update is called once per frame
    private int numeroAleatorio() {
        int random1 = Random.Range(ini,fim);
        int random2 = Random.Range(ini,fim);

        if (tipoOperacao == 1) 
            return random1 + random2;
        
        if (tipoOperacao == 2) 
            return random1 - random2;

        if (tipoOperacao == 3){

            int[] numeroDivisao = geraDivisao(random1, random2);
            return numeroDivisao[0] / numeroDivisao[1];
        }
        if (tipoOperacao == 4) 
            return random1 * random2;

        else {
            return 0;
        } 
    }
    private int[] geraDivisao(int x, int y) {
        do {
            x = Random.Range(1,fim);
            y = Random.Range(1,fim);
        } while (x < y || x % y != 0);
        int[] vetorNumeros = new int[2];
        vetorNumeros[0] = x;
        vetorNumeros[1] = y;
        return vetorNumeros;
    }
    void Update()
    {
        tempojogado += Time.deltaTime;
        PlayerPrefs.SetFloat("tempoJogado", tempojogado);
        timeText.text = "Tempo: " + time.ToString("F0");
        pontuacao.text = "Pontuação: " + PlayerPrefs.GetInt("score").ToString("F0");
        time -= Time.deltaTime;
        if (time < 0)
        {
            SceneManager.LoadScene("gameover");
        }
    }

    public void verificaResposta(int posicao)
    {
        if (opcoes[posicao].GetComponentInChildren<Text>().text == resp.ToString())
        {
            if (PlayerPrefs.GetInt("tipo") == 1)
            {
                SceneManager.LoadScene("playgame");
            }
            else
            {
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score")+10);
                SceneManager.LoadScene("mathematic");
            }
        }
        else
        {
            SceneManager.LoadScene("gameover");
        }
    }

    public void Shuffle()
    {
        for (int i = 0; i < op.Length; i++)
        {
            int rnd = Random.Range(0, op.Length);
            int tempGO = op[rnd];
            op[rnd] = op[i];
            op[i] = tempGO;
        }
    }
}
