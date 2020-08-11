using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkEvents : MonoBehaviour
{
    [SerializeField] GameObject particles;
    void Start()
    {
        
    }

    public void InvokeForkEvent()
    {
        GameObject compressionParticles = Instantiate(particles);
        Destroy(compressionParticles, 1f);
    }
    void Update()
    {
        
    }
}
