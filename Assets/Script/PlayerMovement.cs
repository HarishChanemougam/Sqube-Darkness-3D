using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _moveSpeed = 5.0f;
    [SerializeField] float _jumpForce = 6.0f;
    [SerializeField] bool _jump;
    [SerializeField] InputActionReference _input;
    [SerializeField] Animator _animator;

    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();

        _jump = true;
       
    }

    private void Update()
    {
        float movX = Input.GetAxisRaw("Horizontal");
        float movY = Input.GetAxisRaw("Vertical");

        if(movX != 0)
        {
            _rb.velocity = new Vector2(_moveSpeed * movX, _rb.velocity.y);
        }

        if(movY == 1 && ! _jump)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);

            _jump = true;
        }

        if(movY == 1)
        {
            transform.localScale = new Vector2(1f, 0.5f);
        }

        else
        {
            transform.localScale = new Vector2(1f, 1f);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _jump = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "BlindSpot")
        {
            _animator.SetTrigger("2DPlayerEyeBlink");
        }

        else
        {
            _animator.SetTrigger("2DPlayerEyeBlink2");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
