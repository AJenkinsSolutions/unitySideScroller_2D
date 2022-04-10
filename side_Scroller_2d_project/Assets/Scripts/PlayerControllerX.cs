using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    
    private Rigidbody playerRb;
    private Animator playerAnimator;
    AudioSource playerAudio;
    
    // Reference: public Particle System effect
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public ParticleSystem dirtSplatterVFX;
    public ParticleSystem explosionParticleVFX;


    public bool spaceInput;
    public bool isOnGround = true;
    public float jumpHeight;

    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        // GET-Assign:  playerRigidBody components
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver)
        {
            spaceInput = Input.GetKeyDown(KeyCode.Space);

            if (spaceInput & isOnGround & !gameOver)
            {
                //Clean Up
                dirtSplatterVFX.Stop();
                isOnGround = false;

                // Mover 
                playerRb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);

                //Animation
                playerAnimator.SetTrigger("Jump_trig");
                // SFX
                playerAudio.PlayOneShot(jumpSound, 1f);


            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if(!gameOver)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isOnGround = true;
                dirtSplatterVFX.Play();

                Debug.Log("IsOnGround");
            }
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                // Clean up
                gameOver = true;
                dirtSplatterVFX.Stop();
                Debug.Log("GameOver");

                //  CrashAnimation
                playerAnimator.SetBool("Death_b", true);
                playerAnimator.SetInteger("DeathType_int", 1);

                //  Crash SFX-VFX
                playerAudio.PlayOneShot(crashSound, 1f);
                explosionParticleVFX.Play();


            }
        }
    }
}
