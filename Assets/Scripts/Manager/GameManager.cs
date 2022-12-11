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

    public void AddGold(int gold)
    {
        this.gold += gold;
    }

    public bool SpendAddGold(int gold)
    {
        if (this.gold >= gold)
        {
            this.gold -= gold;
            return true;
        }

        return false;
    }

    public void IncreaseTotalHP(int addHp)
    {
        totalHp += addHp;
    }

    public void SetHP(int hp)
    {
        curHp += hp;
        Mathf.Clamp(curHp, 0 ,100); //curHp를 0보다는 작지않게 100보다는 커지지 않게 설정하는 코드.
    }
}
