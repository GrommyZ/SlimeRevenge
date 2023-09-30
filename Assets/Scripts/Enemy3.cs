using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy3 : UnitBase
{

    public override void BasicAttack(BattleSystem battleSystemRef)
    {
        battleSystem = battleSystemRef;

        if (battleSystem.enemy3Unit.isIgnited == true)
        {
            battleSystem.enemy3Unit.isIgnited = false;
            battleSystem.enemy3IgnitedIcon.SetActive(false);
            battleSystem.enemy3Unit.currentHealth -= 4;
            if (battleSystem.enemy3Unit.currentHealth <= 0)
                battleSystem.enemy3Unit.currentHealth = 0;
            battleSystem.enemy3HUD.UpdateHP(battleSystem.enemy3Unit);
            if (battleSystem.enemy3Unit.currentHealth == 0)
            {
                battleSystem.dialogue.text = battleSystem.currentUnit.unitName + " died from ignite damage!";
                battleSystem.enemy2TargetButton.gameObject.SetActive(false);
                return;
            }

        }
        if (battleSystem.enemy3Unit.isFrozen == true)
        {
            battleSystem.enemy3Unit.isFrozen = false;
            battleSystem.enemy3FrozenIcon.SetActive(false);
            battleSystem.enemy3Unit.isTaunted = false;
            battleSystem.enemy3TauntedIcon.SetActive(false);
            battleSystem.dialogue.text = battleSystem.currentUnit.unitName + " is frozen and cannot act!";
            return;
        }

        if (battleSystem.enemy3Unit.isTaunted == true && battleSystem.slime1Unit.isDead == false)
        {
            battleSystem.enemy3Unit.isTaunted = false;
            battleSystem.enemy3TauntedIcon.SetActive(false);
            battleSystem.selectedUnit = battleSystem.slime1Unit;
            battleSystem.selectedUnitHUD = battleSystem.slime1HUD;

            battleSystem.dialogue.text = battleSystem.currentUnit.unitName + " is attacking " + battleSystem.selectedUnit.unitName;
            battleSystem.selectedUnit.currentHealth -= 10;
            if (battleSystem.selectedUnit.currentHealth <= 0)
                battleSystem.selectedUnit.currentHealth = 0;
            battleSystem.selectedUnitHUD.UpdateHP(battleSystem.selectedUnit);
            return;
        }

        battleSystem.dialogue.text = battleSystem.currentUnit.unitName + " is attacking ";

        battleSystem.slime1Unit.currentHealth -= 5;
        if (battleSystem.slime1Unit.currentHealth <= 0)
            battleSystem.slime1Unit.currentHealth = 0;
        battleSystem.slime2Unit.currentHealth -= 5;
        if (battleSystem.slime2Unit.currentHealth <= 0)
            battleSystem.slime2Unit.currentHealth = 0;
        battleSystem.slime3Unit.currentHealth -= 5;
        if (battleSystem.slime3Unit.currentHealth <= 0)
            battleSystem.slime3Unit.currentHealth = 0;
        battleSystem.slime4Unit.currentHealth -= 5;
        if (battleSystem.slime4Unit.currentHealth <= 0)
            battleSystem.slime4Unit.currentHealth = 0;

        battleSystem.slime1HUD.UpdateHP(battleSystem.slime1Unit);
        battleSystem.slime2HUD.UpdateHP(battleSystem.slime2Unit);
        battleSystem.slime3HUD.UpdateHP(battleSystem.slime3Unit);
        battleSystem.slime4HUD.UpdateHP(battleSystem.slime4Unit);
    }
 
}
