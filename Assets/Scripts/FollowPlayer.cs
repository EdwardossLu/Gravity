﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class FollowPlayer : MonoBehaviour
{
    [Header("General")]
    [SerializeField]private Transform target = null;
    [Range(0.01f, 0.1f)] [SerializeField] private float smoothFactor = 0f;

    private Vector3 _cameraOffest;


    private void Awake()
    {
        Assert.IsNotNull(target);
    }

	private void Start() 
    {
        // Get the distance between the camera and target.
		_cameraOffest = transform.position - target.position;
	}

	void Update () 
    {
        // Set the distance between the camera and target.
		Vector3 newPos = target.position + _cameraOffest;

        if (transform.position - newPos != Vector3.zero)
		    transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);
	}
}
