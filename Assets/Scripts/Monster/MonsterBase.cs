using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterBase
{
    public string monsterName;

    // Getter
    //public string GetMonsterName()
    //{
    //    return monsterName;
    //}

    // Setter
    //public void SetMonsterName(string name)
    //{
    //    monsterName = name;
    //}

    // 축약
    //public string MonsterName { get; set; }


    public int atk;
    public int hp;

    public float delay;

    public int gold;

    


    // 3가지 방법
    // 1. virtual
    //public virtual void Attack()
    //{
    //    Debug.Log("공격합니다.");
    //}

    // 2. abstract
    public abstract void Attack();
}
