using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;

    Vector3 velocity;
    bool isGrounded;
    bool isWalking;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float jumpHeight = 3f;

    public AudioSource walkingAudio;
    public AudioSource collectTone;

    public HashSet<string> keys;

    public GameMaster gm;

    public Transform CollectableGrab;

    void Start()
    {
        keys = new HashSet<string>();
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (move != Vector3.zero)
        {
            isWalking = true;
        }

        else
        {
            isWalking = false;
        }

        Debug.Log("isGrounded" + isGrounded);
        Debug.Log("isWalking" + isWalking);

        if (isGrounded && isWalking)
        {
            Debug.Log("audio is playing");
            if(!walkingAudio.isPlaying)
                walkingAudio.Play();
        }
        else
        {
            walkingAudio.Stop();
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    //OnTriggerEnter is called whenever this object overlaps with a trigger collider.
    void OnTriggerEnter(Collider other)
    {
        //Check the provided Collider parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("Collectable"))
        {
            //gm.keys.Add(other.gameObject.name);

            collectTone.Play();
            //keys.Add(other.gameObject.getComponent<CollectableRotate>.keyName);
            other.gameObject.SetActive(false);  
            
            
        }

        if (other.gameObject.CompareTag("Goal"))
        {
            SceneManager.LoadScene(1);
        }

        
    }

    public bool playerHasKey(string key)
    {
        return keys.Contains(key);
    }
}
