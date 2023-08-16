using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public Animator anim;

    public int SceneId;

    public bool canLoad;
    public Vector3 LastPos;

    public GameObject player;
    void Update()
    {
        if(canLoad == true)
        {
            LastPos = player.transform.position;
            StartCoroutine(LoadScene());
        }
    }
    IEnumerator LoadScene()
    {
        anim.SetTrigger("End");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneId);
        if (SceneManager.GetActiveScene().name == "island")
        {
            player.transform.position = LastPos;
        }
    }

}
