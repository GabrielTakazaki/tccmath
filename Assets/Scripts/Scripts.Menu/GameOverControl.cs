using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverControl : MonoBehaviour
{
    public TextMesh pontuacao;
    private float time;
    public TextMesh tempo;
    public TextMesh recorde;
    // Start is called before the first frame update
    void Start()
    {
        time = PlayerPrefs.GetFloat("tempoJogado");
        pontuacao.text = PlayerPrefs.GetInt("score").ToString();
        recorde.text = PlayerPrefs.GetInt("recorde").ToString();
        tempo.text = time.ToString("F0") + " seg";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            SceneManager.LoadScene("homegame");
        }
    }
}
