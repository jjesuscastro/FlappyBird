using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BirdController : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent onPipePassed;
    [HideInInspector]
    public UnityEvent onPipeHit;

    public float jumpForce = 200f;
    public float speed = 10f;
    public float maxY;

    Rigidbody2D rigidbody2d;
    bool isMoving;
    bool isDead;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0) && isMoving)
        {
            Flap();
        }
#endif

        if (Input.touchCount > 0 && isMoving)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Flap();
            }
        }
    }

    void FixedUpdate()
    {
        if (!isDead)
        {
            //Limit y position and y velocity
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Clamp(transform.localPosition.y, -10f, maxY), transform.localPosition.z);
            rigidbody2d.velocity = new Vector2(speed, Mathf.Clamp(rigidbody2d.velocity.y, -5, 5));

            if (isMoving)
            {
                //Tilt the bird down while falling
                if (rigidbody2d.velocity.y < -0.5)
                {
                    Quaternion target = Quaternion.Euler(0, 0, -45f);
                    transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 5f);
                }
                else if (rigidbody2d.velocity.y > 0)
                {
                    Quaternion target = Quaternion.Euler(0, 0, 35f);
                    transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 8f);
                }
            }
        }
    }

    void Flap()
    {
        rigidbody2d.velocity = new Vector2(0, 0);
        rigidbody2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    public void StartMoving()
    {
        rigidbody2d.gravityScale = 1.5f;
        isMoving = true;
    }

    public void StopMoving()
    {
        isMoving = false;
        isDead = true;
        rigidbody2d.velocity = new Vector2(0, 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Pipe"))
            if (onPipePassed != null)
                onPipePassed.Invoke();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Pipe") || other.transform.CompareTag("Floor"))
            if (onPipeHit != null)
                onPipeHit.Invoke();
    }
}
