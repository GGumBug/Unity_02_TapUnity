using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    void Start()
    {
        GameManager.GetInstance().LoadData();
        UIManager.GetInstance().SetEventSystem();
        GetCharcter();
        UIManager.GetInstance().OpenUI("UIProfile");
        UIManager.GetInstance().OpenUI("UIActionMenu");
    }

    public void GetCharcter()
    {
        string characterName = GameManager.GetInstance().curPlayer.playerName;

        GameObject go = ObjectManager.GetInstance().CreateCharacter(characterName);
        go.transform.localScale = new Vector3(2, 2, 2);
        go.transform.localPosition = new Vector3(0, 1.1f, 0);
    }

}
