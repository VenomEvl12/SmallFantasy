using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllAudio : MonoBehaviour
{
    public AudioClip[] audios;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void PlayAudioAttack()
    {
        source.PlayOneShot(audios[0], 0.5f);
    }

    public void PlayAudioDeath()
    {
        source.PlayOneShot(audios[1], 0.5f);
    }

    public void PlayAudioFootstep()
    {
        source.PlayOneShot(audios[2], 0.5f);
    }

    public void PlayAudioHit()
    {
        source.PlayOneShot(audios[3], 0.5f);
    }

    public void PlayGolemAttack()
    {
        source.PlayOneShot(audios[4], 0.5f);
    }

    public void PlayGolemDeath()
    {
        source.PlayOneShot(audios[5], 0.5f);
    }
    public void PlayGolemHit()
    {
        source.PlayOneShot(audios[6], 0.5f);
    }
}
