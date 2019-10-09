using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverControl : MonoBehaviour
{
    public TextMesh pontuacao;
    public TextMesh recorde;
    // Start is called before the first frame update
    void Start()
    {
        pontuacao.text = PlayerPrefs.GetInt("score").ToString();
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
