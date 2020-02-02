using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class GlobalSounds : MonoBehaviour
{

    public EventInstance music;
    public int MusicIntensity; //0: aim, 1: flight, 2: shop
    public bool Win; //No/Win

    // Start is called before the first frame update
    void Start()
    {
        music = RuntimeManager.CreateInstance("event:/Music/MusicLevel");
        MusicIntensity = 0;
        Win = false;
        music.start();
    }

    // Update is called once per frame
    void Update()
    {
        music.setParameterByName("MusicIntensity", MusicIntensity, true);
    }
}
