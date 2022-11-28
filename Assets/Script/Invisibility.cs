using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour
{/*
    [SerializeField] MeshRenderer _renderer;
    [SerializeField] Material _materalIdle;
    [SerializeField] float _activationTime;

    bool _invisibility;


    private void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _activationTime = 0;
        _invisibility = false;
        _materalIdle = _renderer.sharedMaterial;
    }

    private void Update()
    {
        _activationTime += Time.deltaTime;
        if (_invisibility && _activationTime >= 3)
        {
            _invisibility = false;
            _materalIdle.shader = 1;
            _renderer.sharedMaterial = _materalIdle;
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Invisibility")
        {
            _invisibility = true;
            _activationTime = 0;
            _materalIdle.shader = 2f;
            _renderer.sharedMaterial = _materalIdle;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        
    }*/
}
