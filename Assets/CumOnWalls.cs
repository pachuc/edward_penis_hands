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

        // particles
        List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
        List<ParticleSystem.Particle> exit = new List<ParticleSystem.Particle>();

        // getting the trigger particles sets a list and returns the size of the list i guess lol
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        int numExit= ps.GetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);

        // iterate through particles that entered the collider field
        for (int i = 0; i < numEnter; i++)
        {
            ParticleSystem.Particle p = enter[i];
            double idealCumDrop = (p.velocity.y * -1);
            p.velocity = new Vector3(0, (float)idealCumDrop, 0);
            enter[i] = p;
        }

        // iterate through particles that exited (bounced off) the collider field
        for (int i = 0; i < numExit; i++)
        {
            ParticleSystem.Particle p = exit[i];
            float reboundX = p.velocity.x;
            float reboundZ = p.velocity.z;

            // inverse the velocity + a lil extra to try and get it to go back and 'stick'
            p.velocity = new Vector3(-2*reboundX, 0, -2*reboundZ);
            exit[i] = p;
        }

        void OnParticleCollision(GameObject Other)
        {
            // something
        }

        // set particle data
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);
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
