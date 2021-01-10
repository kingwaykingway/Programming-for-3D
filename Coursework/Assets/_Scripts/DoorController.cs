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
<<<<<<< HEAD
=======
        SpawnBall();
>>>>>>> parent of be08006... 2021/1/10 update
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log(gameObject + " hit the player");
        }
    }

    private void OnTriggerExit(Collider other)
    {        
        if (other.gameObject.tag.Equals("Player"))
        {
            _animator.SetBool("IsOpen", false);

            // SpawnBall();
        }
    }

    void SpawnBall()
    {
        GameObject b = ballPool[new Random().Next(ballPool.Count)];
<<<<<<< HEAD

        var pos = ballSpawningPosition;
        if (useRelativePosition)
        {
            pos += transform.root.position;
        }
        Instantiate(b, pos, Quaternion.identity);
=======
        GameObject.Instantiate(b, ballSpawningPosition, Quaternion.identity);
>>>>>>> parent of be08006... 2021/1/10 update
    }
}
