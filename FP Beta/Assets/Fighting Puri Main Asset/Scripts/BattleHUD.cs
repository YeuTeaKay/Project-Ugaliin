using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHUD : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text levelText;
    public Slider hpSlider;

    public void SetHUD(Unit unitChar)
    {
        nameText.text = unitChar.unitName;
        levelText.text = "Level " + unitChar.unitLevel;

        hpSlider.maxValue =unitChar.maxHP;
        hpSlider.value = unitChar.currentHP;

    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
    }
}
