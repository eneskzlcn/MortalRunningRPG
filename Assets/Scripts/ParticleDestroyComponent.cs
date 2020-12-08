using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//It is controlling blood particle effect.
public class ParticleDestroyComponent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,2.5f);
    }
}
