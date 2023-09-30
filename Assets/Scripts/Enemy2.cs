using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy2 : UnitBase
{

    public override void BasicAttack(BattleSystem battleSystemRef)
    {
        battleSystem = battleSystemRef;

        if (battleSystem.enemy2Unit.isIgnited == true)
        {
            battleSystem.enemy2Unit.isIgnited = false;
            battleSystem.enemy2IgnitedIcon.SetActive(false);
            battleSystem.enemy2Unit.currentHealth -= 4;
            if (battleSystem.enemy2Unit.currentHealth <= 0)
                battleSystem.enemy2Unit.currentHealth = 0;
            battleSystem.enemy2HUD.UpdateHP(battleSystem.enemy2Unit);
            if (battleSystem.enemy2Unit.currentHealth == 0)
            {
                battleSystem.dialogue.text = battleSystem.currentUnit.unitName + " died from ignite damage!";
                battleSystem.enemy3TargetButton.gameObject.SetActive(false);
                return;
            }

        }
        if (battleSystem.enemy2Unit.isFrozen == true)
        {
            battleSystem.enemy2Unit.isFrozen = false;
            battleSystem.enemy2FrozenIcon.SetActive(false);
            battleSystem.enemy2Unit.isTaunted = false;
            battleSystem.enemy2TauntedIcon.SetActive(false);
            battleSystem.dialogue.text = battleSystem.currentUnit.unitName + " is frozen and cannot act!";
            return;
        }

        if (battleSystem.enemy2Unit.isTaunted == true && battleSystem.slime1Unit.isDead == false)
        {
            battleSystem.enemy2Unit.isTaunted = false;
            battleSystem.enemy2TauntedIcon.SetActive(false);
            battleSystem.selectedUnit = battleSystem.slime1Unit;
            battleSystem.selectedUnitHUD = battleSystem.slime1HUD;
        }

        battleSystem.dialogue.text = battleSystem.currentUnit.unitName + " is attacking " + battleSystem.selectedUnit.unitName;
        battleSystem.selectedUnit.currentHealth -= 11;
        if (battleSystem.selectedUnit.currentHealth <= 0)
            battleSystem.selectedUnit.currentHealth = 0;
        battleSystem.selectedUnitHUD.UpdateHP(battleSystem.selectedUnit);
    }
 
}
