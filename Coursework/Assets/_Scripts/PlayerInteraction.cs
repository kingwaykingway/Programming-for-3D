using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] [Range(0, Single.PositiveInfinity)] private float throwBallForce = 500f;
    
    private List<GameObject> _reachableObjects = new List<GameObject>();
    private Transform _mainCameraTransform;
    
    private SphereCollider _interactionTrigger;
    private GameObject _highlightedObject, _heldBall;

    void Start()
    {
        _interactionTrigger = GetComponent<SphereCollider>();
        if (!_interactionTrigger.isTrigger)
        {
            Debug.Log("The sphere trigger should be a trigger. ");
        }
        
        _mainCameraTransform = Camera.main.transform;
    }
    
    void Update()
    {
        _highlightedObject = null;
        float angle = 90f;
        
        foreach (var o in _reachableObjects)
        {
            float a = Vector3.Angle(_mainCameraTransform.forward, o.transform.position - _mainCameraTransform.position);
            if (Mathf.Abs(a) < angle)
            {
                _highlightedObject = o;
                angle = a;
            }
        }

        foreach (var o in _reachableObjects)
        {
            o.GetComponent<Outline>().enabled = o.Equals(_heldBall == null ? _highlightedObject : _heldBall);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_highlightedObject != null)
            {
                if (_highlightedObject.GetComponent<DoorController>())
                {
                    _highlightedObject.GetComponent<DoorController>().Open();
                }
                else if (_heldBall == null)
                {
                    pickUpBall();
                }
                else
                {
                    dropBall();
                }
            }
        }

        if (Input.GetMouseButtonDown(0) && _heldBall != null)
        {
            throwBall();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Interactive"))
        {
            Debug.Log("1");
            _reachableObjects.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Interactive"))
        {
            other.GetComponent<Outline>().enabled = false;
            _reachableObjects.Remove(other.gameObject);
        }
    }

    private void pickUpBall()
    {
            _heldBall = _highlightedObject;
            _heldBall.transform.SetParent(_mainCameraTransform);
            _heldBall.transform.position = _mainCameraTransform.position
                                           + _mainCameraTransform.forward * 0.6f
                                           - _mainCameraTransform.up * 0.4f;
            _heldBall.GetComponent<Rigidbody>().isKinematic = true;
            _heldBall.GetComponent<Outline>().OutlineColor = Color.red;
    }

    private GameObject loseBall()
    {
        var ball = _heldBall;

        if (ball != null)
        {
            _heldBall.transform.SetParent(null);
            _heldBall.GetComponent<Rigidbody>().isKinematic = false;
            _heldBall.GetComponent<Outline>().OutlineColor = Color.white;
            _heldBall = null;
        }
        
        return ball;
    }

    private void dropBall()
    {
        loseBall().transform.position = transform.position + transform.forward;
    }
    
    private void throwBall()
    {
        var ball = loseBall();

        if (ball != null)
        {
            ball.GetComponent<Rigidbody>().AddForce(_mainCameraTransform.forward * throwBallForce);
        }
    }
}
