using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScene : MonoBehaviour
{
    private void Start() 
    {
        GameManager.GetInstance().LoadData();

        UIManager.GetInstance().SetEventSystem();
        UIManager.GetInstance().OpenUI("UIMainMenu");
    }
}
