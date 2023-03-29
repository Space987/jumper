using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAffects : MonoBehaviour
{
    [SerializeField]
    ParticleSystem part = null;


    private void OnTriggerEnter(Collider other) 
    {
        part.Play();
    }
}
