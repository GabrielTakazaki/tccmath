using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{
    public RoundData[] allRoundsData;

    private int roundIndex;
    private int playerHighScore;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        // SceneManager.LoadScene("Menu");
    }

    public void SetRoundData(int round)
    {
        roundIndex = round;
    }
    public RoundData GetCurrentRoundData()
    {
        return allRoundsData[roundIndex];
    }
}
