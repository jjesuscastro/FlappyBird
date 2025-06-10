using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float xOffset;

    private void Update()
    {
        Vector3 position = this.transform.position;
        position.x = this.player.position.x + this.xOffset;
        this.transform.position = position;
    }
}
