using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApartmentCtrl : MonoBehaviour
{
    [SerializeField] private Sprite[] animSprites;
    private Text countText;
    private GameManager gameManager;

    private bool hasFire = false;

    public bool HasFire
    {
        get { return hasFire; }
        set
        {
            if (value == hasFire)
                return;

            hasFire = value;
            if (hasFire)
            {
                GetComponent<Collider2D>().enabled = true;
                StartCoroutine(CounterAndChangeSprite(Random.Range(8, 14)));
            }
        }
    }

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = animSprites[0];
    }

    private IEnumerator CounterAndChangeSprite(int second)
    {
        GameObject counterObject = GameObject.FindGameObjectWithTag("CounterCanvas").gameObject.transform.Find($"{this.gameObject.name}_Counter").gameObject;
        countText = counterObject.GetComponentInChildren<Text>();
        countText.text = second.ToString();
        int currentSprite = 1;
        int count = 0;
        GetComponent<SpriteRenderer>().sprite = animSprites[currentSprite];
        while (true)
        {
            if (animSprites.Length - 1 == currentSprite)
            {
                if (second % (animSprites.Length - 1) == 0)
                {
                    for (int i = 0; i < (second / (animSprites.Length - 1)); i++)
                    {
                        if (!hasFire)
                        {
                            DestroyCounterObject();
                        }
                        yield return new WaitForSeconds(1);
                        Count();
                    }
                }
                else
                {
                    for (int i = 0; i < ((second / (animSprites.Length - 1)) + (second % (animSprites.Length - 1))); i++)
                    {
                        if (!hasFire)
                        {
                            DestroyCounterObject();
                        }
                        yield return new WaitForSeconds(1);
                        Count();
                    }
                }

                gameManager.DisableRedOfHeart();
                DestroyCounterObject();
                break;
            }
            if (!hasFire)
            {
                DestroyCounterObject();
            }
            yield return new WaitForSeconds(1);
            Count();
            if (count % (second / (animSprites.Length - 1)) == 0)
            {
                currentSprite++;
                GetComponent<SpriteRenderer>().sprite = animSprites[currentSprite];
            };
        }

        void Count()
        {
            if (!hasFire)
            {
                DestroyCounterObject();
            }
            else
            {
                count++;
                countText.text = (second - count).ToString();
            }

        }

        void DestroyCounterObject()
        {
            StopCoroutine("CounterAndChangeSprite");
            GetComponent<SpriteRenderer>().sprite = animSprites[0];
            Destroy(counterObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Smoke" && FireExtinguishing.isSmoke)
        {
            GameManager.score += 2;
            GetComponent<Collider2D>().enabled = false;
            hasFire = false;
        }
    }
}
