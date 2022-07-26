using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AutoSave01 : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("AutoSave",2);
        AudioListener.volume = 1f;
    }
}
