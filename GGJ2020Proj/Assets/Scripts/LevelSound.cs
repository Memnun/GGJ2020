using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class LevelSound : MonoBehaviour
{

    public EventInstance cannonLaunch;
    public EventInstance cannonReload;
    public EventInstance ambienceWoosh;
    public bool fired;
    public bool reloaded;
    public int firestate; //0: play, 1: shop, 2: win
    
    void Start()
    {
        cannonLaunch = RuntimeManager.CreateInstance("event:/Catapult/Launch");
        cannonLaunch.set3DAttributes(RuntimeUtils.To3DAttributes(transform));
        cannonReload = RuntimeManager.CreateInstance("event:/Catapult/Ammo");
        cannonReload.set3DAttributes(RuntimeUtils.To3DAttributes(transform));
        ambienceWoosh = RuntimeManager.CreateInstance("event:/AmbienceWhoosh");
        ambienceWoosh.start();
        firestate = 0;
        fired = false;
        reloaded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fired == true)
        {
            cannonLaunch.start();
            fired = false;
        }

        if (reloaded == true)
        {
            cannonReload.start();
            reloaded = false;
        }

        PLAYBACK_STATE ps;
        ambienceWoosh.getPlaybackState(out ps);
        if (firestate != 0 && ps == PLAYBACK_STATE.PLAYING)
        {
            ambienceWoosh.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }

        if (firestate == 0 && ps != PLAYBACK_STATE.PLAYING)
        {
            ambienceWoosh.start();
        }
    }

    private void OnDestroy()
    {
        ambienceWoosh.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
