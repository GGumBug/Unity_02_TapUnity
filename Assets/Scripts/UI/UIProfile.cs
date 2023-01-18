using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIProfile : MonoBehaviour
{
    public Slider hpBar;
    public Image imgFill;

    public TMP_Text txtHp;
    public TMP_Text txtLv;
    public TMP_Text txtName;
    public TMP_Text txtGlod;

    void Start()
    {
        RefreshState();
    }

    public void RefreshState()
    {
        txtLv.text = $"Lv. {GameManager.GetInstance().curPlayer.lv}";
        txtName.text = $"{GameManager.GetInstance().curPlayer.playerName}";
        txtGlod.text = $"{GameManager.GetInstance().curPlayer.gold}G";

        hpBar.maxValue = GameManager.GetInstance().curPlayer.totalHp; 
        hpBar.value = GameManager.GetInstance().curPlayer.curHp;        

        txtHp.text = $"{hpBar.value} / {hpBar.maxValue}";
        GameManager.GetInstance().SaveData();
    }
}
