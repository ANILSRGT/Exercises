using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AlphaPanelManager : MonoBehaviour
{
    private void Start()
    {
        this.GetComponent<CanvasGroup>().DOFade(0, 2f);
    }
}
