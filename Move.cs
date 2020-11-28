using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Camera cam;
    Vector2 mousePos;
    Vector2 movement;
    
    public GameObject deathMenuUI;

    private void Start()
    {
        rb.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
        
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        

    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == ("Enemy"))
        {
            SoundManager.PlaySound("Hurt");
            Destroy(gameObject);
            DeathMenu();
        }
    }
    void DeathMenu()
    {
        deathMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
