using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class LightSwitch : MonoBehaviour
{
    [SerializeField] private List<GameObject> switchableObjects;
    
    private bool _isSwitchedOn;

    private void Start()
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

/*public class LightSwitch : MonoBehaviour
{
    [SerializeField] private GameObject lightObject;
    [SerializeField] private GameObject audioObject;
    
    private bool _isSwitchedOn;
    
    void Start()
    {
        _isSwitchedOn = lightObject != null && lightObject.active 
                        || audioObject != null && audioObject.active;
    }

    public void Toggle()
    {
        _isSwitchedOn = !_isSwitchedOn;
 
        if (lightObject != null)
        {
            lightObject.SetActive(_isSwitchedOn);
        }

        if (audioObject != null)
        {
            audioObject.SetActive(_isSwitchedOn);
        }
    }
}*/
