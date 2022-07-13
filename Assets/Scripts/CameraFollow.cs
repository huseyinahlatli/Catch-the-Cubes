using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] private float translateSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] float lerpValue;
    [SerializeField] private int prefabCount;
    
    #region Singleton class: CameraFollow
    
    public static CameraFollow instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    
    #endregion

    private void Update()
    {
        prefabCount = GameManager.instance.prefabList.Count;
    }

    private void LateUpdate()
    {
        MoveTheCamera();
    }

    private void MoveTheCamera()
    {
        var targetPosition = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition + new Vector3(0, prefabCount, 0), 
            translateSpeed * Time.deltaTime
        );
    }
}
