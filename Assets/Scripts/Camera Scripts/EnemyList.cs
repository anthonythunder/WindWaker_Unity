using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class EnemyList : MonoBehaviour
{
    public CinemachineTargetGroup.Target  target;
    CinemachineTargetGroup ctg;
    
    public List<Transform> Enemies;
    public GameObject[] allEnemies;

    public Transform player;

    float dis;

    public LayerMask targetMask;
    public float targetDis;
    public float PlayerEnemDis;

    public bool DisableTcg;
    // Start is called before the first frame update
    void Start()
    {
        ctg = GetComponent<CinemachineTargetGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        AddEnemiestoList();
    }
    void AddEnemiestoList()
    {
        

        Enemies = new List<Transform>();

        // Add All Enemies to the List

        foreach (GameObject o in allEnemies)
        {
            dis = Vector3.Distance(player.position, o.transform.position);
            if (dis <= 17 )
            {
                Enemies.Add(o.transform);

            }
            
        } 
        if (Enemies.Count <= 0)
        {
            return;
        }
        //CinemachineTargetGroup Array Establishment
        CinemachineTargetGroup.Target[] target = new CinemachineTargetGroup.Target[Enemies.Count];
        // Add CinemachineTargetGroup Array targets to Ctg Component targets 
        for (int x = 0; x < Enemies.Count; x++)
        {
            target[x] = new CinemachineTargetGroup.Target() { target = Enemies[x], weight = 1f, radius = .8f };
            ctg.m_Targets = target;  //Assign the created list to the target object group.
        }
        // if current player is not With in 15 units then loot at player
        Vector3 targetPos = target[target.Length - 1].target.transform.position;
        PlayerEnemDis = Vector3.Distance(player.position, targetPos);
        if (PlayerEnemDis > 15)
        {
            ctg.RemoveMember(target[target.Length - 1].target);
            DisableTcg = true;
        }
        else
        {
            DisableTcg = false;
        }
        
    }

}
