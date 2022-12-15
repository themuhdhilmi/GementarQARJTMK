using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AtanLoading : MonoBehaviour
{

    public List<Texture2D> posterList;

    private bool firstTime = true;

    void Start()
    {

        if(firstTime)
        {
            foreach (var item in posterList)
            {
                saveImageIntoPresistenDataPath(item);
            }

            firstTime= false;
        }




        StartCoroutine(loadStart());
    }

    private void saveImageIntoPresistenDataPath(Texture2D texture)
    {
        byte[] bytes = texture.EncodeToPNG();
        var dirPath = Application.dataPath + "/../SaveImages/";
        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }
        File.WriteAllBytes($"{Application.persistentDataPath}/images/{texture.name}" + ".jpg", bytes);
    }


    IEnumerator loadStart()
    {
        yield return new WaitForSeconds(15f);

        this.GetComponent<AtanLoadScene>().LoadSceneMenu();
    }


}
