using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    public string itemName;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, collectGrab, cam;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

   
    
    // Start is called before the first frame update
    void Start()
    {
       
        rb.isKinematic = false;
        coll.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Check if player is in range and "E" is pressed
        Vector3 distanceToPlayer = player.position - transform.position;
        if (distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E)) PickUp();

        //Drop if equipped and "Q" is pressed
        //if (Input.GetKeyDown(KeyCode.Q)) Drop();
    }

    private void PickUp()
    {
        

        //Make weapon a child of the camera and move it to default position
        transform.SetParent(collectGrab);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        //Make Rigidbody kinematic and BoxCollider a trigger
        rb.isKinematic = true;
        coll.isTrigger = true;

    }

    private void Drop()
    {
       
        //Set parent to null
        transform.SetParent(null);

        //Make Rigidbody not kinematic and BoxCollider normal
        rb.isKinematic = false;
        coll.isTrigger = false;

        //Gun carries momentum of player
        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        //AddForce
        rb.AddForce(cam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(cam.up * dropUpwardForce, ForceMode.Impulse);
        //Add random rotation
        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 10);

       
    }
}
