using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CumLauncher : MonoBehaviour
{
    public ParticleSystem particles;
    public InputActionProperty triggerPressWatcher;

    private bool triggerIsPressed = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float triggerPressValue = triggerPressWatcher.action.ReadValue<float>();

        if (!triggerIsPressed && triggerPressValue == 1)
        {
            particles.Play();
            triggerIsPressed = true;
        }
        if (triggerPressValue == 0)
        {
            triggerIsPressed = false;
        }
    }
}