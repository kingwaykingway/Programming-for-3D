using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRevival : MonoBehaviour
{
    [SerializeField] private float playerRespawnCriticalHeight = -50f;

    private Vector3 initialPosition;
    
    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (transform.position.y < playerRespawnCriticalHeight)
        {
            Debug.Log(transform.position.y);
            Respawn();
        }
    }

    public void Respawn()
    {
        Instantiate(gameObject, initialPosition, new Quaternion());
        Destroy(gameObject);
    }
}
