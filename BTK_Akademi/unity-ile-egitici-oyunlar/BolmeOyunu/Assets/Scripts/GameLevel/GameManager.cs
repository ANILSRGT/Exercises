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
    private GameObject[] squares = new GameObject[25];

    [Header("Question Panel")]
    [SerializeField] private Transform questionPanel;
    [SerializeField] private Text questionTxt;

    //Other Variables
    private List<int> sectionValuesList = new List<int>();
    private int dividend, divisor;
    private int whichQuestion;
    private int buttonTextValue;

    private void Start()
    {
        questionPanel.GetComponent<RectTransform>().localScale = Vector3.zero;

        CreateSquares();
    }

    public void CreateSquares()
    {
        for (int i = 0; i < 25; i++)
        {
            GameObject square = Instantiate(squarePrefab, squaresPanel);
            square.GetComponent<Button>().onClick.AddListener(() => OnClickSquareButton());
            squares[i] = square;
        }

        PrintTheSectionValuesToText();

        StartCoroutine(DoFadeRoutine());
        Invoke("ActiveTheQuestionPanel", 2f);
    }

    private void OnClickSquareButton()
    {
        buttonTextValue = int.Parse(EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text);
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
        questionPanel.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
    }

    private void AskTheQuestion()
    {
        divisor = Random.Range(2, 11);
        whichQuestion = Random.Range(0, sectionValuesList.Count);
        dividend = divisor * sectionValuesList[whichQuestion];
        questionTxt.text = dividend.ToString() + " / " + divisor.ToString();
    }
}
