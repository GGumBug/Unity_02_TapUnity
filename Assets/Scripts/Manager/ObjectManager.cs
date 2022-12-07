using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    #region Singletone
    private static ObjectManager Instance = null;
    public static ObjectManager GetInstance()
    {
        if (Instance == null)
        {
        GameObject go = new GameObject("@ObjectManager");
        Instance = go.AddComponent<ObjectManager>();

        DontDestroyOnLoad(go);
        }
        return Instance;
    }
    #endregion

    public GameObject CreateCharacter()
    {
        Object characterObj = Resources.Load("Sprite/Character");
        GameObject character = (GameObject)Instantiate(characterObj);

        return character;
    }
}