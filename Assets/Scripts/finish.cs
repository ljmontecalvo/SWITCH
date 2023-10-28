using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class finish : MonoBehaviour
{
    public AudioSource sound;

    private GameObject levelLoader;

    private void Start()
    {
        levelLoader = GameObject.FindGameObjectWithTag("Level Loader");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sound.Play();
            StartCoroutine("delay");
        }
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(0.4f);
        levelLoader.GetComponent<levelLoader>().LoadNextLevel();
    }
}
