using UnityEngine;

public class Pipes : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
    private float height;
    private bool moveUp;

    private void OnEnable() {
        this.height = this.transform.position.z;

        Vector2 position = new Vector2(this.transform.position.x, this.transform.position.y);
        this.transform.position = position;
    }

    private void Update()
    {
        if (this.transform.position.y > this.height)
            this.moveUp = false;
        else if (this.transform.position.y < -this.height) this.moveUp = true;

        if (this.moveUp)
            this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + this.speed * Time.deltaTime);
        else
            this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - this.speed * Time.deltaTime);
    }

    public void SetHeight(float height)
    {
        this.height = height;
    }
}
