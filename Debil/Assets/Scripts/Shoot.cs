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

    private void ShootBullet()
    {
        Bullet b = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity).GetComponent<Bullet>();

        Vector3 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y));
        target.z = 1;
        print("mouse: " + target);
        print("position: " + transform.position);
        Vector3 direction = new Vector3(transform.position.x + target.x, transform.position.y - target.y, transform.position.z - target.z);//WHY ADD X, BUT SUBTRACT Y. WHYYY
        print("direction: " + direction);
        b.SetDirection(direction);

        /*Vector3 mousePos = Input.mousePosition;
        mousePos.z = 1f;
        print("mousePos: " + mousePos);
        print("position: " + transform.TransformPoint(transform.position));//converts to world space
        Vector3 direction = mousePos - transform.TransformPoint(transform.position);
        print(direction);
        b.SetDirection(direction);

        Vector3 objectPos = Camera.main.WorldToScreenPoint(mousePos);
        print("objectPos: " + objectPos);
        direction = objectPos - transform.position;
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        print(angle);


        float xPos = transform.position.x + (Mathf.Cos(angle * Mathf.Deg2Rad));
        float yPos = transform.position.y + (Mathf.Sin(angle * Mathf.Deg2Rad));*/


    }
}
