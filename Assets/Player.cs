using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 2;
    public GameObject checkerCollider;
    public int health = 3;
    public GameObject healthImage1;
    public GameObject healthImage2;

    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            checkerCollider.SetActive(true);
            StartCoroutine(DeactivateCollider());
        }
    }

    IEnumerator DeactivateCollider()
    {
        yield return new WaitForSeconds(.1f);
        checkerCollider.SetActive(false);
        health--;

        healthImage1.SetActive(false);
        if(health < 2){
            healthImage2.SetActive(false);
        }
        if(health < 1){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
