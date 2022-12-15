using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AtanEnableDisableTrigger : MonoBehaviour
{
    public GameObject gamesObject;
    public GameObject buttonpack;
    public GameObject gameObjectStatic;
    public GameObject modelObjectsFollowCamera;
    public ParticleSystem particleSystemModelObjectsFollowCamrea;


    private Coroutine objectFollowCameraRoutine;

    public float velocity = 25f;

    private bool hasDetected = false;

    [Button]
    public void enableObject()
    {
        hasDetected = true;
        Debug.LogWarning("DETECT");
        gamesObject.SetActive(true);
        gameObjectStatic.SetActive(false);

        
        if(objectFollowCameraRoutine != null) StopCoroutine(objectFollowCameraRoutine);
        objectFollowCameraRoutine = null;
        objectFollowCameraRoutine = StartCoroutine(disableObjestFollowCamera());
        //StopCoroutine(objectFollowCameraRoutineFam);
    }

    [Button]
    public void disableObject()
    { 
        if(hasDetected)
        {

            gamesObject.SetActive(false);
            buttonpack.SetActive(false);
            gameObjectStatic.gameObject.transform.localPosition = new Vector3(0,0, 1.24f);
            gameObjectStatic.SetActive(true);

            if (objectFollowCameraRoutine != null) StopCoroutine(objectFollowCameraRoutine);
            objectFollowCameraRoutine = null;
            objectFollowCameraRoutine = StartCoroutine(hoveredFreeFlyingPoster());
            //StopCoroutine(objectFollowCameraRoutine);
        }
    }

    private IEnumerator hoveredFreeFlyingPoster()
    {
        modelObjectsFollowCamera.SetActive(true);

        yield return new WaitForSeconds(3f);

        particleSystemModelObjectsFollowCamrea.Play();
        modelObjectsFollowCamera.SetActive(false);

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("Poster");

    }


    private IEnumerator disableObjestFollowCamera()
    {

        yield return new WaitForSeconds(3f);

        particleSystemModelObjectsFollowCamrea.Play();
        modelObjectsFollowCamera.SetActive(false);
    }
}
