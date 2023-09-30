using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slime3 : UnitBase
{

    public override void BasicAttack(BattleSystem battleSystemRef)
    {
        battleSystem = battleSystemRef;
        battleSystem.dialogue.text = battleSystem.currentUnit.unitName + " used Basic Attack on " + battleSystem.selectedUnit.unitName;
        battleSystem.selectedUnit.currentHealth -= 4;
        if (battleSystem.selectedUnit.currentHealth <= 0)
            battleSystem.selectedUnit.currentHealth = 0;
        battleSystem.selectedUnitHUD.UpdateHP(battleSystem.selectedUnit);
        battleSystem.TargetEnemies.SetActive(false);
    }
    public override void Skill1(BattleSystem battleSystemRef)
    {
        battleSystem = battleSystemRef;
        battleSystem.dialogue.text = battleSystem.currentUnit.unitName + " used Skill 1 on " + battleSystem.selectedUnit.unitName;
        battleSystem.selectedUnit.currentHealth -= 4;
        if (battleSystem.selectedUnit.currentHealth <= 0)
            battleSystem.selectedUnit.currentHealth = 0;
        battleSystem.selectedUnit.isIgnited = true;
        battleSystem.selectedUnitHUD.UpdateHP(battleSystem.selectedUnit);
        battleSystem.TargetEnemies.SetActive(false);
        skill1Cooldown = 2;

        if (battleSystem.selectedUnit.unitName == "Knight")
            battleSystem.enemy1IgnitedIcon.SetActive(true);
        if (battleSystem.selectedUnit.unitName == "Thief")
            battleSystem.enemy2IgnitedIcon.SetActive(true);
        if (battleSystem.selectedUnit.unitName == "Archer")
            battleSystem.enemy3IgnitedIcon.SetActive(true);
        if (battleSystem.selectedUnit.unitName == "Priest")
            battleSystem.enemy4IgnitedIcon.SetActive(true);
    }
    public override void Skill2(BattleSystem battleSystemRef)
    {
        battleSystem = battleSystemRef;
        battleSystem.dialogue.text = battleSystem.currentUnit.unitName + " used Skill 2";

        battleSystem.enemy1Unit.currentHealth -= 2;
        if (battleSystem.enemy1Unit.currentHealth <= 0)
            battleSystem.enemy1Unit.currentHealth = 0;
        battleSystem.enemy2Unit.currentHealth -= 2;
        if (battleSystem.enemy2Unit.currentHealth <= 0)
            battleSystem.enemy2Unit.currentHealth = 0;
        battleSystem.enemy3Unit.currentHealth -= 2;
        if (battleSystem.enemy3Unit.currentHealth <= 0)
            battleSystem.enemy3Unit.currentHealth = 0;
        battleSystem.enemy4Unit.currentHealth -= 2;
        if (battleSystem.enemy4Unit.currentHealth <= 0)
            battleSystem.enemy4Unit.currentHealth = 0;

        battleSystem.enemy1Unit.isIgnited = true;
        battleSystem.enemy1IgnitedIcon.SetActive(true);
        battleSystem.enemy2Unit.isIgnited = true;
        battleSystem.enemy2IgnitedIcon.SetActive(true);
        battleSystem.enemy3Unit.isIgnited = true;
        battleSystem.enemy3IgnitedIcon.SetActive(true);
        battleSystem.enemy4Unit.isIgnited = true;
        battleSystem.enemy4IgnitedIcon.SetActive(true);

        battleSystem.enemy1HUD.UpdateHP(battleSystem.enemy1Unit);
        battleSystem.enemy2HUD.UpdateHP(battleSystem.enemy2Unit);
        battleSystem.enemy3HUD.UpdateHP(battleSystem.enemy3Unit);
        battleSystem.enemy4HUD.UpdateHP(battleSystem.enemy4Unit);

        battleSystem.TargetAllEnemies.SetActive(false);
        skill2Cooldown = 4;
    }
    public override void BasicAttackTarget(BattleSystem battleSystemRef)
    {
        battleSystem = battleSystemRef;
        battleSystem.skillsText.text = "Basic Attack: Single target attack that deals 4 damage";
        battleSystem.TargetEnemies.SetActive(true);
    }
    public override void Skill1Targets(BattleSystem battleSystemRef)
    {
        battleSystem = battleSystemRef;
        battleSystem.skillsText.text = "Skill 1: Single target attack that deals 4 damage and applies ignite for 1 turn, ignited enemies take 4 damage at the start of their turn (2 turns cooldown)";
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
        battleSystem.skillsText.text = "Skill 2: Attack all enemies for 2 damage and ignites them for 1 turn, ignited enemies take 4 damage at the start of their turn (4 turns cooldown)";
        if (skill2Cooldown != 0)
        {
            return;
        }
        else
            battleSystem.TargetAllEnemies.SetActive(true);
    }
}
