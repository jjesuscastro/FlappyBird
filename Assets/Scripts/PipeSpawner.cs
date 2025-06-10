using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnTime;
    [SerializeField]
    private float spawnDistance;
    [SerializeField]
    private float spawnHeight;

    private bool isSpawning;
    private Camera mainCamera;
    private float timer;

    private void Awake()
    {
        this.mainCamera = Camera.main;
    }

    private void Update()
    {
        if (this.isSpawning)
        {
            this.timer += Time.deltaTime;

            if (this.timer >= this.spawnTime)
            {
                SpawnChild();

                this.timer = 0;
            }
        }
    }

    private void SpawnChild()
    {
        Transform pipe = this.transform.GetChild(0);
        Vector3 pipePosition = pipe.position;

        pipe.gameObject.SetActive(false);
        pipePosition.x = this.mainCamera.transform.position.x + this.spawnDistance;
        pipePosition.y = Random.Range(-this.spawnHeight, this.spawnHeight);
        pipePosition.z = this.spawnHeight;

        pipe.position = pipePosition;
        pipe.SetSiblingIndex(this.transform.childCount - 1);
        pipe.gameObject.SetActive(true);
    }

    public void StartSpawning()
    {
        this.isSpawning = true;
        this.timer = this.spawnTime;
    }

    public void StopSpawning()
    {
        this.isSpawning = false;
    }
}
