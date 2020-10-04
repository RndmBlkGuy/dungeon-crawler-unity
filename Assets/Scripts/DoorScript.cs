using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    //public AudioSource doorOpen;

    // adding objectives if this door needs to be open.

    //public GameMaster gm;
    public string doorKey;
    public Animator anim;

    void Awake()
    {
        anim.SetBool("OpenCloseState", false);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Activate the Main function when Player enter the trigger area
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (doorKey == "")
            {
                Debug.Log("Door has no key");
                anim.SetBool("OpenCloseState", true);
                //doorOpen.Play();
            }
            
            else
            {
                //if (gm.keys.Contains(doorKey))
                //{
                  //  Debug.Log("Player has the " + doorKey);
                    //anim.SetBool("OpenCloseState", true);
                //}
                //else
                //{
                  //  Debug.Log("Player has no key");
               // }

            } 

        }
    }
    // Deactivate the Main function when Player exit the trigger area
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("OpenCloseState", false);
        }
    }
}
