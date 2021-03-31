using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int score = 0;
    private static int redOfHeartCount = 3;
    public GameObject[] heartReds;
    [SerializeField] private Text scoreTxt;
    [SerializeField] private GameObject gameOverPanel;

    private void Awake()
    {
        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
        scoreTxt.text = "Score:\n" + score.ToString();
    }

    private void LateUpdate()
    {
        scoreTxt.text = "Score:\n" + score.ToString();
    }

    public void DisableRedOfHeart()
    {
        redOfHeartCount--;
        heartReds[redOfHeartCount].SetActive(false);
        if (redOfHeartCount == 0)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
