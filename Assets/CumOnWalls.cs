using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CumOnWalls : MonoBehaviour
{
    void Start()
    {

    }
    void OnParticleTrigger()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();

        // particles
        List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

        // get
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

        // iterate
        for (int i = 0; i < numEnter; i++)
        {
            ParticleSystem.Particle p = enter[i];
            p.velocity = new Vector3(0, 0, 0);
            p.angularVelocity3D = new Vector3(0, 0, 0);
            p.angularVelocity = 0f;
            enter[i] = p;
        }

        // set
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
