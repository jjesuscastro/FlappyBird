using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed;
    float height;
    bool moveUp;

    void Update()
    {
        if (transform.position.y > height)
            moveUp = false;
        else if (transform.position.y < -height)
            moveUp = true;

        if (moveUp)
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        else
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
    }

    public void SetHeight(float height)
    {
        this.height = height;
    }
}
