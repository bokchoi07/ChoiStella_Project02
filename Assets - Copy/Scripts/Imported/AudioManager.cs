using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance = null;

    AudioSource _audioSource;

    private void Awake()
    {
        #region Singleton Pattern (Simple)
        if(Instance == null)
        {
            // doesnt exist yet, this is our singleton
            Instance = this;
            DontDestroyOnLoad(gameObject);
            // fill references
            _audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
        #endregion
    }

    public void PlaySong(AudioClip clip)
    {
        if (_audioSource.isPlaying)
        {
            return;
        }
        _audioSource.clip = clip;
        _audioSource.Play();
    }
}
