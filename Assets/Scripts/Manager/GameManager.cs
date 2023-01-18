using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singletone
    private static GameManager Instance = null;
    public static GameManager GetInstance()
    {
        if (Instance == null)
        {
            GameObject go = new GameObject("@GameManager");
            Instance = go.AddComponent<GameManager>();

            DontDestroyOnLoad(go);
        }
        return Instance;
    }
    #endregion

    public Player curPlayer;

    public int characterIdx = 0; // 0 - skull 1 - blackNight

    public Player[] players = {
        new Player("Character", 1, 500, 100, 100),
        new Player("Character2", 1, 500, 120, 120),
    };

    ////캐릭터 1
    //public int skullHp = 100;
    //public string skullImg = "Character";
    ////캐릭터 2
    //public int blackNightHp = 120;
    //public string blackNightImg = "Character2";

    public void LoadData()
    {
        curPlayer.playerName = PlayerPrefs.GetString($"playerName_{characterIdx}", "JooWoojae"); // 뒤에오는 인자값은 만약 "playerName"이 null이면 "JooWoojae"를 넣어준다.

        curPlayer.lv = PlayerPrefs.GetInt($"lv_{characterIdx}", 1);
        curPlayer.gold = PlayerPrefs.GetInt($"gold_{characterIdx}", 500);
        curPlayer.totalHp = PlayerPrefs.GetInt($"totalHp_{characterIdx}", 100);
        curPlayer.curHp = PlayerPrefs.GetInt($"curHp_{characterIdx}", 100);
    }

    public void SaveData()
    {
        PlayerPrefs.SetString($"playerName_{characterIdx}", curPlayer.playerName);
        PlayerPrefs.SetInt($"lv_{characterIdx}", curPlayer.lv);
        PlayerPrefs.SetInt($"gold_{characterIdx}", curPlayer.gold);
        PlayerPrefs.SetInt($"totalHp_{characterIdx}", curPlayer.totalHp);
        PlayerPrefs.SetInt($"curHp_{characterIdx}", curPlayer.curHp);
    }
    public void AddGold(int gold)
    {
        curPlayer.gold += gold;
        SaveData();
    }

    public bool SpendAddGold(int gold)
    {
        if (curPlayer.gold >= gold)
        {
            gold -= gold;
            SaveData();
            return true;
        }

        return false;
    }

    public void IncreaseTotalHP(int addHp)
    {
        curPlayer.totalHp += addHp;
        SaveData();
    }

    public void SetHP(int hp)
    {
        curPlayer.curHp += hp;
        if (curPlayer.curHp <= 0)
        {
            curPlayer.curHp = 0;
        }
        if (curPlayer.curHp > curPlayer.totalHp)
        {
            curPlayer.curHp = curPlayer.totalHp;
        }

        // Mathf.Clamp(curPlayer.curHp, 0, 100); //curHp를 0보다는 작지않게 100보다는 커지지 않게 설정하는 코드.
        SaveData();
    }
}
