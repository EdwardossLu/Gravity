using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody _rb;
    private bool flipGravity = true;

    private void Awake() 
    {
        _rb = GetComponent<Rigidbody>();
        Assert.IsNotNull(_rb);
    }

    private void Update() 
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        _rb.MovePosition(transform.position + transform.TransformDirection(Vector3.right * moveHorizontal));

        if (Input.GetKeyDown(KeyCode.Space))     
            FlipGravity();
    }

    private void FlipGravity()
    {
        flipGravity = !flipGravity;

        _rb.useGravity = flipGravity;
        
        if (flipGravity == false)
            _rb.velocity = Vector3.up * 5f;
    }
}
