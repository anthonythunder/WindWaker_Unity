using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Cinemachine.Utility;

public class CamChanging : MonoBehaviour
{
    CinemachineFreeLook tppCam;
    public Transform player;
    public Transform ctgCam;
    public bool canTarget;
    public bool DisableCtg;
    public bool isTargeting;
    // Start is called before the first frame update
    void Start()
    {
        tppCam = GetComponent<CinemachineFreeLook>();
        tppCam.LookAt = player;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        DisableCtg = ctgCam.GetComponent<EnemyList>().DisableTcg;
        if (Input.GetKeyUp(KeyCode.Z) && DisableCtg == false && isTargeting == false)
        {
            tppCam.LookAt = ctgCam;
            isTargeting = true;
        }
        else if (Input.GetKeyUp(KeyCode.Z) && isTargeting == true || DisableCtg == true)
        {
            tppCam.LookAt = player;
            isTargeting = false;
        }
        
        
    }
  
}
