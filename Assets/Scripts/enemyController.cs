using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public float maximumLeftPatrol;
    public float maximumRightPatrol;

    public float patrolSpeed;
    public float chaseSpeed;

    public string color;

    public LayerMask playerLayer;

    private Rigidbody2D rb;
    private GameObject player;
    private GameObject levelLoader;
    private BoxCollider2D bc2d;

    public ParticleSystem red;
    public ParticleSystem yellow;
    public ParticleSystem green;
    public ParticleSystem blue;

    public Vector2 destination;

    private bool playerIsInZone = false;
    private bool dieAnimHasPlayed = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        levelLoader = GameObject.FindGameObjectWithTag("Level Loader");
        bc2d = GetComponent<BoxCollider2D>();
        CreateNewDestination();
    }

    private void Update()
    {
        if (transform.position.x == destination.x && !playerIsInZone)
        {
            CreateNewDestination();
        } else if (transform.position.x != destination.x && !playerIsInZone) {
            MoveToDestination();
        }

        if (playerIsInZone)
        {
            MoveTowardsPlayer();
        }

        if (player.GetComponent<playerController>().color != color)
        {
            LookForPlayer();
            CheckForAttackPlayer();
        }
    }

    /*private bool objectCheck()
    {
        
    }*/

    private void CreateNewDestination()
    {
        float x = Random.Range(maximumLeftPatrol, maximumRightPatrol);
        float y = transform.position.y;

        destination = new Vector2(x, y);
    }

    private void MoveToDestination()
    {
        float step = patrolSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, destination, step);
    }

    private void LookForPlayer()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        float viewDistance = 5f;

        if (distance < viewDistance)
        {
            playerIsInZone = true;
        } else
        {
            playerIsInZone = false;
        }
    }

    private void MoveTowardsPlayer()
    {
       
    }

    private void CheckForAttackPlayer()
    {
        
    }

    private IEnumerator dieAnim()
    {
        player.GetComponent<BoxCollider2D>().enabled = false;

        if (player.GetComponent<playerController>().color == "red")
        {
            GetComponent<AudioSource>().Play();
            player.GetComponent<SpriteRenderer>().enabled = false;
            player.GetComponent<playerController>().enabled = false;
            GetComponent<enemyController>().enabled = false;
            red.Play();
        } else if (player.GetComponent<playerController>().color == "yellow")
        {
            GetComponent<AudioSource>().Play();
            player.GetComponent<SpriteRenderer>().enabled = false;
            player.GetComponent<playerController>().enabled = false;
            GetComponent<enemyController>().enabled = false;
            yellow.Play();
        } else if (player.GetComponent<playerController>().color == "green")
        {
            GetComponent<AudioSource>().Play();
            player.GetComponent<SpriteRenderer>().enabled = false;
            player.GetComponent<playerController>().enabled = false;
            GetComponent<enemyController>().enabled = false;
            green.Play();
        } else if (player.GetComponent<playerController>().color == "blue")
        {
            GetComponent<AudioSource>().Play();
            player.GetComponent<SpriteRenderer>().enabled = false;
            player.GetComponent<playerController>().enabled = false;
            GetComponent<enemyController>().enabled = false;
            blue.Play();
        }
        yield return new WaitForSeconds(1.7f);
        levelLoader.GetComponent<levelLoader>().ReloadScene();
    }
}