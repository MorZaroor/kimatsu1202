using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    public float lifetime = 0.3f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
