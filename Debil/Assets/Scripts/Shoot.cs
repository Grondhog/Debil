using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject bullet;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
    }

    private void OnDrawGizmos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 mousePosition = hit.point;
            //Debug.Log("mousePosition: " + mousePosition);
            Vector3 fromMouseToPlayer = mousePosition - new Vector3(transform.position.x, transform.position.y, transform.position.z);
            //print("FromMouseToPlayer: " + fromMouseToPlayer);
            Gizmos.DrawSphere(mousePosition, 1f);
            Gizmos.DrawLine(transform.position, fromMouseToPlayer);
        }

    }

    private void ShootBullet()
    {
        Bullet b = Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<Bullet>();
        //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //transform.LookAt(mousePosition); //is causing the object to move towards the mouse for some reason

        //Debug.Log(rb.velocity.magnitude);
        
            //Debug.Log("fromMouseToPlayer: " + fromMouseToPlayer);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 mousePosition = hit.point;
                Debug.Log("mousePosition: " + mousePosition);
                print("playerPosition: " + transform.position);
                Vector3 fromMouseToPlayer = mousePosition - new Vector3(transform.position.x, transform.position.y, transform.position.z);
                print("FromMouseToPlayer: " + fromMouseToPlayer);
                fromMouseToPlayer.y = 0;
                b.SetDirection(fromMouseToPlayer);
            }


            //rb.AddForce(fromMouseToPlayer * speed);
            //ShootBullet(fromMouseToPlayer);
        
    }
}
