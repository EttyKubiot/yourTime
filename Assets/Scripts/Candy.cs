using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void ShowExplosionFx()
    {
        ParticleSystem particles = GetComponentInChildren<ParticleSystem>();
        particles.Play();
        particles.transform.position = transform.position;
    }
}
