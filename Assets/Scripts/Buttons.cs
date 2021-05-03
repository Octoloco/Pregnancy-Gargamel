using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    public void NextGame()
    {
        StartCoroutine(WaitForAnimation());
    }

    public void LoadNextScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(sceneIndex);
        sceneIndex++;
        if (sceneIndex > SceneManager.sceneCountInBuildSettings - 1)
        {
            sceneIndex = 1;
        }

        SceneManager.LoadScene(sceneIndex);
    }


    public void StartGame()
    {
        GameObject.Find("Canvas").GetComponentInChildren<Animator>().SetTrigger("play");
        StartCoroutine(WaitForAnimation());
    }

    IEnumerator WaitForAnimation()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            yield return new WaitForSeconds(1.5f);
        }
        GameObject.Find("TransitionCanvas").GetComponentInChildren<Animator>().SetBool("cover", true);
        yield return new WaitForSeconds(.5f);
        LoadNextScene();
    }

}
