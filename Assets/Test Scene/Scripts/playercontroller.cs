using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    CharacterController con;
    public Transform Cam;
    Animator anim;
    public float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        con = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float xValue = Input.GetAxis("Horizontal") ;
        float zValue = Input.GetAxis("Vertical") ;

        Vector3 move = new Vector3(xValue,0f,zValue);

        if (move.magnitude >= 0.1f)
        {

            float rot = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + Cam.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0f,rot,0f) ;
            Vector3 moveDir = Quaternion.Euler(0f, rot, 0f) * Vector3.forward;
            con.Move(moveDir * movementSpeed * Time.deltaTime);
        }
        anim.SetFloat("moveValue", move.magnitude);
    }
}
