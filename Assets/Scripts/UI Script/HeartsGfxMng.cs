using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsGfxMng : MonoBehaviour
{
    public Sprite FullHeart;
    public Sprite ThreeFourthHeart;
    public Sprite HalfHeart;
    public Sprite OneFourthHeart;

    public GameObject HeartsInfo;
    Health Health;

    public Image H1;
    public Image H2;
    public Image H3;
    void Start()
    {
        Health = HeartsInfo.GetComponent<Health>();
    }
    void Update()
    {
        switch (Health.health)
        {
            case 1:
                H3.enabled = false;
                H2.enabled = false;
                H1.sprite = OneFourthHeart;
                break;
            case 2:
                H3.enabled = false;
                H2.enabled = false;
                H1.sprite = HalfHeart;
                break ;
            case 3:
                H3.enabled = false;
                H2.enabled = false;
                H1.sprite = ThreeFourthHeart;
                break;
            case 4:
                H3.enabled = false;
                H2.enabled = false;
                H1.sprite = FullHeart;
                break;
            case 5:
                H3.enabled = false;
                if(H2.enabled == false) H2.enabled = true;
                H2.sprite = OneFourthHeart;
                H1.sprite = FullHeart;
                break;
            case 6:
                H3.enabled = false;
                if (H2.enabled == false) H2.enabled = true;
                H2.sprite = HalfHeart;
                H1.sprite = FullHeart;
                break;
            case 7:
                H3.enabled = false;
                if (H2.enabled == false) H2.enabled = true;
                H2.sprite = ThreeFourthHeart;
                H1.sprite = FullHeart;
                break;
            case 8:
                H3.enabled = false;
                if (H2.enabled == false) H2.enabled = true;
                H2.sprite = FullHeart;
                H1.sprite = FullHeart;
                break;
            case 9:
                if(H3.enabled == false) H3.enabled = true;
                H3.sprite = OneFourthHeart;
                if (H2.enabled == false) H2.enabled = true;
                H2.sprite = FullHeart;
                H1.sprite = FullHeart;
                break;
            case 10:
                if (H3.enabled == false) H3.enabled = true;
                H3.sprite = HalfHeart;
                if (H2.enabled == false) H2.enabled = true;
                H2.sprite = FullHeart;
                H1.sprite = FullHeart;
                break;
            case 11:
                if (H3.enabled == false) H3.enabled = true;
                H3.sprite = ThreeFourthHeart;
                if (H2.enabled == false) H2.enabled = true;
                H2.sprite = FullHeart;
                H1.sprite = FullHeart;
                break;
            case 12:
                if (H3.enabled == false) H3.enabled = true;
                H3.sprite = FullHeart;
                if (H2.enabled == false) H2.enabled = true;
                H2.sprite = FullHeart;
                H1.sprite = FullHeart;
                break;

        }
    }
}
