using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] AudioMixer _audioMixer;
    public void SetVolume(float volume)
    {
        _audioMixer.SetFloat("Volume", volume);
    }
}
