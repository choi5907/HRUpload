using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSave02 : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("AutoSave",3);
        AudioListener.volume = 1f;
    }
}
