using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandDoorCheckPoint : MonoBehaviour
{

    public GameObject GDMessage;
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
            GDMessage.SetActive(true);
        }
    }
    // Deactivate the Main function when Player exit the trigger area
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GDMessage.SetActive(false);
        }
    }
}
