using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    #region Singletone
    private static BattleManager Instance = null;
    public static BattleManager GetInstance()
    {
        if (Instance == null)
        {
        GameObject go = new GameObject("@BattleManager");
        Instance = go.AddComponent<BattleManager>();

        DontDestroyOnLoad(go);
        }
        return Instance;
    }
    #endregion

    public Monster1 monsterData;

    GameObject uiTab;

    public void BattleStart(Monster1 monster)
    {
        monsterData = monster;

        UIManager.GetInstance().OpenUI("UITab");

        StartCoroutine("BattleProgress");
    }

    IEnumerator BattleProgress()
    {
        while (GameManager.GetInstance().curHp > 0)
        {
            yield return new WaitForSeconds(monsterData.delay);

            int damage = monsterData.atk;
            GameManager.GetInstance().SetHP(-damage);
            GameObject ui = UIManager.GetInstance().GetUI("UIProfile");
            if (ui != null) 
            {
                ui.GetComponent<UIProfile>().RefreshState();
            }
            
            Debug.Log($"몬스터가 플레이어에게 공격을 했습니다. 데미지 : {damage} 플레이어 체력 : {GameManager.GetInstance().curHp}");
            
        }

        Lose();
    }

    public void AttckMonster()
    {
        float randX = Random.Range(-1.7f, 1.7f);
        float randY = Random.Range(-1.7f, 1.7f);

        // var particle = ObjectManager.GetInstance().CreateHitEffect(); // var는 리턴값에 있는 형식을 자동으로 치환해 준다. 예를 들어 리턴 값이 숫자면 int 문자면 string으로
        var particle = ObjectPool.GetObject();
        particle.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        particle.transform.localPosition = new Vector3(0 + randX, 0.7f + randY, -0.5f);
        particle.ShootEffect();



        monsterData.hp--;

        if (monsterData.hp <= 0)
        {
            Victory();
        }
    }

    void Victory()
    {
        Debug.Log("전투에서 승리했습니다!");
        StopCoroutine("BattleProgress");
        UIManager.GetInstance().CloseUI("UITab");

        GameManager.GetInstance().AddGold(monsterData.gold);
        Invoke("MoveToMain", 2.5f);
    }

    void Lose()
    {
        Debug.Log("전투에서 패배했습니다.");
        UIManager.GetInstance().CloseUI("UITab");

        if (GameManager.GetInstance().SpendAddGold(500))
        {
            GameManager.GetInstance().SetHP(80);
        }
        else
        GameManager.GetInstance().SetHP(10);

        Invoke("MoveToMain", 2.5f);
    }

    void MoveToMain()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }
}
