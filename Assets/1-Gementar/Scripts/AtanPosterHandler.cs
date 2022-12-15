using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class AtanPosterHandler : MonoBehaviour
{

    private List<Texture2D> postersBody;
    public RawImage posterTexture;

    public GameObject buttonLeft;
    public GameObject buttonRight;

    private void Start()
    {
        postersBody = new List<Texture2D>
        {
            AtanImageLoad.getImages(0),
            AtanImageLoad.getImages(1),
            AtanImageLoad.getImages(2),
            AtanImageLoad.getImages(3)
        };

        posterTexture.texture = postersBody[0];
    }


    public void toTheRight()
    {
        int index = 0;
        foreach (var item in postersBody)
        {
            if(item.name.Equals(posterTexture.texture.name))
            {
                try
                {

                    if (item.name.Equals(AtanImageLoad.getImages(3).name))
                    {
                        buttonRight.SetActive(false);
                    }
                    buttonLeft.SetActive(true);

                    posterTexture.texture = postersBody[index + 1];
                    
                    return;
                }
                catch (Exception)
                {
                    //out of bond
                }
            }

            index++;
        }
    }

    public void toTheLeft()
    {
        int index = 0;
        foreach (var item in postersBody)
        {
            if (item.name == posterTexture.texture.name)
            {
                try
                {

                    if (item.name.Equals(AtanImageLoad.getImages(0).name))
                    {
                        buttonLeft.SetActive(false);
                    }
                    buttonRight.SetActive(true);

                    posterTexture.texture = postersBody[index - 1];

                }
                catch (Exception)
                {
                    //out of bond
                }
            }

            index++;
        }
    }

}
