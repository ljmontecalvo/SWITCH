using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour
{
    public GameObject[] redDoors;
    public GameObject[] yellowDoors;
    public GameObject[] greenDoors;
    public GameObject[] blueDoors;
    public GameObject[] magicDoors;

    public bool tokenTrue = true;
    public GameObject token;

    public GameObject[] buttons;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player.GetComponent<playerController>().color == "red")
        {
            for (int i = 0; i < redDoors.Length; i++)
            {
                redDoors[i].SetActive(false);
            }

            for (int i = 0; i < yellowDoors.Length; i++)
            {
                yellowDoors[i].SetActive(true);
            }

            for (int i = 0; i < greenDoors.Length; i++)
            {
                greenDoors[i].SetActive(true);
            }

            for (int i = 0; i < blueDoors.Length; i++)
            {
                blueDoors[i].SetActive(true);
            }

            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].GetComponent<button>().pressedStatus && buttons[i].name != "redButton")
                {
                    buttons[i].GetComponent<BoxCollider2D>().enabled = true;
                    buttons[i].GetComponent<button>().pressedStatus = false;
                    buttons[i].GetComponent<Animator>().SetTrigger("up");
                }
            }
        } else if (player.GetComponent<playerController>().color == "yellow")
        {
            for (int i = 0; i < redDoors.Length; i++)
            {
                redDoors[i].SetActive(true);
            }

            for (int i = 0; i < yellowDoors.Length; i++)
            {
                yellowDoors[i].SetActive(false);
            }

            for (int i = 0; i < greenDoors.Length; i++)
            {
                greenDoors[i].SetActive(true);
            }

            for (int i = 0; i < blueDoors.Length; i++)
            {
                blueDoors[i].SetActive(true);
            }

            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].GetComponent<button>().pressedStatus && buttons[i].name != "yellowButton")
                {
                    buttons[i].GetComponent<BoxCollider2D>().enabled = true;
                    buttons[i].GetComponent<button>().pressedStatus = false;
                    buttons[i].GetComponent<Animator>().SetTrigger("up");
                }
            }
        } else if (player.GetComponent<playerController>().color == "green")
        {
            for (int i = 0; i < redDoors.Length; i++)
            {
                redDoors[i].SetActive(true);
            }

            for (int i = 0; i < yellowDoors.Length; i++)
            {
                yellowDoors[i].SetActive(true);
            }

            for (int i = 0; i < greenDoors.Length; i++)
            {
                greenDoors[i].SetActive(false);
            }

            for (int i = 0; i < blueDoors.Length; i++)
            {
                blueDoors[i].SetActive(true);
            }

            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].GetComponent<button>().pressedStatus && buttons[i].name != "greenButton")
                {
                    buttons[i].GetComponent<BoxCollider2D>().enabled = true;
                    buttons[i].GetComponent<button>().pressedStatus = false;
                    buttons[i].GetComponent<Animator>().SetTrigger("up");
                }
            }
        } else if (player.GetComponent<playerController>().color == "blue")
        {
            for (int i = 0; i < redDoors.Length; i++)
            {
                redDoors[i].SetActive(true);
            }

            for (int i = 0; i < yellowDoors.Length; i++)
            {
                yellowDoors[i].SetActive(true);
            }

            for (int i = 0; i < greenDoors.Length; i++)
            {
                greenDoors[i].SetActive(true);
            }

            for (int i = 0; i < blueDoors.Length; i++)
            {
                blueDoors[i].SetActive(false);
            }

            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].GetComponent<button>().pressedStatus && buttons[i].name != "blueButton")
                {
                    buttons[i].GetComponent<BoxCollider2D>().enabled = true;
                    buttons[i].GetComponent<button>().pressedStatus = false;
                    buttons[i].GetComponent<Animator>().SetTrigger("up");
                }
            }
        }

        if (tokenTrue)
        {
            if (token.GetComponent<token>().isCollected)
            {
                for (int i = 0; i < magicDoors.Length; i++)
                {
                    magicDoors[i].SetActive(false);
                }
            }
        }
    }
}
