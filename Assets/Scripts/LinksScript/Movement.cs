  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Movement : MonoBehaviour
{
    public static bool masterSword = true;

    CharacterController controller;
    Climbing climbCs;
    public Transform cam;
    Animator anim;
    public Transform ThirdPersonCam;
    public bool canTarget;
//float targetingRange = 10;

    GameObject target;

    bool swordDrawn;
    public Vector3 Dir;
    public Vector3 direction;
    Vector3 climAtTopEndPos;
    Vector3 playerVelocity;

    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelociy;

    public int movementSpeed;
    public float JumpForce;
    float gravityValue = -9.81f;

    public  bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    //Ik
    [Range(0f, 1f)]
    public float _LeftdistanceToGround;

    [Range(0f, 1f)]
    public float _RightdistanceToGround;
    public LayerMask playerMask;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        climbCs = GetComponent<Climbing>();

    }

    // Update is called once per frame
    void Update()
    {
        
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        move();
    }
    public void move()
    {
        float xValue =Input.GetAxisRaw("Horizontal");
        float zValue = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(xValue, 0f, zValue).normalized;

        
        movementSpeed = 5 * (int)Dir.magnitude;
        anim.SetFloat("VelocityY",playerVelocity.y);
        /*if(playerVelocity.y < -6)
        {
            StartCoroutine(fallRecharge());
        }
        */
        
        Dir = direction;
        if  (isGrounded )
        {
            anim.SetBool("isGrounded",true);
            anim.SetFloat("moveMagnitude", direction.magnitude);
        }
        else
        { 
            anim.SetBool("isGrounded",false);
        }//run Animations

        anim.SetFloat("VelocityY", playerVelocity.y);

        if (direction.magnitude >= 0.1f )
        {
            
            float TargetAngle = Mathf.Atan2(Dir.x, Dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref turnSmoothVelociy, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, Angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, TargetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * movementSpeed * Time.deltaTime);
            
        }
        ///Gravity
        playerVelocity.y += 2 * gravityValue * Time.deltaTime;

        //?Jump
        if (Input.GetButtonUp("Jump") && isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(JumpForce * -2 * gravityValue);    
        }

            controller.Move(playerVelocity * Time.deltaTime);
        ///Climb

    }
    private void OnAnimatorIK(int layerIndex)
    {
        if (anim)
       
            anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot,anim.GetFloat("IKLeftFootWeight"));
            anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot,anim.GetFloat("IKLeftFootWeight"));

            anim.SetIKPositionWeight(AvatarIKGoal.RightFoot,anim.GetFloat("IKRightFootWeight"));
            anim.SetIKRotationWeight(AvatarIKGoal.RightFoot,anim.GetFloat("IKRightFootWeight"));

            //Left Foot
            RaycastHit hit;
            Ray ray = new Ray(anim.GetIKPosition(AvatarIKGoal.LeftFoot) + Vector3.up,Vector3.down);
            
            if(Physics.Raycast(ray, out hit,_LeftdistanceToGround + 1f,playerMask))
            {
                if(hit.transform.tag == "ground")
                {
                    Vector3 footPos = hit.point;
                    footPos.y += _LeftdistanceToGround;
                    anim.SetIKPosition(AvatarIKGoal.LeftFoot,footPos);
                    anim.SetIKRotation(AvatarIKGoal.LeftFoot,Quaternion.LookRotation(transform.forward,hit.normal));
                }
            }


            //Right Foot
            ray = new Ray(anim.GetIKPosition(AvatarIKGoal.RightFoot) + Vector3.up, Vector3.down);

            if (Physics.Raycast(ray, out hit, _RightdistanceToGround + 1f, playerMask))
            {
                if (hit.transform.tag == "ground")
                {
                    Vector3 footPos = hit.point;
                    footPos.y += _RightdistanceToGround;
                    anim.SetIKPosition(AvatarIKGoal.RightFoot, footPos);
                    anim.SetIKRotation(AvatarIKGoal.RightFoot, Quaternion.LookRotation(transform.forward, hit.normal));
                }
            }
        } 



}


