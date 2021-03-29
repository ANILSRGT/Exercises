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
    private bool endGame = false;
    [SerializeField] private Text scoreTxt;

    private void Awake()
    {
        endGame = false;
        scoreTxt.text = "Score:\n" + score.ToString();
    }

    private void LateUpdate()
    {
        scoreTxt.text = "Score:\n" + score.ToString();

        if (endGame == true)
        {
            endGame = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void DisableRedOfHeart()
    {
        redOfHeartCount--;
        heartReds[redOfHeartCount].SetActive(false);
        if (redOfHeartCount == 0) endGame = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
