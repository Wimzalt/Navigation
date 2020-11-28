using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    public GameObject hook;
    public float hookSpeed;
    public Transform ShootPoint;
    GameObject target;
    public LineRenderer line;
    public SpringJoint2D spring;
    
    void Start()
    {
        line.enabled = false;
        spring.enabled = false;
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Release();
        }
        
        if(target != null)
        {
            line.SetPosition(0, ShootPoint.position);
            line.SetPosition(1, target.transform.position);
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(hook, ShootPoint.position, ShootPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(ShootPoint.up * hookSpeed, ForceMode2D.Impulse);
    }
    public void TargetHit(GameObject hit)
    {
        target = hit;
        line.enabled = true;
        spring.enabled = true;
        spring.connectedBody = target.GetComponent<Rigidbody2D>();

    }
    void Release()
    {
        line.enabled = false;
        spring.enabled = false;
        target = null;
    }
}
