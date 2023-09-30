using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnitBase : MonoBehaviour
{
    public GameObject unitPrefab;
    public Transform unitSpawn;
    public bool isEnemy;
    public bool isDead;
    public string unitName;
    public BattleHUD unitHUD;
    public int currentHealth;
    public int maxHealth;
    public int speed;
    public int damage;
    public int turnProgress;
    public int skill1Cooldown = 0;
    public int skill2Cooldown = 0;
    public BattleSystem battleSystem;
    public bool isIgnited;
    public bool isFrozen;
    public bool isTaunted;

    public virtual void BasicAttack(BattleSystem battleSystemRef)
    {
        // Placeholder for Basic Attack
    }
    public virtual void Skill1(BattleSystem battleSystemRef)
    {
        // Placeholder for Skill 1
    }

    public virtual void Skill2(BattleSystem battleSystemRef)
    {
        // Placeholder for Skill 2
    }
    public virtual void BasicAttackTarget(BattleSystem battleSystemRef)
    {
        // Placeholder for Basic Attack targeting
    }
    public virtual void Skill1Targets(BattleSystem battleSystemRef)
    {
        // Placeholder for Skill 1 targeting
    }

    public virtual void Skill2Targets(BattleSystem battleSystemRef)
    {
        // Placeholder for Skill 2 targeting
    }
}
