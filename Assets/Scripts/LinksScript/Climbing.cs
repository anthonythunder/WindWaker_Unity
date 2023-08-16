using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour
{
    CharacterController con;
    Movement moveCs;
    Animator anim;

    public float climbSpeed;

    //public bool isClimbing;
    public bool canClimb;
    //public bool ClimbtopTriggered;

    //public Vector3 climbMovement;
    //ClimbingObstackle Check
    //public GameObject ClimbingObstackle;
    //float ClimbingObstackleRadius = .4f;
    //public LayerMask ClimbingObstackleMask;
    //public LayerMask ClimbTopTriggerMask;
    // Start is called before the first frame update
    void Start()
    {
        con = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        moveCs = GetComponent<Movement>();
        canClimb = false;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ladder")
        {
            moveCs.enabled = false;
            canClimb = !canClimb;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Ladder")
        {
            moveCs.enabled = true;
            canClimb = !canClimb;
        }
    }
    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isClimbing", canClimb);
        float yValue = Input.GetAxisRaw("Vertical");

        if (canClimb == true && yValue >= 0.1f)
        {
            con.transform.position += Vector3.up / climbSpeed * Time.deltaTime;
        }
        if (canClimb == true && yValue <= -0.1f)
        {
            con.transform.position += Vector3.down / climbSpeed * Time.deltaTime;
        }
        anim.SetFloat("ClimbValue", yValue);
    }

}
