using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITab : MonoBehaviour
{
    public Button btnTab;

    private void Start() {
        btnTab = GetComponentInChildren<Button>();
        btnTab.onClick.AddListener(OnTab);
    }

    void OnTab()
    {
        BattleManager.GetInstance().AttckMonster();
        Debug.Log("공격");
    }
}
