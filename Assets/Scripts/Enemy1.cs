using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy1 : UnitBase
{

    public override void BasicAttack(BattleSystem battleSystemRef)
    {
        battleSystem = battleSystemRef;

        if (battleSystem.enemy1Unit.isIgnited == true)
        {
            battleSystem.enemy1Unit.isIgnited = false;
            battleSystem.enemy1IgnitedIcon.SetActive(false);
            battleSystem.enemy1Unit.currentHealth -= 4;
            if (battleSystem.enemy1Unit.currentHealth <= 0)
                battleSystem.enemy1Unit.currentHealth = 0;
            battleSystem.enemy1HUD.UpdateHP(battleSystem.enemy1Unit);
            if(battleSystem.enemy1Unit.currentHealth == 0)
            {
                battleSystem.dialogue.text = battleSystem.currentUnit.unitName + " died from ignite damage!";
                battleSystem.enemy4TargetButton.gameObject.SetActive(false);
                return;
            }

        }
        if (battleSystem.enemy1Unit.isFrozen == true)
        {
            battleSystem.enemy1Unit.isFrozen = false;
            battleSystem.enemy1FrozenIcon.SetActive(false);
            battleSystem.enemy1Unit.isTaunted = false;
            battleSystem.enemy1TauntedIcon.SetActive(false);
            battleSystem.dialogue.text = battleSystem.currentUnit.unitName + " is frozen and cannot act!";
            return;
        }

        if (battleSystem.enemy1Unit.isTaunted == true && battleSystem.slime1Unit.isDead == false)
        {
            battleSystem.enemy1Unit.isTaunted = false;
            battleSystem.enemy1TauntedIcon.SetActive(false);
            battleSystem.selectedUnit = battleSystem.slime1Unit;
            battleSystem.selectedUnitHUD = battleSystem.slime1HUD;
        }

        battleSystem.dialogue.text = battleSystem.currentUnit.unitName + " is attacking " + battleSystem.selectedUnit.unitName + " and healing allies";
        battleSystem.selectedUnit.currentHealth -= 4;
        if (battleSystem.selectedUnit.currentHealth <= 0)
            battleSystem.selectedUnit.currentHealth = 0;
        battleSystem.selectedUnitHUD.UpdateHP(battleSystem.selectedUnit);

        if (battleSystem.enemy1Unit.isDead == false)
        {
            battleSystem.enemy1Unit.currentHealth += 1;
            if (battleSystem.enemy1Unit.currentHealth > battleSystem.enemy1Unit.maxHealth)
                battleSystem.enemy1Unit.currentHealth = battleSystem.enemy1Unit.maxHealth;
            battleSystem.enemy1HUD.UpdateHP(battleSystem.enemy1Unit);
        }
        if (battleSystem.enemy2Unit.isDead == false)
        {
            battleSystem.enemy2Unit.currentHealth += 1;
            if (battleSystem.enemy2Unit.currentHealth > battleSystem.enemy2Unit.maxHealth)
                battleSystem.enemy2Unit.currentHealth = battleSystem.enemy2Unit.maxHealth;
            battleSystem.enemy2HUD.UpdateHP(battleSystem.enemy2Unit);
        }
        if (battleSystem.enemy3Unit.isDead == false)
        {
            battleSystem.enemy3Unit.currentHealth += 1;
            if (battleSystem.enemy3Unit.currentHealth > battleSystem.enemy3Unit.maxHealth)
                battleSystem.enemy3Unit.currentHealth = battleSystem.enemy3Unit.maxHealth;
            battleSystem.enemy3HUD.UpdateHP(battleSystem.enemy3Unit);
        }
        if (battleSystem.enemy4Unit.isDead == false)
        {
            battleSystem.enemy4Unit.currentHealth += 1;
            if (battleSystem.enemy4Unit.currentHealth > battleSystem.enemy4Unit.maxHealth)
                battleSystem.enemy4Unit.currentHealth = battleSystem.enemy4Unit.maxHealth;
            battleSystem.enemy4HUD.UpdateHP(battleSystem.enemy4Unit);
        }
    }
 
}
