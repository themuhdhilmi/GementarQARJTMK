using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AtanLoadScene : MonoBehaviour
{
    public void LoadSceneAr()
    {
        SceneManager.LoadScene("ARScene");
    }

    public void LoadSceneMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
