using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float xOffset;

    void Update()
    {
        Vector3 position = transform.position;
        position.x = player.position.x + xOffset;
        transform.position = position;
    }
}
