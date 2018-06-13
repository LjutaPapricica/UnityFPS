using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Destroy the gameobject that pass the trigger
/// </summary>
public class ObjectDestroyer : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
