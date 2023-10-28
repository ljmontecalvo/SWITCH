using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    [HideInInspector] public bool pressedStatus;

    public AudioSource source;

    public void makeSound()
    {
        source.Play();
    }
}
