using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefControl : MonoBehaviour
{
    private void Start()
    {
        //PlayerPrefs.SetInt("testkey", 2);

        Debug.Log(PlayerPrefs.HasKey("testkey")); // true
        Debug.Log(PlayerPrefs.GetInt("testkey")); // 2
    }
}
