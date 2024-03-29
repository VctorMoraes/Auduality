﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public bool playable = false;

    public float speed = 2;
    public GameObject checkerCollider;
    public int health = 3;
    public GameObject healthImage1;
    public GameObject healthImage2;
    public GameObject healthImage3;
    public Animator effectAnimation;

    public Animator spriteAnimator;
    public SpriteRenderer playerSprite;
    public bool turnedLeft = false;

    public bool victory = false;

    public bool checkerCooldown;

    public SpriteRenderer musician;

    void Update()
    {
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && playable)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            spriteAnimator.SetBool("right", true);
            spriteAnimator.SetBool("up", false);
            spriteAnimator.SetBool("down", false);

            if (turnedLeft)
            {
                playerSprite.flipX = false;
                turnedLeft = false;
            }
        }
        if ((Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D)) && playable)
        {
            spriteAnimator.SetBool("right", false);
        }

        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && playable)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            spriteAnimator.SetBool("right", true);
            spriteAnimator.SetBool("up", false);
            spriteAnimator.SetBool("down", false);

            if (!turnedLeft)
            {
                playerSprite.flipX = true;
                turnedLeft = true;
            }
        }
        if ((Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A)) && playable)
        {
            spriteAnimator.SetBool("right", false);
        }

        if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && playable)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            spriteAnimator.SetBool("right", false);
            spriteAnimator.SetBool("up", false);
            spriteAnimator.SetBool("down", true);
        }
        if ((Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)) && playable)
        {
            spriteAnimator.SetBool("down", false);
        }

        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && playable)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            spriteAnimator.SetBool("right", false);
            spriteAnimator.SetBool("up", true);
            spriteAnimator.SetBool("down", false);
        }
        if ((Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W)) && playable)
        {
            spriteAnimator.SetBool("up", false);
        }

        if ((Input.GetKeyDown(KeyCode.Space)) && playable && !checkerCooldown)
        {
            checkerCollider.SetActive(true);
            StartCoroutine(DeactivateCollider());
            checkerCooldown = true;
            StartCoroutine(CheckerCooldown());
        }
    }

    IEnumerator CheckerCooldown()
    {
        yield return new WaitForSeconds(1f);
        checkerCooldown = false;
    }

    IEnumerator DeactivateCollider()
    {
        effectAnimation.Play("effect");

        yield return new WaitForSeconds(.1f);
        if (!victory)
        {
            checkerCollider.SetActive(false);
            health--;

            healthImage1.SetActive(false);
            if (health < 2)
            {
                healthImage2.SetActive(false);
            }
            if (health < 1)
            {
                StartCoroutine(Death());
            }
        }
    }

    IEnumerator Death()
    {
        healthImage3.SetActive(false);
        yield return new WaitForSeconds(1.2f);
        if (!victory)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void NextLevel()
    {
        StartCoroutine(NextLevelCoroutine());
        StartCoroutine(RevealMusician());
    }

    IEnumerator RevealMusician()
    {

        Color c = musician.color;
        for (float alpha = 0f; alpha <= 1; alpha += 0.01f)
        {
            c.a = alpha;
            musician.color = c;
            yield return new WaitForSeconds(.006f);
        }
    }

    IEnumerator NextLevelCoroutine()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
