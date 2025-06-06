using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BirdController : MonoBehaviour {
    [HideInInspector]
    public UnityEvent onFlap;
    [HideInInspector]
    public UnityEvent onPipePassed;
    [HideInInspector]
    public UnityEvent onPipeHit;
    
    [SerializeField]
    private float jumpForce = 200f;
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float maxY;

    [SerializeField]
    private BirdAnimator birdAnimator;
    [SerializeField]
    private Rigidbody2D rigidbody2d;
    
    private bool isMoving;
    private bool isDead;
    
    public bool IsDead => this.isDead;

    private void FixedUpdate()
    {
        if (!this.isDead)
        {
            //Limit y position and y velocity
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, Mathf.Clamp(this.transform.localPosition.y, -10f, this.maxY), this.transform.localPosition.z);
            this.rigidbody2d.velocity = new Vector2(this.speed, Mathf.Clamp(this.rigidbody2d.velocity.y, -5, 5));

            if (this.isMoving)
            {
                //Tilt the bird down while falling
                if (this.rigidbody2d.velocity.y < -0.5)
                {
                    Quaternion target = Quaternion.Euler(0, 0, -45f);
                    this.transform.rotation = Quaternion.Slerp(this.transform.rotation, target, Time.deltaTime * 5f);
                }
                else if (this.rigidbody2d.velocity.y > 0)
                {
                    Quaternion target = Quaternion.Euler(0, 0, 35f);
                    this.transform.rotation = Quaternion.Slerp(this.transform.rotation, target, Time.deltaTime * 8f);
                }
            }
        }
    }

    public void Flap() {
        if (!this.isMoving)
            return;
        
        this.rigidbody2d.velocity = new Vector2(0, 0);
        this.rigidbody2d.AddForce(new Vector2(0, this.jumpForce), ForceMode2D.Impulse);

        this.onFlap?.Invoke();
    }

    public void StartMoving() {
        this.rigidbody2d.freezeRotation = false;
        this.rigidbody2d.gravityScale = 1.5f;
        this.isMoving = true;
    }

    public void StopMoving()
    {
        this.isMoving = false;
        this.isDead = true;
        this.rigidbody2d.velocity = new Vector2(0, 0);
        this.rigidbody2d.freezeRotation = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Pipe")) {
            this.onPipePassed?.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Pipe") || other.transform.CompareTag("Floor")) {
            this.onPipeHit?.Invoke();
        }
    }
}
