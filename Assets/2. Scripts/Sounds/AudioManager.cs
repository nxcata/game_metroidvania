using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer musicMixer, effectsMixer;

    public AudioSource backgroundMusic, hit, enemyDead, gems, arrow;

    public static AudioManager instance;

    [Range(-80,10)]

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
        PlayAudio(backgroundMusic);
        masterSldr.value = masterVol;
        effectsSldr.value = effectsVol;

        effectsSldr.minValue = -80;
        effectsSldr.maxValue = 10;

        masterSldr.minValue = -80;
        masterSldr.maxValue = 10;


    }

    // Update is called once per frame
    void Update()
    {
        MasterVolume();
        EffectsVolume();
    }

    public void MasterVolume()
    {
        musicMixer.SetFloat("MasterVolumen", masterSldr.value);

    }

    public void EffectsVolume()
    {
        effectsMixer.SetFloat("EffectsVolumen", effectsSldr.value);

    }

    public void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }
}
