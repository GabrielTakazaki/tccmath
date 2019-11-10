using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    private GameObject[] exit;
    public Text recorde;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("passou", 0);
        PlayerPrefs.SetInt("score", 0);
        exit = GameObject.FindGameObjectsWithTag("exit");
    }

    // Update is called once per frame
    void Update()
    {
        recorde.text = "Recorde: " + PlayerPrefs.GetInt("recorde").ToString();
    }
    public void opcoes(int opcoes)
    {
        if (opcoes == 1)
        {
            SceneManager.LoadScene("gameoption");
        }
        if (opcoes == 2)
            Application.Quit();
    }
}
