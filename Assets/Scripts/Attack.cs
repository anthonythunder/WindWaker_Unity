using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator anim;
    CharacterController con;
    public float moveSpeed;
    //booleans
    public bool swordEquipped;//swordEquipped
    bool playerGrounded;
    public bool swordDrawn;

    
    // Start is called before the first frame update
    void Start()
    {
        swordEquipped = false;
        swordDrawn = false;
        con = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //attackAnimation();
        weaponEquipped(swordEquipped);
        playerGrounded = con.isGrounded;

        moveSpeed = transform.GetComponent<Movement>().movementSpeed;
        //Debug.Log(playerGrounded);
    }
    void attackAnimation()
    {
        if(Input.GetMouseButton(1) && swordEquipped == true  && swordDrawn == false)
        {
            anim.SetBool("DrawOut", true);                                                                  //Drawing out sword
            StartCoroutine(swordDrawnDelay());

        }
        if (Input.GetMouseButton(1)  && swordDrawn == true)
        {
            anim.SetBool("DrawOut", false);//Drawing in sword
            StartCoroutine(swordDrawnInDelay());
        }

        if (Input.GetMouseButton(0) && swordDrawn && swordEquipped && playerGrounded)
        {
            StartCoroutine(firstAttack());
        }


        if (swordDrawn == true )
        {
            anim.SetInteger("swordrunning", (int)moveSpeed);//running with sword
        }
        if(swordDrawn == true && moveSpeed > 7)
        {
            anim.SetLayerWeight(1, 0);
            if (moveSpeed ==0)
            {
                anim.SetLayerWeight(1, 1);
            }
        }

        



    }

    void weaponEquipped(bool swordOnTheBack)
    {
        GameObject link = GameObject.Find("Link Variant");
        GameObject masterHolding = link.transform.GetChild(10).gameObject;//OG Master Sword
        masterHolding.SetActive(swordOnTheBack);
    }
    IEnumerator swordDrawnDelay()
    {
        yield return new WaitForSeconds(1f);
        swordDrawn = true;//holding sword
    }
    IEnumerator swordDrawnInDelay()
    {
        yield return new WaitForSeconds(1.2f);
        swordDrawn = false;//holding sword
    }
    IEnumerator firstAttack()
    {
        anim.SetLayerWeight(1, 0);
        anim.SetBool("First Attack", true);
        yield return new WaitForSeconds(0.83f);
        anim.SetBool("First Attack", false);
        anim.SetLayerWeight(1, 1);
    }
}
