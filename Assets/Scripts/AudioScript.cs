using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    
    public AudioSource MusicSource;

    public AudioClip OST1, OST2, OST3;

    private int CurrentMusic;

    void Start()
    {
        CurrentMusic = 1;
        MusicSource.clip = OST1;
        MusicSource.Play();
    }
/* To gowno robi michu takie cos ze jak sobie 
   np pierdykniesz spacyjke to zacznie song dudnić */

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            CurrentMusic = CurrentMusic +1;
            if (CurrentMusic > 3) {
                CurrentMusic = 1;
            }
            switch (CurrentMusic) {
                default:
                    MusicSource.clip = OST1;
                    MusicSource.Play();
                    break;
                case 1:
                    MusicSource.clip = OST1;
                    MusicSource.Play();
                    break;
                case 2:
                    MusicSource.clip = OST2;
                    MusicSource.Play();
                    break;
                case 3:
                    MusicSource.clip = OST3;
                    MusicSource.Play();
                    break;
            }
        }
    }
}
