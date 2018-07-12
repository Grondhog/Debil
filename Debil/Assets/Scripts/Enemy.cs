using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MovingCharacter {

    public Transform player;

    private NavMeshAgent nmAgent;

	// Use this for initialization
	void Start () {
        nmAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        nmAgent.SetDestination(player.position);
	}
}
