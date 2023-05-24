using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// destroyes the gameobject after 1 sec
public class DestroyCopie : MonoBehaviour
{
    void Update()
    {
        // destroyes the gameobject after 1 sec
        Destroy(gameObject,1);
    }
}
