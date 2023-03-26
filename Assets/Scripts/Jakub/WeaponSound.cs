using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSound : MonoBehaviour
{
    [SerializeField] private AudioClip weaponSound;

    public void PlaySound()
    {
        SoundSystemSingleton.Instance.PlaySfxSound(weaponSound);
    }
}
