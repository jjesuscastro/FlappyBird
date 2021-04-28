using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public float spawnTime;
    public float spawnDistance;
    public float spawnHeight;

    bool isSpawning;
    Camera mainCamera;
    float timer;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (isSpawning)
        {
            timer += Time.deltaTime;

            if (timer >= spawnTime)
            {
                SpawnChild();

                timer = 0;
            }
        }
    }

    void SpawnChild()
    {
        Transform pipe = transform.GetChild(0);
        Pipes pipes = pipe.GetComponent<Pipes>();
        Vector2 pipePosition = pipe.position;

        pipePosition.x = mainCamera.transform.position.x + spawnDistance;
        pipePosition.y = Random.Range(-spawnHeight, spawnHeight);

        pipes.SetHeight(spawnHeight);

        pipe.position = pipePosition;
        pipe.SetSiblingIndex(transform.childCount - 1);
        pipe.gameObject.SetActive(true);
    }

    public void StartSpawning()
    {
        isSpawning = true;
        timer = spawnTime;
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }
}
