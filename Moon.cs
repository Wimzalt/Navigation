using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public GameObject deathMenuUI;

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
