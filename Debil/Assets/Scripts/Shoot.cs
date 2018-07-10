using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject bullet;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        Vector2 fromMouseToPlayer = new Vector2(transform.position.x, transform.position.y) - mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
    }

    private void OnDrawGizmos()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Gizmos.DrawSphere(mousePosition, 1f);
    }

    private void ShootBullet()
    {
        Bullet b = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity).GetComponent<Bullet>();
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(mousePosition);
        //transform.LookAt(mousePosition); //is causing the object to move towards the mouse for some reason
        Vector2 fromMouseToPlayer =  mousePosition - new Vector2(transform.position.x, transform.position.y) ;
        //Debug.Log(rb.velocity.magnitude);
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("fromMouseToPlayer: " + fromMouseToPlayer);
            b.SetDirection(fromMouseToPlayer);
            //rb.AddForce(fromMouseToPlayer * speed);
            //ShootBullet(fromMouseToPlayer);
        }
    }
}
