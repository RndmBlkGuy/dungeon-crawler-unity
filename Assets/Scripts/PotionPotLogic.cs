using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionPotLogic : MonoBehaviour
{


    public GameObject GreenPotionPart;
    public GameObject RedPotionPart;
    public GameObject YellowPotionPart;
    public GameObject BluePotionPart;
    public GameObject PurplePotionPart;
    public GameObject OrangePotionPart;

    public GameObject ActivePotion;

    public GameObject PMmessage;

    public GameObject potionSolution;


    // Start is called before the first frame update
    void Start()
    {

        //cycle through children of game object and disable the render component
        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<Renderer>().enabled = false;
        }

        //activate the designated potion for this pot.
        ActivePotion.gameObject.GetComponent<Renderer>().enabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    void OnTriggerStay(Collider col)
    {

        Debug.Log("GameObject Hit: " + col.tag);
        if(col.gameObject.tag == "Collectable")
        {
            if (col.gameObject.GetComponent<Collectable>().holding)
            {
                PMmessage.SetActive(true);
                Debug.Log("Is holding");
                if ((Input.GetKeyDown(KeyCode.Q)) && (col.gameObject.tag == "Collectable") && (col.gameObject.GetComponent<Collectable>().holding))
                {
                    Debug.Log("Calling to mix potion");
                    MixPotions(col.gameObject.name);
                    PMmessage.SetActive(false);
                }
                
            }
        }
    }

    // Deactivate the Main function when Player exit the trigger area
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PMmessage.SetActive(false);
        }
    }

    void MixPotions(string name)
    {
        if(name == "BluePotion")
        {
            Debug.Log("Blue potion identified");
            if ((ActivePotion == YellowPotionPart))
            {
                Debug.Log("Changed to green");
                YellowPotionPart.gameObject.GetComponent<Renderer>().enabled = false;
                greenMix();
            }

            else if ((ActivePotion == GreenPotionPart))
            {
                Debug.Log("Changed to blue");
                GreenPotionPart.gameObject.GetComponent<Renderer>().enabled = false;
                blueMix();
            }

        }
       
    }

    void checkSolution()
    {

    }

    void greenMix()
    {
        ActivePotion = GreenPotionPart;
        GreenPotionPart.gameObject.GetComponent<Renderer>().enabled = true;
    }
    void redMix()
    {
        ActivePotion = RedPotionPart;
    }
    void yellowMix()
    {
        ActivePotion = YellowPotionPart;
    }
    void blueMix()
    {
        ActivePotion = BluePotionPart;
        BluePotionPart.gameObject.GetComponent<Renderer>().enabled = true;
    }
    void purpleMix()
    {
        ActivePotion = PurplePotionPart;
    }
    void orangeMix()
    {
        ActivePotion = OrangePotionPart;
    }
}
