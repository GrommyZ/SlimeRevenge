using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slime4 : UnitBase
{

    public override void BasicAttack(BattleSystem battleSystemRef)
    {
        battleSystem = battleSystemRef;
        battleSystem.dialogue.text = battleSystem.currentUnit.unitName + " used Basic Attack on " + battleSystem.selectedUnit.unitName;
        battleSystem.selectedUnit.currentHealth -= 3;
        if (battleSystem.selectedUnit.currentHealth <= 0)
            battleSystem.selectedUnit.currentHealth = 0;
        battleSystem.selectedUnitHUD.UpdateHP(battleSystem.selectedUnit);
        battleSystem.TargetEnemies.SetActive(false);
    }
    public override void Skill1(BattleSystem battleSystemRef)
    {
        battleSystem = battleSystemRef;

        if (battleSystem.selectedUnit.unitName == "Water Slime")
            battleSystem.dialogue.text = battleSystem.currentUnit.unitName + " used Skill 1 on themselves";
        else
            battleSystem.dialogue.text = battleSystem.currentUnit.unitName + " used Skill 1 on " + battleSystem.selectedUnit.unitName;

        battleSystem.selectedUnit.currentHealth += 5;
        if (battleSystem.selectedUnit.currentHealth >= battleSystem.selectedUnit.maxHealth)
            battleSystem.selectedUnit.currentHealth = battleSystem.currentUnit.maxHealth;

        battleSystem.selectedUnitHUD.UpdateHP(battleSystem.selectedUnit);
        battleSystem.TargetAllies.SetActive(false);
        skill1Cooldown = 2;
    }
    public override void Skill2(BattleSystem battleSystemRef)
    {
        battleSystem = battleSystemRef;
        battleSystem.dialogue.text = battleSystem.currentUnit.unitName + " used Skill 2";

        if (battleSystem.slime1Unit.isDead == false)
        {
            battleSystem.slime1Unit.currentHealth += 2;
            if (battleSystem.slime1Unit.currentHealth >= battleSystem.slime1Unit.maxHealth)
                battleSystem.slime1Unit.currentHealth = battleSystem.slime1Unit.maxHealth;
        }
        if (battleSystem.slime2Unit.isDead == false)
        {
            battleSystem.slime2Unit.currentHealth += 2;
            if (battleSystem.slime2Unit.currentHealth >= battleSystem.slime2Unit.maxHealth)
                battleSystem.slime2Unit.currentHealth = battleSystem.slime2Unit.maxHealth;
        }
        if (battleSystem.slime3Unit.isDead == false)
        {
            battleSystem.slime3Unit.currentHealth += 2;
            if (battleSystem.slime3Unit.currentHealth >= battleSystem.slime3Unit.maxHealth)
                battleSystem.slime3Unit.currentHealth = battleSystem.slime3Unit.maxHealth;
        }
        if (battleSystem.slime4Unit.isDead == false)
        {
            battleSystem.slime4Unit.currentHealth += 2;
            if (battleSystem.slime4Unit.currentHealth >= battleSystem.slime4Unit.maxHealth)
                battleSystem.slime4Unit.currentHealth = battleSystem.slime4Unit.maxHealth;
        }

        battleSystem.slime1HUD.UpdateHP(battleSystem.slime1Unit);
        battleSystem.slime2HUD.UpdateHP(battleSystem.slime2Unit);
        battleSystem.slime3HUD.UpdateHP(battleSystem.slime3Unit);
        battleSystem.slime4HUD.UpdateHP(battleSystem.slime4Unit);
        battleSystem.TargetAllAllies.SetActive(false);
        skill2Cooldown = 3;
    }
    public override void BasicAttackTarget(BattleSystem battleSystemRef)
    {
        battleSystem = battleSystemRef;
        battleSystem.skillsText.text = "Basic Attack: Single target attack that deals 3 damage";
        battleSystem.TargetEnemies.SetActive(true);
    }
    public override void Skill1Targets(BattleSystem battleSystemRef)
    {
        battleSystem = battleSystemRef;
        battleSystem.skillsText.text = "Skill 1: Heal a single ally for 5 health (2 turns cooldown)";
        if (skill1Cooldown != 0)
        {
            return;
        }
        else
            battleSystem.TargetAllies.SetActive(true);
    }
    public override void Skill2Targets(BattleSystem battleSystemRef)
    {
        battleSystem = battleSystemRef;
        battleSystem.skillsText.text = "Skill 2: Heal all allies for 2 health (3 turns cooldown)";
        if (skill2Cooldown != 0)
        {
            return;
        }
        else
            battleSystem.TargetAllAllies.SetActive(true);
    }
}
