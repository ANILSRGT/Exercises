using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    [Header("Squares Panel")]
    [SerializeField] private GameObject squarePrefab;
    [SerializeField] private Transform squaresPanel;

    [Header("Squares Panel")]
    [SerializeField] private Sprite[] squareSprites;
    private GameObject[] squares = new GameObject[25];

    [Header("Question Panel")]
    [SerializeField] private Transform questionPanel;
    [SerializeField] private Text questionTxt;

    [Header("End Game Panel")]
    [SerializeField] private GameObject endGamePanel;

    [Header("Other")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip buttonClip;

    //Other Variables
    private List<int> sectionValuesList = new List<int>();
    private GameObject selectedSquare;
    private int dividend, divisor;
    private int whichQuestion;
    private int correctResult;
    private int buttonTextValue;
    private int remainingHealth;
    private bool canPressButton;
    private GameLevelEnums.QuestionDifficultyLevel questionDifficultyLevel;
    private RemainingHealthsManager remainingHealthsManager;
    private ScoreManager scoreManager;

    private void Awake()
    {

        remainingHealth = 3;
        endGamePanel.GetComponent<RectTransform>().localScale = Vector3.zero;

        remainingHealthsManager = Object.FindObjectOfType<RemainingHealthsManager>();
        scoreManager = Object.FindObjectOfType<ScoreManager>();

        remainingHealthsManager.ReaminingHealthCtrl(remainingHealth);

    }

    private void Start()
    {
        canPressButton = false;

        questionPanel.GetComponent<RectTransform>().localScale = Vector3.zero;

        CreateSquares();
    }

    public void CreateSquares()
    {
        for (int i = 0; i < 25; i++)
        {
            GameObject square = Instantiate(squarePrefab, squaresPanel);
            square.transform.GetChild(1).GetComponent<Image>().sprite = squareSprites[Random.Range(0, squareSprites.Length)];
            square.GetComponent<Button>().onClick.AddListener(() => OnClickSquareButton());
            squares[i] = square;
        }

        PrintTheSectionValuesToText();

        StartCoroutine(DoFadeRoutine());
        Invoke("ActiveTheQuestionPanel", 2f);
    }

    private void OnClickSquareButton()
    {
        if (canPressButton)
        {
            audioSource.PlayOneShot(buttonClip);
            selectedSquare = EventSystem.current.currentSelectedGameObject;

            buttonTextValue = int.Parse(selectedSquare.transform.GetChild(0).GetComponent<Text>().text);

            CheckToResult();
        }
    }

    private void CheckToResult()
    {
        if (buttonTextValue == correctResult)
        {
            selectedSquare.transform.GetChild(0).GetComponent<Text>().enabled = false;
            selectedSquare.transform.GetChild(1).GetComponent<Image>().enabled = true;
            selectedSquare.transform.GetComponent<Button>().interactable = false;

            scoreManager.AddScore(questionDifficultyLevel);
            sectionValuesList.RemoveAt(whichQuestion);

            if (sectionValuesList.Count <= 0)
            {
                EndGame();
                return;
            }

            ActiveTheQuestionPanel();
        }
        else
        {
            remainingHealth--;
            remainingHealthsManager.ReaminingHealthCtrl(remainingHealth);
        }

        if (remainingHealth <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        canPressButton = false;
        endGamePanel.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
    }

    IEnumerator DoFadeRoutine()
    {
        foreach (var square in squares)
        {
            square.GetComponent<CanvasGroup>().DOFade(1, 0.2f);
            yield return new WaitForSeconds(0.075f);
        }
    }

    private void PrintTheSectionValuesToText()
    {
        foreach (var square in squares)
        {
            int randValue = Random.Range(1, 13);
            sectionValuesList.Add(randValue);
            square.transform.GetChild(0).GetComponent<Text>().text = randValue.ToString();
        }
    }

    private void ActiveTheQuestionPanel()
    {
        AskTheQuestion();
        // The isButtonPress will be true when the questionPanel is active and the animation is complete.
        questionPanel.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack).OnComplete(() => canPressButton = true);

    }

    private void AskTheQuestion()
    {
        divisor = Random.Range(2, 11);
        whichQuestion = Random.Range(0, sectionValuesList.Count);
        correctResult = sectionValuesList[whichQuestion];
        dividend = divisor * correctResult;

        if (dividend <= 40)
        {
            questionDifficultyLevel = GameLevelEnums.QuestionDifficultyLevel.EASY;
        }
        else if (dividend > 40 && dividend <= 80)
        {
            questionDifficultyLevel = GameLevelEnums.QuestionDifficultyLevel.MEDIUM;
        }
        else
        {
            questionDifficultyLevel = GameLevelEnums.QuestionDifficultyLevel.HARD;
        }

        questionTxt.text = dividend.ToString() + " / " + divisor.ToString();
    }
}
