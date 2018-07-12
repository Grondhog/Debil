using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MovingCharacter
{
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var y = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(new Vector3(x, 0, y), Space.World);
    }
}
