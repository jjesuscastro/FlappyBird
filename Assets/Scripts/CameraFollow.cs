using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float xOffset;

    private void Update()
    {
        Vector3 position = this.transform.position;
        position.x = this.player.position.x + this.xOffset;
        this.transform.position = position;
    }
}
