using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Vector3 direction = Vector3.zero; //bad
    public float speed = .1f;

    public float lifeTime = 300f;
    public float timeAlive = 0f;

    // Use this for initialization
    void Start()
    {
        print("BulletStartPosition" + transform.position);
    }

    public void SetDirection(Vector3 _direction)
    {
        direction = _direction.normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (direction != Vector3.zero)
        {
            transform.Translate(direction);
        }
        timeAlive++;
        if(timeAlive > lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
