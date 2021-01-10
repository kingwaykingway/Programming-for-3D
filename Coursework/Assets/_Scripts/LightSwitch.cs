using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LightSwitch : MonoBehaviour
{
    [SerializeField] private GameObject lightObject;
    [SerializeField] private GameObject audioObject;
    
    private bool _isSwitchedOn;
    
    void Start()
    {
        _isSwitchedOn = (lightObject != null && lightObject.active) 
                        || (audioObject != null && audioObject.active);
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
}
