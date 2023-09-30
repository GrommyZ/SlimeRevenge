using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slime1 : UnitBase
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
        battleSystem.dialogue.text = battleSystem.currentUnit.unitName + " used Skill 1 on " + battleSystem.selectedUnit.unitName + " while healing for 4 health";
        battleSystem.selectedUnit.currentHealth -= 4;
        if (battleSystem.selectedUnit.currentHealth <= 0)
            battleSystem.selectedUnit.currentHealth = 0;
        battleSystem.selectedUnitHUD.UpdateHP(battleSystem.selectedUnit);

        battleSystem.slime1Unit.currentHealth += 4;
        if (battleSystem.slime1Unit.currentHealth >= battleSystem.slime1Unit.maxHealth)
            battleSystem.slime1Unit.currentHealth = battleSystem.slime1Unit.maxHealth;
        battleSystem.slime1HUD.UpdateHP(battleSystem.slime1Unit);

        battleSystem.TargetEnemies.SetActive(false);
        skill1Cooldown = 4;
    }
    public override void Skill2(BattleSystem battleSystemRef)
    {
        battleSystem = battleSystemRef;
        battleSystem.dialogue.text = battleSystem.currentUnit.unitName + " used Skill 2";

        battleSystem.enemy1Unit.isTaunted = true;
        battleSystem.enemy1TauntedIcon.SetActive(true);
        battleSystem.enemy2Unit.isTaunted = true;
        battleSystem.enemy2TauntedIcon.SetActive(true);
        battleSystem.enemy3Unit.isTaunted = true;
        battleSystem.enemy3TauntedIcon.SetActive(true);
        battleSystem.enemy4Unit.isTaunted = true;
        battleSystem.enemy4TauntedIcon.SetActive(true);

        battleSystem.TargetAllEnemies.SetActive(false);
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
        battleSystem.skillsText.text = "Skill 1: Single target attack that deals 4 damage and heals the caster for 4 health (4 turns cooldown)";
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
        battleSystem.skillsText.text = "Skill 2: Taunts all enemies for 1 turn, forcing them to attack the caster with single target attacks (3 turns cooldown)";
        if (skill2Cooldown != 0)
        {
            return;
        }
        else
            battleSystem.TargetAllEnemies.SetActive(true);
    }
}
