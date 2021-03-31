using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApartmentCtrl : MonoBehaviour
{
    [SerializeField] private Sprite[] animSprites;
    private Text countText;
    private GameManager gameManager;
    private GameObject counterObject;
    private GameObject counterCanvas;
    private int count = 0;
    private int currentSprite = 1;
    private int apartmentIndex;

    private void Awake()
    {
        counterCanvas = GameObject.FindGameObjectWithTag("CounterCanvas").gameObject;
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = animSprites[0];
    }

    public IEnumerator CounterAndChangeSprite(int second, int apartmentIndex)
    {
        this.apartmentIndex = apartmentIndex;
        GetComponent<Collider2D>().enabled = true;

        counterObject = counterCanvas.transform.Find($"{apartmentIndex}_Counter").gameObject;
        countText = counterObject.GetComponentInChildren<Text>();
        countText.text = second.ToString();
        currentSprite = 1;
        count = 0;

        GetComponent<SpriteRenderer>().sprite = animSprites[currentSprite];

        while (true)
        {
            if (animSprites.Length - 1 == currentSprite)
            {
                if (second % (animSprites.Length - 1) == 0)
                {
                    for (int i = 0; i < (second / (animSprites.Length - 1)); i++)
                    {
                        if (!CreateFire.hasFire[this.apartmentIndex])
                        {
                            DestroyCounterObject();
                            break;
                        }
                        yield return new WaitForSeconds(1);
                        Count(second);
                    }
                }
                else
                {
                    for (int i = 0; i < ((second / (animSprites.Length - 1)) + (second % (animSprites.Length - 1))); i++)
                    {
                        if (!CreateFire.hasFire[this.apartmentIndex])
                        {
                            DestroyCounterObject();
                            break;
                        }
                        yield return new WaitForSeconds(1);
                        Count(second);
                    }
                }

                if (count == second)
                {
                    DestroyCounterObject();
                    gameManager.DisableRedOfHeart();
                }
                break;
            }

            if (!CreateFire.hasFire[this.apartmentIndex])
            {
                DestroyCounterObject();
                break;
            }

            yield return new WaitForSeconds(1);
            Count(second);

            if (count % (second / (animSprites.Length - 1)) == 0)
            {
                currentSprite++;
                GetComponent<SpriteRenderer>().sprite = animSprites[currentSprite];
            };
        }
    }

    private void Count(int second)
    {
        if (!CreateFire.hasFire[this.apartmentIndex])
        {
            DestroyCounterObject();
        }
        else
        {
            count++;
            countText.text = (second - count).ToString();
        }
    }

    private void DestroyCounterObject()
    {
        StopCoroutine("CounterAndChangeSprite");
        GetComponent<SpriteRenderer>().sprite = animSprites[0];
        Destroy(counterObject);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Smoke" && FireExtinguishing.isSmoke)
        {
            CreateFire.hasFire[apartmentIndex] = false;
            GetComponent<Collider2D>().enabled = false;
            GameManager.score += 2;
        }
    }
}
