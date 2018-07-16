using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    List<Enemy> enemies;

    public int maxEnemies = 10;
    public int spawnDelay = 30;
    private int framesSinceSpawn = 0;
    public GameObject enemy;

    public GameObject player;


	// Use this for initialization
	void Start () {
        enemies = new List<Enemy>();
	}
	
	// Update is called once per frame
	void Update () {
        framesSinceSpawn++;
		if(enemies.Count < maxEnemies && framesSinceSpawn >= spawnDelay)
        {
            framesSinceSpawn = 0;
            SpawnEnemy();
        }
	}

    private void SpawnEnemy()
    {
        Enemy e = Instantiate(enemy, this.transform.position, Quaternion.identity).GetComponent<Enemy>();
        e.player = player.transform;
        enemies.Add(e);
    }

    public void SendEnemy(int index)
    {
        enemies[index].Attack(true);
    }
}
