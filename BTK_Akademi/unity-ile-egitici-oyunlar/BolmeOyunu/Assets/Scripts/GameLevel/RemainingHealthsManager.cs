using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemainingHealthsManager : MonoBehaviour
{
    [SerializeField] private GameObject[] remainingHealthObjs = new GameObject[3];

    private void Start()
    {

    }

    public void ReaminingHealthCtrl(int remainingHealth)
    {
        for (int i = remainingHealth; i < remainingHealthObjs.Length; i++)
        {
            remainingHealthObjs[i].SetActive(false);
        }
        for (int i = 0; i < remainingHealth; i++)
        {
            remainingHealthObjs[i].SetActive(true);
        }
    }
}
