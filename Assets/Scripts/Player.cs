using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string playerName;
    public int lv;
    public int gold;
    public int totalHp;
    public int curHp;

    public Player(string playerName, int lv, int gold, int totalHp, int curHp)
    {
        this.playerName = playerName;
        this.lv = lv;
        this.gold = gold;
        this.totalHp = totalHp;
        this.curHp = curHp;
    }
}
