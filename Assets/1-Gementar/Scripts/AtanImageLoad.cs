using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public  class AtanImageLoad : MonoBehaviour
{

    private static List<Texture2D> imagesList;


    private void Awake()
    {
        imagesList= new List<Texture2D>();
        setImagesList();
    }

    private void setImagesList()
    {
        int index = 1;
        foreach (var item in getPathList())
        {
            imagesList.Add(LoadPNG(item, index));
            index++;
        }
    }

    private string[] getPathList()
    {
        return Directory.GetFiles($"{Application.persistentDataPath}/images/", "*", SearchOption.TopDirectoryOnly);
    }

    private Texture2D LoadPNG(string filePath, int index)
    {

        Texture2D tex = null;
        byte[] fileData;

        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
            tex.name = $"pt{index}";
        }

        return tex;
    }

    public static Texture2D getImages(int index)
    {
        return imagesList[index];
    }




}
