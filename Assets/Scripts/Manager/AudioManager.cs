using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource DuckSound;
    public AudioSource CoinSound;
    public AudioClip DuckClip;
    public AudioClip CoinClip;

    public void PlayDuckSound()
    {
        DuckSound.PlayOneShot(DuckClip);
    }

    public void PlayCointSound()
    {
        CoinSound.PlayOneShot(CoinClip);
    }
}
