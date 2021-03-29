using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCtrl : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private Sprite[] walkSprites;
    private Rigidbody2D rb2D;
    private float axisX;
    private float axisY;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        axisX = Input.GetAxis("Horizontal");
        axisY = Input.GetAxis("Vertical");

        rb2D.velocity = new Vector2(axisX * moveSpeed, rb2D.gravityScale == 1 ? rb2D.velocity.y : axisY * moveSpeed * 0.75f);
        if (axisX != 0)
        {
            StartCoroutine(WalkAnim());
            if (axisX < 0)
            {
                transform.rotation = new Quaternion(0, 180, 0, 0);
            }
            else if (axisX > 0)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = walkSprites[0];
                StopCoroutine(WalkAnim());
            }
        }
    }

    private IEnumerator WalkAnim()
    {
        int currentSprite = 0;
        while (true)
        {
            GetComponent<SpriteRenderer>().sprite = walkSprites[currentSprite];
            if (axisX == 0)
            {
                GetComponent<SpriteRenderer>().sprite = walkSprites[0];
                break;
            }
            yield return new WaitForSeconds(0.2f);
            if (axisX == 0)
            {
                GetComponent<SpriteRenderer>().sprite = walkSprites[0];
                break;
            }
            currentSprite = currentSprite == walkSprites.Length - 1 ? 0 : +1;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Stair")
        {
            rb2D.gravityScale = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Stair")
        {
            rb2D.gravityScale = 1;
        }
    }
}
