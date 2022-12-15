using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Policy;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class AtanLoading : MonoBehaviour
{

    public List<Texture2D> posterList;
    public TextMeshProUGUI loadingText;
    

    public bool firstTime = true;
    public string dateUpload = "";
    

    void Start()
    {
        StartCoroutine(loadStart());
    }

    IEnumerator loadStart()
    {
        float intervalTimer = 3;
        bool internetAvailable = false;
        string fetched = "";

        checkFirstLoad();
        yield return new WaitForSeconds(intervalTimer);

        yield return checkInternetConnection(isConnected => {internetAvailable = isConnected;});

        yield return new WaitForSeconds(intervalTimer);

        yield return GetRequest("", fetchedResult =>
        {
            changeLoadText("Fetched");
            fetched = fetchedResult;
        });

        if (internetAvailable) 
        {
            yield return GetRequest("https://qar.gementar.com/date", fetchedResult =>
            {
                changeLoadText("Fetched date");
                fetched = fetchedResult;
            });

            yield return new WaitForSeconds(intervalTimer);

            if (!dateUpload.Equals(fetched))
            {

                yield return LoadImageFromURL("pt1", "https://qar.gementar.com/poster_images/pt1.jpg", texture =>
                {
                    saveImageIntoPresistenDataPath(texture);
                });

                yield return LoadImageFromURL("pt2", "https://qar.gementar.com/poster_images/pt2.jpg", texture =>
                {
                    saveImageIntoPresistenDataPath(texture);
                });

                yield return LoadImageFromURL("pt3", "https://qar.gementar.com/poster_images/pt3.jpg", texture =>
                {
                    saveImageIntoPresistenDataPath(texture);
                });

                yield return LoadImageFromURL("pt4", "https://qar.gementar.com/poster_images/pt4.jpg", texture =>
                {
                    saveImageIntoPresistenDataPath(texture);
                });

                yield return LoadImageFromURL("pt5", "https://qar.gementar.com/poster_images/pt5.jpg", texture =>
                {
                    saveImageIntoPresistenDataPath(texture);
                });

                dateUpload = fetched;
                ES3AutoSaveMgr.Current.Save();
            }
            else
            {
                changeLoadText("You're up to date");
                yield return new WaitForSeconds(intervalTimer);
            }

        }

        this.GetComponent<AtanLoadScene>().LoadSceneMenu();
    }


    private IEnumerator checkInternetConnection(Action<bool> action)
    {
        UnityWebRequest request = new UnityWebRequest("http://google.com");
        yield return request.SendWebRequest();
        if (request.error != null)
        {
            changeLoadText("No internet avaiable....");
            action(false);
        }
        else
        {
            changeLoadText("Internet avaiable....");
            action(true);
        }
    }

    private void checkFirstLoad()
    {
        if (firstTime)
        {
            changeLoadText("first load");
            foreach (var item in posterList)
            {
                saveImageIntoPresistenDataPath(item);
            }

            firstTime = false;
            ES3AutoSaveMgr.Current.Save();
        }
    }

    IEnumerator GetRequest(string uri, Action<string> str)
    {
        UnityWebRequest www = UnityWebRequest.Get("https://qar.gementar.com/date");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            str(www.downloadHandler.text);
        }
    }

    private void saveImageIntoPresistenDataPath(Texture2D texture)
    {
        byte[] bytes = texture.EncodeToPNG();
        var dirPath = $"{Application.persistentDataPath}/images";
        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }
        File.WriteAllBytes($"{Application.persistentDataPath}/images/{texture.name}" + ".jpg", bytes);
    }

    public IEnumerator LoadImageFromURL(string name,string url, Action<Texture2D> action)
    {
        changeLoadText("Downloading ... " + name);
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            changeLoadText("No connection to server....");
        }
        else
        {

            Texture2D texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            texture.name = name;
            action(texture);
        }
    }


    private void changeLoadText(string text)
    {
        loadingText.text = text;
    }


}
