using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------Audio Source---------")]
    public AudioSource musicSource;
    public AudioSource SFXSource;

    [Header("---------Audio Clip---------")]
    public AudioClip background;
    public AudioClip endTurn;
    public AudioClip playerTurn;
    public AudioClip enemyTurn;
    public AudioClip cardSelect;
    public AudioClip CardDeal;
    public AudioClip PlayerAtk_Sword;
    public AudioClip EnemyAtk_Scimitar;

    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
