using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class AtanARButton : MonoBehaviour
{
    public GameObject buttonPack;
    public GameObject bodyObj;

    public List<Texture2D> postersBody;

    public void firstPoster()
    {
        replacePoster(postersBody[0]);
    }

    public void secondPoster()
    {
        replacePoster(postersBody[1]);
    }

    public void thirdPoster()
    {
        replacePoster(postersBody[2]);
    }

    public void fourthPoster()
    {
        replacePoster(postersBody[3]);
    }  

    private void replacePoster(Texture2D texture)
    {
        bodyObj.GetComponent<MeshRenderer>().material.mainTexture = texture;
    }

    [Button]
    public void enalbeButtonPack()
    {
        buttonPack.SetActive(true);
    }
}
