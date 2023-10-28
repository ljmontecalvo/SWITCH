using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine;

public class main : MonoBehaviour
{
    public GameObject canvas;
    public GameObject about;
    public GameObject notes;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void About()
    {
        canvas.SetActive(false);
        about.SetActive(true);
    }

    public void versionNotes()
    {
        canvas.SetActive(false);
        notes.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Back()
    {
        canvas.SetActive(true);
        about.SetActive(false);
        notes.SetActive(false);
    }
}