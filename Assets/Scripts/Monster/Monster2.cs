using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2 : MonsterBase
{
    public Monster2(string name, int atk, int hp, float delay, int gold)
    {
        monsterName = name;
        this.atk = atk;
        this.hp = hp;
        this.delay = delay;
        this.gold = gold;
    }

    //public
    //protacted
    //private


    public float critical = 10f;

    public override void Attack()
    {
        float criticalRate = Random.Range(0, 100.0f);

        int damege = atk;
        if (criticalRate < critical)
        {
            damege *= 2;
        }

        GameManager.GetInstance().SetHP(-atk);
        Debug.Log($"몬스터가 플레이어에게 공격을 했습니다. 데미지 : {damege} 플레이어 체력 : {GameManager.GetInstance().curPlayer.curHp}");
    }
}
