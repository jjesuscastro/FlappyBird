using System;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField]
    private float viewZone;
    [SerializeField]
    private float backgroundSize;
    [SerializeField]
    private float parallaxSpeed;

    [SerializeField]
    private Transform[] layers;
    
    private Transform cameraTransform;
    private int leftIndex;
    private int rightIndex;
    private float lastCameraX;

    private void Start()
    {
        if (Camera.main is null) {
            throw new NullReferenceException(nameof(Camera.main));
        }
        
        this.cameraTransform = Camera.main.transform;
        this.lastCameraX = this.cameraTransform.position.x;
        this.layers = new Transform[this.transform.childCount];

        for (int i = 0; i < this.transform.childCount; i++) this.layers[i] = this.transform.GetChild(i);

        this.leftIndex = 0;
        this.rightIndex = this.layers.Length - 1;
    }

    private void Update()
    {
        float deltaX = this.cameraTransform.position.x - this.lastCameraX;
        this.transform.position += Vector3.right * (deltaX * this.parallaxSpeed);
        this.lastCameraX = this.cameraTransform.position.x;

        if (this.cameraTransform.position.x < (this.layers[this.leftIndex].transform.position.x + this.viewZone))
            ScrollLeft();

        if (this.cameraTransform.position.x > (this.layers[this.rightIndex].transform.position.x - this.viewZone))
            ScrollRight();
    }

    private void ScrollLeft()
    {
        this.layers[this.rightIndex].position = new Vector3(this.layers[this.leftIndex].position.x - this.backgroundSize, this.layers[this.leftIndex].position.y, 0);
        this.leftIndex = this.rightIndex;
        this.rightIndex--;

        if (this.rightIndex < 0) this.rightIndex = this.layers.Length - 1;
    }

    private void ScrollRight()
    {
        this.layers[this.leftIndex].position = new Vector3(this.layers[this.rightIndex].position.x + this.backgroundSize, this.layers[this.leftIndex].position.y, 0);
        this.rightIndex = this.leftIndex;
        this.leftIndex++;

        if (this.leftIndex == this.layers.Length) this.leftIndex = 0;
    }
}
