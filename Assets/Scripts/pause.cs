using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject player;
    private GameObject sounds;

    private void Start()
    {
        sounds = GameObject.FindGameObjectWithTag("sound");
    }

    public void resume()
    {
        pauseMenu.SetActive(false);
        player.GetComponent<playerController>().enabled = true;
    }

    public void reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void menu()
    {
        SceneManager.LoadScene(0);
    }

    public void mute()
    {
        if (sounds.GetComponent<AudioSource>().volume != 0)
        {
            sounds.GetComponent<AudioSource>().volume = 0;
        } else
        {
            sounds.GetComponent<AudioSource>().volume = 0.2f;
        }
        
    }
}
