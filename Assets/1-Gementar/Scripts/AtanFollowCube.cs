using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtanFollowCube : MonoBehaviour
{
    public GameObject followObject;

    private void Update()
    {
        transform.DOMove(followObject.transform.position, 3f);
        transform.DOLookAt(Camera.main.transform.position, 3f);
    }
}

