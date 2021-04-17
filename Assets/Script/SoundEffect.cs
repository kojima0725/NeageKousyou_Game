using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    [SerializeField]
    AudioSource source;

    [SerializeField]
    AudioClip moneySound;

    [SerializeField]
    AudioClip jumpSound;

    public void PlayMoneySound()
    {
        source.PlayOneShot(moneySound);
    }

    public void PlayJumpSound()
    {
        source.PlayOneShot(jumpSound);
    }
}
