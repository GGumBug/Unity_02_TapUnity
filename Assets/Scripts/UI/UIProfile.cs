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
        txtLv.text = $"Lv. {GameManager.GetInstance().lv}";
        txtName.text = $"{GameManager.GetInstance().playerName}";
        txtGlod.text = $"{GameManager.GetInstance().gold}G";

        hpBar.value = GameManager.GetInstance().curHp;
        hpBar.maxValue = GameManager.GetInstance().totalHp;

        txtHp.text = $"{hpBar.value} / {hpBar.maxValue}";
    }
}
