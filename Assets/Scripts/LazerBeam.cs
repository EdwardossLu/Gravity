using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class LazerBeam : MonoBehaviour
{

    private bool _switchLazerState = true;
    
    private Renderer _rend;
    private Collider _col;


    private void Awake() 
    {
        _rend = GetComponent<Renderer>();
        _col = GetComponent<Collider>();
    }

    private void Start() 
    {
        StartCoroutine("SetBeamVisability");
    }

    private IEnumerator SetBeamVisability()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            BeamToggle();
        }
    }

    private void BeamToggle()
    {
        _switchLazerState = !_switchLazerState;

        _rend.enabled = _switchLazerState;
        _col.enabled = _switchLazerState;
    }
}
