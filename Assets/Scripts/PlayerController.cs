using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    
    [Tooltip("The speed of the character.")]
    [SerializeField] private float speed = 5f;

    [Tooltip("How fast should the character fly")]
    [Range(100f, 300f)] [SerializeField] private float flipedGravitySpeed = 150f;

    [SerializeField] private GameObject playerChar = null;

    private Animator animator = null;

    private Rigidbody _rb;

    private bool _flipGravity = true;


    private void Awake() 
    {
        _rb = GetComponent<Rigidbody>();
        Assert.IsNotNull(_rb);
    }

    private void Start() 
    {
        animator = playerChar.GetComponent<Animator>();
    }

    private void Update()
    {
        // Toggle the gravity of the player.
        if (Input.GetKeyDown(KeyCode.Space))     
            FlipGravity();
    }

    private void FixedUpdate() 
    {
        CharacterMovement();
    }

    private void CharacterMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        _rb.MovePosition(transform.position + transform.TransformDirection(Vector3.right * moveHorizontal));

        animator.SetFloat("inputX", moveHorizontal);
        print(moveHorizontal);
    }

    // Change the gravity of the player.
    private void FlipGravity()
    {
        _flipGravity = !_flipGravity;

        animator.SetBool("appGrav", _flipGravity);

        print(_flipGravity);

        _rb.useGravity = _flipGravity;
        
        if (_flipGravity == false)
            _rb.AddForce(Vector3.up * 150f);
    }
}
