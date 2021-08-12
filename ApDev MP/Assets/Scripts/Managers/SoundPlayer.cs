using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//plays a sound
//used in input events such as click events
//needs an audio manager object to work
public class SoundPlayer : MonoBehaviour
{
    public void PlaySound(string soundSTR)
    {
        FindObjectOfType<AudioManager>().Play(soundSTR);
    }
}
