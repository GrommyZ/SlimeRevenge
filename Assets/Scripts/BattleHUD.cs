using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHUD : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public Slider hpSlider;
    public TextMeshProUGUI unitHealth;

    public void SetHUD(UnitBase unit)
    {
        nameText.text = unit.unitName;
        hpSlider.maxValue = unit.maxHealth;
        hpSlider.value = unit.currentHealth;
        unitHealth.text = unit.currentHealth + " / " + unit.maxHealth;
    }
    public void UpdateHP(UnitBase unit)
    {
        hpSlider.value = unit.currentHealth;
        unitHealth.text = unit.currentHealth + " / " + unit.maxHealth;
    }

}
