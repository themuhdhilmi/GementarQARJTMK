using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtanOnEnable : MonoBehaviour
{

    public bool startRotate = false;

    private void OnEnable()
    {
        if (startRotate)
        {
            this.transform.DOLocalRotate(new Vector3(0, 30f, 0), 0f, RotateMode.Fast);
            this.transform.DOLocalRotate(Vector3.zero, 3f, RotateMode.Fast);
        }
    }

}
