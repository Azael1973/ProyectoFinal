using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixer musicMixer, effectsMixer;

    public AudioSource melee, jump, steps, enemydeath, arrow, door, musicabg;

    public static AudioManager instance;

    public float masterVol, effectsVol;
    public Slider masterSldr, effectsSldr;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayAudio(musicabg);
        masterSldr.value = masterVol;
        effectsSldr.value = effectsVol;

        masterSldr.minValue = -80;
        masterSldr.maxValue = 10;
        effectsSldr.minValue = -80;
        effectsSldr.maxValue = 10;
    }

    // Update is called once per frame
    void Update()
    {
        MasterVolume();
        EffectVolume();
    }

    public void MasterVolume()
    {
        musicMixer.SetFloat("MasterVolume", masterSldr.value);
    }

    public void EffectVolume()
    {
        effectsMixer.SetFloat("EffectsVolumen", effectsSldr.value);
    }

    public void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }
}
