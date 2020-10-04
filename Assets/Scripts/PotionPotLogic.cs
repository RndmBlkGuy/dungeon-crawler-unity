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
}
