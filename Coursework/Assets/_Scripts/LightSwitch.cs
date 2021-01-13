using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LightSwitch : MonoBehaviour
{
    [SerializeField] private List<GameObject> switchableObjects;
    
    private bool _isSwitchedOn;
    
    void Start()
    {
        foreach (var o in switchableObjects)
        {
            if (o.active)
            {
                _isSwitchedOn = true;
                break;
            }
        }
    }

    public void Toggle()
    {
        _isSwitchedOn = !_isSwitchedOn;

        foreach (var o in switchableObjects)
        {
            o.SetActive(_isSwitchedOn);
        }
    }
}
