using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    GrapplingGun gun;

    // Start is called before the first frame update
    void Start()
    {
        gun = GameObject.FindGameObjectWithTag("Player").GetComponent<GrapplingGun>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "moon")
        {
            gun.TargetHit(collision.gameObject);
            Destroy(gameObject);
        }

        
    }
}
