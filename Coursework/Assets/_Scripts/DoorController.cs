using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Vector3 ballSpawningPosition;
    [SerializeField] private bool useRelativePosition = true;
    [SerializeField] private List<GameObject> ballPool;
    
    private bool _isPlayerPassing;
    private Vector3 _enteredPosition;

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

    public void Open()
    {
        _animator.SetBool("IsOpen", true);
        SpawnBall();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log(gameObject + " hit the player");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _enteredPosition = other.transform.position;
            _isPlayerPassing = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {        
        if (other.gameObject.tag.Equals("Player"))
        {
            _animator.SetBool("IsOpen", false);
        }
    }

    void SpawnBall()
    {
        GameObject b = ballPool[new Random().Next(ballPool.Count)];

        var pos = ballSpawningPosition;
        if (useRelativePosition)
        {
            pos += transform.root.position;
        }
        Instantiate(b, pos, Quaternion.identity);
    }
}
