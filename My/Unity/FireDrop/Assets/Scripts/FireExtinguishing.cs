using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguishing : MonoBehaviour
{
    [SerializeField] private Sprite[] smokeSprites;
    public static bool isSmoke = false;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = null;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Extinguishing();
        }
    }

    public void Extinguishing()
    {
        if (!isSmoke)
        {
            isSmoke = true;
            StartCoroutine("SmokeSpriteAnim");
        }
    }

    private IEnumerator SmokeSpriteAnim()
    {
        foreach (Sprite item in smokeSprites)
        {
            GetComponent<SpriteRenderer>().sprite = item;
            if (item == smokeSprites[smokeSprites.Length - 1]) break;
            yield return new WaitForSeconds(1 / (smokeSprites.Length - 1));
        }
        GetComponent<SpriteRenderer>().sprite = null;
        isSmoke = false;
    }
}
