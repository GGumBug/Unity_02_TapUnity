using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIMainMenu : MonoBehaviour
{
    public Button[] btnStart;
    void Start()
    {
        btnStart = GetComponentsInChildren<Button>();

        btnStart[0].onClick.AddListener(OnClickStart);
        btnStart[1].onClick.AddListener(OnClickStart2);
    }

    void OnClickStart()
    {
        GameManager.GetInstance().characterIdx = 0;
        SetPlayer();
        GameManager.GetInstance().SaveData();
        ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }

    void OnClickStart2()
    {
        GameManager.GetInstance().characterIdx = 1;
        SetPlayer();
        GameManager.GetInstance().SaveData();
        ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }

    void SetPlayer()
    {
        int characterIdx = GameManager.GetInstance().characterIdx;
        GameManager.GetInstance().curPlayer = GameManager.GetInstance().players[characterIdx]; // Player curPlayer = Player players[0] 을 하면 클래스의 내부의 변수가 복사되어 들어간다.
    }
}
