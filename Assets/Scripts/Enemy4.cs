using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy4 : UnitBase
{

    public override void BasicAttack(BattleSystem battleSystemRef)
    {
        battleSystem = battleSystemRef;

        if (battleSystem.enemy4Unit.isIgnited == true)
        {
            battleSystem.enemy4Unit.isIgnited = false;
            battleSystem.enemy4IgnitedIcon.SetActive(false);
            battleSystem.enemy4Unit.currentHealth -= 4;
            if (battleSystem.enemy4Unit.currentHealth <= 0)
                battleSystem.enemy4Unit.currentHealth = 0;
            battleSystem.enemy4HUD.UpdateHP(battleSystem.enemy4Unit);
            if (battleSystem.enemy4Unit.currentHealth == 0)
            {
                battleSystem.dialogue.text = battleSystem.currentUnit.unitName + " died from ignite damage!";
                battleSystem.enemy1TargetButton.gameObject.SetActive(false);
                return;
            }

        }
        if (battleSystem.enemy4Unit.isFrozen == true)
        {
            battleSystem.enemy4Unit.isFrozen = false;
            battleSystem.enemy4FrozenIcon.SetActive(false);
            battleSystem.enemy4Unit.isTaunted = false;
            battleSystem.enemy4TauntedIcon.SetActive(false);
            battleSystem.dialogue.text = battleSystem.currentUnit.unitName + " is frozen and cannot act!";
            return;
        }

        if ((battleSystem.enemy4Unit.isTaunted == false) && (((battleSystem.enemy1Unit.currentHealth != battleSystem.enemy1Unit.maxHealth) && (battleSystem.enemy1Unit.isDead == false)) || ((battleSystem.enemy2Unit.currentHealth != battleSystem.enemy2Unit.maxHealth) && (battleSystem.enemy2Unit.isDead == false)) || ((battleSystem.enemy3Unit.currentHealth != battleSystem.enemy3Unit.maxHealth) && (battleSystem.enemy3Unit.isDead == false)) || ((battleSystem.enemy4Unit.currentHealth != battleSystem.enemy4Unit.maxHealth) && (battleSystem.enemy4Unit.isDead == false))))
        {
            if ((battleSystem.enemy2Unit.isDead == false) && (battleSystem.enemy2Unit.currentHealth != battleSystem.enemy2Unit.maxHealth) && (battleSystem.enemy2Unit.currentHealth <= battleSystem.enemy3Unit.currentHealth) && (battleSystem.enemy2Unit.currentHealth <= battleSystem.enemy4Unit.currentHealth) && (battleSystem.enemy2Unit.currentHealth <= battleSystem.enemy1Unit.currentHealth))
            {
                battleSystem.enemy2Unit.currentHealth += 6;
                if (battleSystem.enemy2Unit.currentHealth > battleSystem.enemy2Unit.maxHealth)
                    battleSystem.enemy2Unit.currentHealth = battleSystem.enemy2Unit.maxHealth;
                battleSystem.enemy2HUD.UpdateHP(battleSystem.enemy2Unit);
                battleSystem.dialogue.text = battleSystem.currentUnit.unitName + " healed " + battleSystem.enemy2Unit.unitName;
            }
            else if ((battleSystem.enemy3Unit.isDead == false) && (battleSystem.enemy3Unit.currentHealth != battleSystem.enemy3Unit.maxHealth) && (battleSystem.enemy3Unit.currentHealth <= battleSystem.enemy4Unit.currentHealth) && (battleSystem.enemy3Unit.currentHealth <= battleSystem.enemy1Unit.currentHealth))
            {
                battleSystem.enemy3Unit.currentHealth += 6;
                if (battleSystem.enemy3Unit.currentHealth > battleSystem.enemy3Unit.maxHealth)
                    battleSystem.enemy3Unit.currentHealth = battleSystem.enemy3Unit.maxHealth;
                battleSystem.enemy3HUD.UpdateHP(battleSystem.enemy3Unit);
                battleSystem.dialogue.text = battleSystem.currentUnit.unitName + " healed " + battleSystem.enemy3Unit.unitName;
            }
            else if ((battleSystem.enemy4Unit.isDead == false) && (battleSystem.enemy4Unit.currentHealth != battleSystem.enemy4Unit.maxHealth) && (battleSystem.enemy4Unit.currentHealth <= battleSystem.enemy1Unit.currentHealth))
            {
                battleSystem.enemy4Unit.currentHealth += 6;
                if (battleSystem.enemy4Unit.currentHealth > battleSystem.enemy4Unit.maxHealth)
                    battleSystem.enemy4Unit.currentHealth = battleSystem.enemy4Unit.maxHealth;
                battleSystem.enemy4HUD.UpdateHP(battleSystem.enemy4Unit);
                battleSystem.dialogue.text = battleSystem.currentUnit.unitName + " healed themselves";
            }
            else if ((battleSystem.enemy1Unit.isDead == false) && (battleSystem.enemy1Unit.currentHealth != battleSystem.enemy1Unit.maxHealth))
            {
                battleSystem.enemy1Unit.currentHealth += 6;
                if (battleSystem.enemy1Unit.currentHealth > battleSystem.enemy1Unit.maxHealth)
                    battleSystem.enemy1Unit.currentHealth = battleSystem.enemy1Unit.maxHealth;
                battleSystem.enemy1HUD.UpdateHP(battleSystem.enemy1Unit);
                battleSystem.dialogue.text = battleSystem.currentUnit.unitName + " healed " + battleSystem.enemy1Unit.unitName;
            }
        }
        else
        {
            if (battleSystem.enemy4Unit.isTaunted == true && battleSystem.slime1Unit.isDead == false)
            {
                battleSystem.enemy4Unit.isTaunted = false;
                battleSystem.enemy4TauntedIcon.SetActive(false);
                battleSystem.selectedUnit = battleSystem.slime1Unit;
                battleSystem.selectedUnitHUD = battleSystem.slime1HUD;
            }

            battleSystem.dialogue.text = battleSystem.currentUnit.unitName + " is attacking " + battleSystem.selectedUnit.unitName;
            battleSystem.selectedUnit.currentHealth -= 4;
            if (battleSystem.selectedUnit.currentHealth <= 0)
                battleSystem.selectedUnit.currentHealth = 0;
            battleSystem.selectedUnitHUD.UpdateHP(battleSystem.selectedUnit);
        }
    }
 
}
