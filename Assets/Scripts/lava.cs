using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class lava : MonoBehaviour
{
    public AudioSource sound;
    bool played = false;

    private GameObject levelLoader;

    private void Start()
    {
        levelLoader = GameObject.FindGameObjectWithTag("Level Loader");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!played)
            {
                sound.Play();
                collision.GetComponent<Rigidbody2D>().gravityScale = 0.05f;
                collision.GetComponent<playerController>().enabled = false;
                collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -0.2f);
                StartCoroutine("waitSeconds");
                played = true;
            }
        }
    }

    IEnumerator waitSeconds()
    {
        yield return new WaitForSeconds(1.7f);
        levelLoader.GetComponent<levelLoader>().ReloadScene();
    }
}
