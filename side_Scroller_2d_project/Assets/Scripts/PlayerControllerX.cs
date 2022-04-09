using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    
    private Rigidbody playerRb;
    private Animator playerAnimator;

    public bool spaceInput;
    public bool isOnGround = true;
    public float jumpHeight;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        spaceInput = Input.GetKeyDown(KeyCode.Space);

        if (spaceInput & isOnGround & !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            playerAnimator.SetTrigger("Jump_trig");
            isOnGround = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            Debug.Log("IsOnGround");
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("GameOver");
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
        }
    }
}
