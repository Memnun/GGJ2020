using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class MusicPlayer : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string EventPath;
    EventInstance MemeInst;
    
    void Start()
    {
        MemeInst = RuntimeManager.CreateInstance(EventPath);
        MemeInst.start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        MemeInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
