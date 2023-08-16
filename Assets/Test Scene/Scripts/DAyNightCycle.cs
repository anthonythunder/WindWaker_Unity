using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DAyNightCycle : MonoBehaviour
{
    [Range(0f, 2f)]
    public float timeChangeRate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.rotation *= Quaternion.Euler(timeChangeRate * Time.deltaTime,0f,0f);
    }
}
