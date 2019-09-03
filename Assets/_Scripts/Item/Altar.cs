using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Altar : MonoBehaviour
{
    private  Orb _orb;
    public TMP_Text myText = null;
    private bool _orbPlaced = false;
    public GameObject OrbPoint = null;
    private Animator OrbPointAnim = null;
    public GameObject rockLeft = null;
    public GameObject rockRight = null;
    private Animator rockLeftAnim = null;
    private Animator rockRightAnim = null;

    private void Awake()
    {
        _orb = GameObject.Find("OrbLight").GetComponent<Orb>();
        OrbPointAnim = OrbPoint.GetComponent<Animator>();
        rockLeftAnim = rockLeft.GetComponent<Animator>();
        rockRightAnim = rockRight.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider myTrigger)
    {
        if (myTrigger.name == "OrbLight" && Input.GetKeyDown(KeyCode.E))
        {
            _orb.OrbToAltar();
            OrbPointAnim.SetTrigger("MoveOrb");
            rockLeftAnim.SetTrigger("RockMoveLeft");
            rockRightAnim.SetTrigger("RockMoveRight");
        }
        if (_orbPlaced)
        {
            myText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider myTrigger)
    {
        if (myTrigger.name == "OrbLight")
        {
            myText.gameObject.SetActive(true);
            myText.text = "Press E To place";
        }
        
    }

    private void OnTriggerExit(Collider myTrigger)
    {

        if (!_orbPlaced)
        {
            if (myTrigger.name == "OrbLight")
            {
                myText.gameObject.SetActive(false);

            }
        }
       
    }
}
