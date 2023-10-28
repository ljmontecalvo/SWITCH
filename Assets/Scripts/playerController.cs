using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed = 5;
    public float jumpForce = 10;

    [HideInInspector] public string color;

    private Rigidbody2D rb;
    private BoxCollider2D bc2d;
    private SpriteRenderer sp;
    [SerializeField] private LayerMask ground;

    public GameObject pauseMenu;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    private void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            gameObject.GetComponent<playerController>().enabled = false;
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && isGrounded())
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
    }

    private bool isGrounded()
    {
        float extraHeightTest = 0.1f;

        RaycastHit2D raycastHitMiddle = Physics2D.Raycast(bc2d.bounds.center, Vector2.down, bc2d.bounds.extents.y + extraHeightTest, ground);
        RaycastHit2D raycastHitLeft = Physics2D.Raycast(bc2d.bounds.min, Vector2.down, bc2d.bounds.extents.y + extraHeightTest, ground);
        RaycastHit2D raycastHitRight = Physics2D.Raycast(bc2d.bounds.max, Vector2.down, bc2d.bounds.extents.y + extraHeightTest, ground);

        return raycastHitMiddle.collider != null || raycastHitLeft.collider != null || raycastHitRight.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag(collision.gameObject.tag);

        if (collision.gameObject.tag == "red")
        {
            sp.color = new Color(1f, 0.3294118f, 0f, 1f);
            color = "red";

            collision.gameObject.GetComponent<button>().makeSound();

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].gameObject.GetComponent<Animator>().Play("buttonDown");
                buttons[i].gameObject.GetComponent<button>().pressedStatus = true;
                buttons[i].gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        else if (collision.gameObject.tag == "yellow")
        {
            sp.color = new Color(1f, 0.9048885f, 0f, 1f);
            color = "yellow";

            collision.gameObject.GetComponent<button>().makeSound();

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].gameObject.GetComponent<Animator>().Play("buttonDown");
                buttons[i].gameObject.GetComponent<button>().pressedStatus = true;
                buttons[i].gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        else if (collision.gameObject.tag == "green")
        {
            sp.color = new Color(0f, 1f, 0.4093699f, 1f);
            color = "green";

            collision.gameObject.GetComponent<button>().makeSound();

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].gameObject.GetComponent<Animator>().Play("buttonDown");
                buttons[i].gameObject.GetComponent<button>().pressedStatus = true;
                buttons[i].gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        else if (collision.gameObject.tag == "blue")
        {
            sp.color = new Color(0f, 0.8612397f, 1f, 1f);
            color = "blue";

            collision.gameObject.GetComponent<button>().makeSound();

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].gameObject.GetComponent<Animator>().Play("buttonDown");
                buttons[i].gameObject.GetComponent<button>().pressedStatus = true;
                buttons[i].gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}
