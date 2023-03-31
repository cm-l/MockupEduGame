using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSound : MonoBehaviour
{
    [SerializeField] private AudioClip attackSound, gearSound;

    public void PlayAttackSound()
    {
        SoundSystemSingleton.Instance.PlaySfxSound(attackSound);
    }

    public void PlayDrawSound()
    {
        SoundSystemSingleton.Instance.PlaySfxSound(gearSound);
    }
}
