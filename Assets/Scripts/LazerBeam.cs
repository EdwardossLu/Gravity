using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class LazerBeam : MonoBehaviour
{
    [SerializeField] private float beamTimer = 2f;

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

    // Toggle the visibility of the the light beam.
    private IEnumerator SetBeamVisability()
    {
        while (true)
        {
            yield return new WaitForSeconds(beamTimer);
            BeamToggle();
        }
    }

    // Change the rendering of the the light beam.
    private void BeamToggle()
    {
        _switchLazerState = !_switchLazerState;

        _rend.enabled = _switchLazerState;
        _col.enabled = _switchLazerState;
    }
}
