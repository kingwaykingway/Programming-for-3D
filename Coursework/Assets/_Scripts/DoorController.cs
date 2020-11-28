using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Vector3 ballSpawningPosition;
    [SerializeField] private List<GameObject> ballPool;
    
    private bool _isPlayerInBound;

    private Animator _animator;
    private Collider _doorTrigger;
    
    void Start()
    {
        _animator = GetComponent<Animator>();

        _doorTrigger = GetComponent<Collider>();
        if (!_doorTrigger.isTrigger)
        {
            Debug.Log("The collider should be a trigger. ");
        }
    }
    
    void Update()
    {
        
    }

    public void Open()
    {
        _animator.SetBool("IsOpen", true);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log(gameObject + " hit the player");
            // _animator
        }
    }

    private void OnTriggerExit(Collider other)
    {        
        if (other.gameObject.tag.Equals("Player"))
        {
            _animator.SetBool("IsOpen", false);

            GameObject b = ballPool[new Random().Next(ballPool.Count)];
            GameObject.Instantiate(b, ballSpawningPosition, Quaternion.identity);
        }
    }
}
