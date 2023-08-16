using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CamSettings : MonoBehaviour
{
    CinemachineBrain CamBrain;
    // Start is called before the first frame update
    void Start()
    {
        CamBrain = GetComponent<CinemachineBrain>();
    }

    // Update is called once per frame
    void Update()
    {
        CamBrain.m_DefaultBlend.m_Time = 2f *  Time.deltaTime;
    }
}
