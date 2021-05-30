using UnityEngine;

public class FishManager : MonoBehaviour
{
    public enum Emotion
    {
        anger,
        fear,
        sadness,
        joy,
        neutral
    }

    Rigidbody2D rb;
    SpriteRenderer sr;
    public float speed;
    public Animator animator;
    public Emotion fishEmotion;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        fishEmotion = Emotion.neutral;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (fishEmotion)
        {
            case Emotion.sadness:
                animator.SetBool("IsSad", true);
                break;
            case Emotion.fear:
                animator.SetBool("IsFear", true);
                break;
            case Emotion.anger:
                animator.SetBool("IsAnger", true);
                break;
            case Emotion.joy:
                animator.SetBool("IsSad", true);
                break;
            default:
                animator.SetBool("IsNeutral", true);
                break;
        }

        if (Input.GetKey(KeyCode.P))
        {
            animator.SetBool("IsSad", true);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetBool("Front", !animator.GetBool("Front"));
        }

        rb.velocity = new Vector2(speed*Input.GetAxis("Horizontal"), speed*Input.GetAxis("Vertical"));
        if(rb.velocity.x > 0.2)
        {
            sr.flipX = true;
        }
        else if(rb.velocity.x < -0.2)
        {
            sr.flipX = false;
        }

        if(Input.GetAxis("Vertical") < 0.1)
        {
            
            if ((int)(Time.realtimeSinceStartup % 2) == 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 0.2f);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - 0.2f);
            }
        }

        // animation
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        // emotions



    }
}
