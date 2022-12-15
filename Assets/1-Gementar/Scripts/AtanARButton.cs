using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Playables;
using DG.Tweening;
using Vuforia;

public class AtanARButton : MonoBehaviour
{
    public GameObject buttonPack;
    public GameObject bodyObj;
    private List<Texture2D> postersBody;

    private void Start()
    {


        postersBody = new List<Texture2D>
        {
            AtanImageLoad.getImages(0),
            AtanImageLoad.getImages(1),
            AtanImageLoad.getImages(2),
            AtanImageLoad.getImages(3),
            AtanImageLoad.getImages(4)
        };

        replacePoster(AtanImageLoad.getImages(4));
    }

    [Button]
    public void firstPoster()
    {
        replacePoster(postersBody[0]);
        disableButtonPack();
    }

    [Button]
    public void secondPoster()
    {
        replacePoster(postersBody[1]);
        disableButtonPack();
    }

    [Button]
    public void thirdPoster()
    {
        replacePoster(postersBody[2]);
        disableButtonPack();
    }

    [Button]
    public void fourthPoster()
    {
        replacePoster(postersBody[3]);
        disableButtonPack();
    }  

    private void mainPoster()
    {
        replacePoster(postersBody[4]);
        enalbeButtonPack();
    }

    private void replacePoster(Texture2D texture)
    {
        bodyObj.GetComponent<MeshRenderer>().material.mainTexture = texture;
    }

    [Button]
    public void enalbeButtonPack()
    {
        if(!buttonPack.activeSelf)
        {
            buttonPack.SetActive(true);
            mainPoster();
        }

    }

    public void disableButtonPack()
    {

        if (buttonPack.activeSelf)
        {

            buttonPack.SetActive(false);
        }

    }
}
