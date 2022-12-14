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

    public string playerName = "JooWoojae";
    public int lv = 1;
    public int gold = 500;
    public int totalHp = 100;
    public int curHp = 100;

    public void LoadData()
    {
        playerName = PlayerPrefs.GetString("playerName", "JooWoojae"); // 뒤에오는 인자값은 만약 "playerName"이 null이면 "JooWoojae"를 넣어준다.

        lv = PlayerPrefs.GetInt("lv", 1);
        gold = PlayerPrefs.GetInt("gold", 500);
        totalHp = PlayerPrefs.GetInt("totalHp", 100);
        curHp = PlayerPrefs.GetInt("curHp", 100);
    }

    public void SaveData()
    {
        PlayerPrefs.SetString("playerName", playerName);
        PlayerPrefs.SetInt("lv", lv);
        PlayerPrefs.SetInt("gold", gold);
        PlayerPrefs.SetInt("totalHp", totalHp);
        PlayerPrefs.SetInt("curHp", curHp);
    }
    public void AddGold(int gold)
    {
        this.gold += gold;
        SaveData();
    }

    public bool SpendAddGold(int gold)
    {
        if (this.gold >= gold)
        {
            this.gold -= gold;
            SaveData();
            return true;
        }

        return false;
    }

    public void IncreaseTotalHP(int addHp)
    {
        totalHp += addHp;
        SaveData();
    }

    public void SetHP(int hp)
    {
        curHp += hp;
        Mathf.Clamp(curHp, 0 ,100); //curHp를 0보다는 작지않게 100보다는 커지지 않게 설정하는 코드.
    }
}
