using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CameraLag : MonoBehaviour
{
    [Header("General")]
    
    [SerializeField] private Transform target = null;

    [Tooltip("The lag distance between points. Lower number = higher distance")]
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

        // if the distance between the two transform isn't zero.
        if (transform.position - newPos != Vector3.zero)
            // Move the character to the player.
		    transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);
	}
}
