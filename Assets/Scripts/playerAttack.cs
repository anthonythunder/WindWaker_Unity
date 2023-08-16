using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public bool masterSword = false;

    public GameObject Sword;
    GameObject maSword;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Link = GameObject.Find("Link Variant");
    }

    // Update is called once per frame
    void Update()
    {
        if (maSword == null)
        {
            if (masterSword == true)
            {
                GameObject go = Instantiate(Sword, transform.position, transform.rotation) as GameObject;//Create Master sword at SwordPos and SwordRot
                go.transform.parent = GameObject.Find("Link Variant").transform;//Make master Sword as a child
                maSword = go;
            }
        }

        if (masterSword == false)
        {
            GameObject.Destroy(maSword);
        }
    }
}
