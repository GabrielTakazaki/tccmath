using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScriptQuestion : MonoBehaviour
{

    public Text questionText, timeText, pontuacao;
    private GameObject[] opcoes;
    private int val1, val2, resp;
    private int[] op;
    private float tempojogado;
    private float time = 10;

    // Start is called before the first frame update
    void Start()
    {
        tempojogado = PlayerPrefs.GetFloat("tempoJogado");
        print(PlayerPrefs.GetFloat("tempoJogado").ToString());
        op = new int[3];
        newQuestion();
        time = 10;
    }

    private void newQuestion()
    {
        opcoes = GameObject.FindGameObjectsWithTag("opcoes");
        time = 20;
        dificuldade();
        operacao();
        op[0] = resp;
        rangeQuestion();
        Shuffle();

        opcoes[0].GetComponentInChildren<Text>().text = "" + op[0];
        opcoes[1].GetComponentInChildren<Text>().text = "" + op[1];
        opcoes[2].GetComponentInChildren<Text>().text = "" + op[2];
    }

    private void operacao()
    {
        if (PlayerPrefs.GetInt("operacoes") == 0)
        {
            questionText.text = "Quanto é " + val1 + " + " + val2;
            resp = val1 + val2;
        }
        if (PlayerPrefs.GetInt("operacoes") == 1)
        {
            questionText.text = "Quanto é " + val1 + " - " + val2;
            resp = val1 - val2;
        }
        if (PlayerPrefs.GetInt("operacoes") == 2)
        {
            questionText.text = "Quanto é " + val1 + " ÷ " + val2;
            resp = val1 / val2;
        }
        if (PlayerPrefs.GetInt("operacoes") == 3)
        {
            questionText.text = "Quanto é " + val1 + " x " + val2;
            resp = val1 * val2;
        }
    }

    private void dificuldade()
    {
        if (PlayerPrefs.GetInt("dificuldade") == 0)
        {
            val1 = Random.Range(0, 11);
            val2 = Random.Range(0, 11);
        }
        if (PlayerPrefs.GetInt("dificuldade") == 1)
        {
            val1 = Random.Range(0, 50);
            val2 = Random.Range(0, 50);
        }
        if (PlayerPrefs.GetInt("dificuldade") == 2)
        {
            val1 = Random.Range(0, 1000);
            val2 = Random.Range(0, 1000);
        }
    }

    private void rangeQuestion()
    {
        if (PlayerPrefs.GetInt("dificuldade") == 0)
        {
            int var = 0;
            do
            {
                var = Random.Range(0, 23);
            } while (var == resp);
            op[1] = var;
            do
            {
                var = Random.Range(0, 23);
            } while (var == resp || var == op[1]);
            op[2] = var;
        }
        if (PlayerPrefs.GetInt("dificuldade") == 1)
        {
            int var = 0;
            do
            {
                var = Random.Range(0, 100);
            } while (var == resp);
            op[1] = var;
            do
            {
                var = Random.Range(0, 100);
            } while (var == resp || var == op[1]);
            op[2] = var;
        }
        if (PlayerPrefs.GetInt("dificuldade") == 2)
        {
            int var = 0;
            do
            {
                var = Random.Range(0, 2000);
            } while (var == resp);
            op[1] = var;
            do
            {
                var = Random.Range(0, 2000);
            } while (var == resp || var == op[1]);
            op[2] = var;
        }

    }

    // Update is called once per frame
    void Update()
    {
        tempojogado += Time.deltaTime;
        PlayerPrefs.SetFloat("tempoJogado", tempojogado);
        timeText.text = "Tempo: " + time.ToString("F0");
        pontuacao.text = "Pontuação: " + PlayerPrefs.GetInt("score").ToString("F0");
        time -= Time.deltaTime;
        if (time < 0)
        {
            print("Time" + time);
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
