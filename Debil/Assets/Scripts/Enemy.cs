using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MovingCharacter {

    public Transform player;

    private NavMeshAgent nmAgent;

    public float minDistance = 10f;
    private float curMinDistance;

    private int angle = 0;
    private int angleDelay = 10;
    private int count = 0;


    // Use this for initialization
    void Start () {
        nmAgent = GetComponent<NavMeshAgent>();
        curMinDistance = minDistance;
        nmAgent.SetDestination(player.position);
        nmAgent.speed = 100;
    }
	
	// Update is called once per frame
	void Update () {
        count++;
        if(count > angleDelay)
        {
            angle = (angle + 1) % 360;
            count = 0;
        }
        //print(player.position);
        
        //SetDistanceMinDistanceFromTarget();
        if(nmAgent.remainingDistance > curMinDistance)
        {
            nmAgent.isStopped = false;
            nmAgent.SetDestination(player.position);
        }
        else
        {
            nmAgent.isStopped = true;
            SetDistanceMinDistanceFromTarget();
        }
	}

    public void Attack(bool attack)
    {
        if (attack)
            curMinDistance = 1f;    
        else
            curMinDistance = minDistance;
    }

    public void TakeDamage(int damage)
    {
        curHealth -= damage;
    }

    private void OnDrawGizmos()
    {
        float x = (Mathf.Sin(Mathf.Deg2Rad * angle) * curMinDistance) + player.position.x;
        float y = (Mathf.Cos(Mathf.Deg2Rad * angle) * curMinDistance) + player.position.z;
        Gizmos.DrawCube(new Vector3(x, 0, y), new Vector3(1, 1 , 1));
    }

    private void SetDistanceMinDistanceFromTarget()
    {
        float x = (Mathf.Sin(Mathf.Deg2Rad * angle) * curMinDistance) + player.position.x;
        float y = (Mathf.Cos(Mathf.Deg2Rad * angle) * curMinDistance) + player.position.z;
        //print("Changing destination: " + x + ", " + y);
        nmAgent.SetDestination(new Vector3(x, 0, y));
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Enemy Collision " + collision.gameObject.tag);
        if(collision.gameObject.tag == "Bullet")
        {
            Bullet b = collision.gameObject.GetComponent<Bullet>();
            curHealth -= b.damage;
            Destroy(b);//TODO enemy shouldn't destroy the bullet, bullet should do this
        }
    }
}
