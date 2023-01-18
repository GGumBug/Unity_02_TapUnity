using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster3 : MonsterBase
{
    public Monster3(string name, int atk, int hp, float delay, int gold)
    {
        monsterName = name;
        this.atk = atk;
        this.hp = hp;
        this.delay = delay;
        this.gold = gold;
    }

    private int attackCount = 2;

    public override void Attack()
    {
        GameManager.GetInstance().SetHP(-atk);
        GameManager.GetInstance().SetHP(-atk);
        Debug.Log($"몬스터가 플레이어에게 공격을 했습니다. 데미지 : {atk} 플레이어 체력 : {GameManager.GetInstance().curPlayer.curHp}");
        Debug.Log($"몬스터가 플레이어에게 공격을 했습니다. 데미지 : {atk} 플레이어 체력 : {GameManager.GetInstance().curPlayer.curHp}");
    }
}
