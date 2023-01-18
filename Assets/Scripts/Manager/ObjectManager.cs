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

    public GameObject CreateCharacter(string characterName)
    {
        Object characterObj = Resources.Load("Sprite/"+characterName);
        GameObject character = (GameObject)Instantiate(characterObj);

        return character;
    }

    public GameObject CreateMonster(string monsterName)
    {
        Debug.Log(monsterName);

        Object monsterObj = Resources.Load("Sprite/" + monsterName);
        GameObject Monster1 = (GameObject)Instantiate(monsterObj);

        return Monster1;
    }

    public ParticleSystem CreateHitEffect()
    {
        Object hitObj = Resources.Load("Effect/Hit");
        GameObject effect = (GameObject)Instantiate(hitObj);

        return effect.GetComponent<ParticleSystem>();
    }
}
