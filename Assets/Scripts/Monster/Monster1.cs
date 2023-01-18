using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class 는 참조
// struct 는 값 타입이기때문에 함수가 끝나도 값에 저장이 안된다.

public class Monster1 : MonsterBase
{

    public Monster1(string name, int atk, int hp, float delay, int gold)
    {
        monsterName = name;
        this.atk = atk;
        this.hp = hp;
        this.delay = delay;
        this.gold = gold;
    }

    public override void Attack()
    {
        GameManager.GetInstance().SetHP(-atk);
        Debug.Log($"몬스터가 플레이어에게 공격을 했습니다. 데미지 : {atk} 플레이어 체력 : {GameManager.GetInstance().curPlayer.curHp}");
    }
}
