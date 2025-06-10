using UnityEngine;

public class BirdAnimator : MonoBehaviour
{
    [SerializeField]
    private float animationSpeed = 8f; // Frames per second
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite[] animationFrames; // Array of sprite frames
    private float timer;
    private int currentFrame;

    public void SetFrames(Skin skin) {
        this.animationFrames = new [] { skin.upSprite, skin.midSprite, skin.downSprite };
        
        this.currentFrame = 0;
    }

    private void Update()
    {
        if (this.animationFrames is { Length: > 0 })
        {
            this.timer += Time.deltaTime * this.animationSpeed;
            if (this.timer >= 1f)
            {
                this.timer = 0; // Reset the timer
                this.currentFrame++;

                if (this.currentFrame >= this.animationFrames.Length)
                {
                    this.currentFrame = 0; // Reset to the first frame if looping
                }

                this.spriteRenderer.sprite = this.animationFrames[this.currentFrame]; // Set the sprite
            }
        }
    }
}
