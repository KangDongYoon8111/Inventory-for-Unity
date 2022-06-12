using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f;

    private InputController playerInput;
    private Rigidbody2D playerRigidbody;
    private Animator playerAnimator;
    private SpriteRenderer playerRenderer;

    void Start()
    {
        playerInput = GetComponent<InputController>();
        playerRigidbody = GetComponentInChildren<Rigidbody2D>();
        playerAnimator = GetComponentInChildren<Animator>();
        playerRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Moveing();
        Anim();
    }

    private void Moveing()
    {
        Vector2 move = playerRigidbody.velocity;
        move.x = playerInput.move * moveSpeed;
        playerRigidbody.velocity = move;
    }

    private void Anim()
    {
        switch (playerInput.move)
        {
            case 0:
                playerAnimator.SetBool("isWalk", false);
                break;
            case 1:
                playerRenderer.flipX = false;
                playerAnimator.SetBool("isWalk", true);
                break;
            case -1:
                playerRenderer.flipX = true;
                playerAnimator.SetBool("isWalk", true);
                break;
        }
    }
}
