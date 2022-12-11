using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class AtanOnEnable : MonoBehaviour
{

    public bool startRotate = false;
    public bool startMainAnimation = false;

    private void OnEnable()
    {
        if (startRotate)
        {
            this.transform.DOLocalRotate(new Vector3(0, 30f, 0), 0f);
            this.transform.DOLocalRotate(Vector3.zero, 3f);
        }

        if(startMainAnimation) 
        {
            PlayableDirector playableDirector = this.GetComponent<PlayableDirector>();
            playableDirector.Play(); 
        }
    }

}
