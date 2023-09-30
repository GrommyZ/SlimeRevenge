using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slime2 : UnitBase
{

    public override void BasicAttack(BattleSystem battleSystemRef)
    {
        battleSystem = battleSystemRef;

        int applyFreeze = Random.Range(1, 101);
        if (applyFreeze <= 35)
        {
            battleSystem.dialogue.text = battleSystem.currentUnit.unitName + " used Basic Attack on and froze " + battleSystem.selectedUnit.unitName;
            battleSystem.selectedUnit.currentHealth -= 3;
            if (battleSystem.selectedUnit.currentHealth <= 0)
                battleSystem.selectedUnit.currentHealth = 0;
            battleSystem.selectedUnitHUD.UpdateHP(battleSystem.selectedUnit);
            battleSystem.selectedUnit.isFrozen = true;
            battleSystem.TargetEnemies.SetActive(false);

            if (battleSystem.selectedUnit.unitName == "Knight")
                battleSystem.enemy1FrozenIcon.SetActive(true);
            if (battleSystem.selectedUnit.unitName == "Thief")
                battleSystem.enemy2FrozenIcon.SetActive(true);
            if (battleSystem.selectedUnit.unitName == "Archer")
                battleSystem.enemy3FrozenIcon.SetActive(true);
            if (battleSystem.selectedUnit.unitName == "Priest")
                battleSystem.enemy4FrozenIcon.SetActive(true);
        }
        else
        {
            battleSystem.dialogue.text = battleSystem.currentUnit.unitName + " used Basic Attack on " + battleSystem.selectedUnit.unitName;
            battleSystem.selectedUnit.currentHealth -= 3;
            if (battleSystem.selectedUnit.currentHealth <= 0)
                battleSystem.selectedUnit.currentHealth = 0;
            battleSystem.selectedUnitHUD.UpdateHP(battleSystem.selectedUnit);
            battleSystem.TargetEnemies.SetActive(false);
        }
    }
    public override void Skill1(BattleSystem battleSystemRef)
    {
        battleSystem = battleSystemRef;
        battleSystem.dialogue.text = battleSystem.currentUnit.unitName + " used Skill 1 on " + battleSystem.selectedUnit.unitName;
        battleSystem.selectedUnit.currentHealth -= 6;
        if (battleSystem.selectedUnit.currentHealth <= 0)
            battleSystem.selectedUnit.currentHealth = 0;
        battleSystem.selectedUnitHUD.UpdateHP(battleSystem.selectedUnit);
        battleSystem.TargetEnemies.SetActive(false);
        skill1Cooldown = 2;
    }
    public override void Skill2(BattleSystem battleSystemRef)
    {
        battleSystem = battleSystemRef;
        battleSystem.dialogue.text = battleSystem.currentUnit.unitName + " used Skill 2 on " + battleSystem.selectedUnit.unitName;
        battleSystem.selectedUnit.currentHealth -= 3;
        if (battleSystem.selectedUnit.currentHealth <= 0)
            battleSystem.selectedUnit.currentHealth = 0;
        battleSystem.selectedUnitHUD.UpdateHP(battleSystem.selectedUnit);
        battleSystem.selectedUnit.isFrozen = true;
        battleSystem.TargetEnemies.SetActive(false);
        skill2Cooldown = 3;

        if (battleSystem.selectedUnit.unitName == "Knight")
            battleSystem.enemy1FrozenIcon.SetActive(true);
        if (battleSystem.selectedUnit.unitName == "Thief")
            battleSystem.enemy2FrozenIcon.SetActive(true);
        if (battleSystem.selectedUnit.unitName == "Archer")
            battleSystem.enemy3FrozenIcon.SetActive(true);
        if (battleSystem.selectedUnit.unitName == "Priest")
            battleSystem.enemy4FrozenIcon.SetActive(true);
    }
    public override void BasicAttackTarget(BattleSystem battleSystemRef)
    {
        battleSystem = battleSystemRef;
        battleSystem.skillsText.text = "Basic Attack: Single target attack that deals 3 damage with a 35% chance to freeze the target for 1 turn, frozen units cannot act during their turn";
        battleSystem.TargetEnemies.SetActive(true);
    }
    public override void Skill1Targets(BattleSystem battleSystemRef)
    {
        battleSystem = battleSystemRef;
        battleSystem.skillsText.text = "Skill 1: Attack a single enemy, dealing 6 damage to the target (2 turns cooldown)";
        if (skill1Cooldown != 0)
        {
            return;
        }
        else
            battleSystem.TargetEnemies.SetActive(true);
    }
    public override void Skill2Targets(BattleSystem battleSystemRef)
    {
        battleSystem = battleSystemRef;
        battleSystem.skillsText.text = "Skill 2: Single target attack that deals 3 damage and freezes the target for 1 turn, frozen units cannot act during their turn (3 turns cooldown)";
        if (skill2Cooldown != 0)
        {
            return;
        }
        else
            battleSystem.TargetEnemies.SetActive(true);
    }
}
