using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Orb : MonoBehaviour
{
    [SerializeField]
    Transform playerHoldPoint = null;
    bool inPlayerHand = false;
    [SerializeField]
    private TMP_Text myText= null;
    [SerializeField]
    Transform altarPoint = null;
    private bool inAltar = false;

    
    // Start is called before the first frame update

    private void Awake()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!inAltar)
        {
            if (inPlayerHand == true)
            {
                transform.position = playerHoldPoint.position;
            }
        }
        
    }

    private void OnTriggerStay(Collider myCollider)
    {
        if (!inAltar)
        {
            if (myCollider.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
            {

                this.gameObject.transform.parent = playerHoldPoint.transform;
                inPlayerHand = true;
                if (myText.gameObject.activeInHierarchy == true)
                {
                    myText.gameObject.SetActive(false);
                }
            }
        }
        
        
    }

    private void OnTriggerEnter(Collider myTrigger)
    {
        if (!inAltar)
        {
            if (inPlayerHand == true)
            {
                return;
            }
            if (myTrigger.CompareTag("Player"))
            {
                myText.gameObject.SetActive(true);
                myText.text = "Press E";
            }
        }
        
        
    }

    private void OnTriggerExit(Collider myTrigger)
    {
        if (!inAltar)
        {
            if (inPlayerHand == true)
            {
                return;
            }
            if (myTrigger.CompareTag("Player"))
            {
                myText.gameObject.SetActive(false);
            }
        }
        
    }

    public void OrbToAltar()
    {
        inPlayerHand = false;
        inAltar = true;
        this.gameObject.transform.parent = altarPoint.transform;
        transform.position = altarPoint.position;
    }
}
