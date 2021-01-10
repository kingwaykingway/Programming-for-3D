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
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
        SpawnBall();
>>>>>>> parent of be08006... 2021/1/10 update
=======
        // SpawnBall();
>>>>>>> parent of 19007a1... 2021/1/10 #1
=======
        SpawnBall();
>>>>>>> parent of be08006... 2021/1/10 update
=======
        // SpawnBall();
>>>>>>> parent of 19007a1... 2021/1/10 #1
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log(gameObject + " hit the player");
            // _animator
<<<<<<< HEAD
=======
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _enteredPosition = other.transform.position;
            _isPlayerPassing = true;
>>>>>>> parent of 19007a1... 2021/1/10 #1
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
<<<<<<< HEAD

        var pos = ballSpawningPosition;
        if (useRelativePosition)
        {
            /*var p = transform;
            while (p.parent != null)
            {
                p = p.parent;
            }*/
            pos += transform.root.position;
        }
        Instantiate(b, pos, Quaternion.identity);
=======
        GameObject.Instantiate(b, ballSpawningPosition, Quaternion.identity);
>>>>>>> parent of be08006... 2021/1/10 update
=======
        GameObject.Instantiate(b, ballSpawningPosition, Quaternion.identity);
>>>>>>> parent of be08006... 2021/1/10 update
    }
}
