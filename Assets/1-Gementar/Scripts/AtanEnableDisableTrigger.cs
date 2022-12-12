using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        objectFollowCameraRoutine = StartCoroutine(disableObjestFollowCamera());
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

            modelObjectsFollowCamera.SetActive(true);
            StopCoroutine(objectFollowCameraRoutine);
        }
    }


    private IEnumerator disableObjestFollowCamera()
    {

        

        yield return new WaitForSeconds(3f);

        particleSystemModelObjectsFollowCamrea.Play();
        modelObjectsFollowCamera.SetActive(false);
    }
}
