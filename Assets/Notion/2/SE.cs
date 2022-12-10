using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE : MonoBehaviour
{
    [SerializeField]AudioClip _Se;
    AudioSource _audiosource;

    public void Start()
    {
        _audiosource = GetComponent<AudioSource>();
    }
    public void Play()
    {
        _audiosource.PlayOneShot(_Se);
    }
}
