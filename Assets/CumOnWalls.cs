using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CumOnWalls : MonoBehaviour
{
    void Start()
    {

    }
    void OnParticleTrigger()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        Component component = ps.trigger.GetCollider(0);

        // particles
        List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
        List<ParticleSystem.Particle> exit = new List<ParticleSystem.Particle>();

        // getting the trigger particles sets a list and returns the size of the list i guess lol
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        int numExit= ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, exit);

        // iterate through particles that entered the collider field
        for (int i = 0; i < numEnter; i++)
        {
            ParticleSystem.Particle p = enter[i];
            p.velocity = new Vector3(0, 1, 0);
            enter[i] = p;
        }

        for (int i = 0; i < numExit; i++)
        {
            // try to move it just a little bit toward the collision spot?
            // might make more particles stick
        }

        // set particle data
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
    }

    // old test trying to better manage the gravity of each particle with a coroutine....did not go well lol

    //private IEnumerator reverseGravity(ParticleSystem ps, List<ParticleSystem.Particle> enter, int numEnter)
    //{
    //    // iterate
    //    System.DateTime gravityStartTime = System.DateTime.Now;
    //    if (numEnter > 0)
    //    {
    //        while (System.DateTime.Now < gravityStartTime.AddSeconds(10))
    //        {
    //            for (int i = 0; i < numEnter; i++)
    //            {
    //                ParticleSystem.Particle p = enter[i];
    //                double timeUnderGravity = (System.DateTime.Now - gravityStartTime).TotalSeconds;
    //                float antiGravity = (float)(9.8 * (timeUnderGravity * timeUnderGravity));
    //                p.velocity = new Vector3(0, antiGravity, 0);
    //                enter[i] = p;
    //            }

    //            // set
    //            ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
    //            yield return null;
    //        }
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
