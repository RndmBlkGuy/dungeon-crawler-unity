using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionAltar : MonoBehaviour
{

    public GameObject instructionImage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Activate the Main function when Player enter the trigger area
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            instructionImage.SetActive(true);
        }
    }
    // Deactivate the Main function when Player exit the trigger area
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            instructionImage.SetActive(false);
        }
    }
}
