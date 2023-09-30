using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public GameObject wonUI;
    public GameObject lostUI;
    public TextMeshProUGUI dialogue;
    public TextMeshProUGUI skillsText;

    public GameObject slime1Prefab;
    public GameObject slime2Prefab;
    public GameObject slime3Prefab;
    public GameObject slime4Prefab;
    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;
    public GameObject enemy3Prefab;
    public GameObject enemy4Prefab;

    public GameObject enemy1TauntedIcon;
    public GameObject enemy1FrozenIcon;
    public GameObject enemy1IgnitedIcon;
    public GameObject enemy2TauntedIcon;
    public GameObject enemy2FrozenIcon;
    public GameObject enemy2IgnitedIcon;
    public GameObject enemy3TauntedIcon;
    public GameObject enemy3FrozenIcon;
    public GameObject enemy3IgnitedIcon;
    public GameObject enemy4TauntedIcon;
    public GameObject enemy4FrozenIcon;
    public GameObject enemy4IgnitedIcon;

    public Transform slime1Spawn;
    public Transform slime2Spawn;
    public Transform slime3Spawn;
    public Transform slime4Spawn;
    public Transform enemy1Spawn;
    public Transform enemy2Spawn;
    public Transform enemy3Spawn;
    public Transform enemy4Spawn;

    public BattleHUD slime1HUD;
    public BattleHUD slime2HUD;
    public BattleHUD slime3HUD;
    public BattleHUD slime4HUD;
    public BattleHUD enemy1HUD;
    public BattleHUD enemy2HUD;
    public BattleHUD enemy3HUD;
    public BattleHUD enemy4HUD;
    public BattleHUD selectedUnitHUD;

    public UnitBase slime1Unit;
    public UnitBase slime2Unit;
    public UnitBase slime3Unit;
    public UnitBase slime4Unit;
    public UnitBase enemy1Unit;
    public UnitBase enemy2Unit;
    public UnitBase enemy3Unit;
    public UnitBase enemy4Unit;

    UnitBase slime1GOS;
    UnitBase slime2GOS;
    UnitBase slime3GOS;
    UnitBase slime4GOS;

    UnitBase enemy1GOS;
    UnitBase enemy2GOS;
    UnitBase enemy3GOS;
    UnitBase enemy4GOS;

    UnitBase currentUnitSkills;

    public UnitBase currentUnit;
    public UnitBase selectedUnit;

    public int selectedSkill;
    public GameObject TargetEnemies;
    public GameObject TargetAllEnemies;
    public GameObject TargetAllies;
    public GameObject TargetAllAllies;

    public GameObject enemy1TargetButton;
    public GameObject enemy2TargetButton;
    public GameObject enemy3TargetButton;
    public GameObject enemy4TargetButton;
    public GameObject ally1TargetButton;
    public GameObject ally2TargetButton;
    public GameObject ally3TargetButton;
    public GameObject ally4TargetButton;

    private float slime1HealthPercentage;
    private float slime2HealthPercentage;
    private float slime3HealthPercentage;
    private float slime4HealthPercentage;

    private bool playerTookAction;

    public List<UnitBase> units; // List of all units in the game

    private int currentUnitIndex; // Index of the unit currently taking a turn

    public BattleState state;

    public Button startButton;

    private void Start()
    {
        // Add a listener to the start button
        startButton.onClick.AddListener(StartGame);
    }
    public void StartGame()
    {
        state = BattleState.START;
        units.Sort((a, b) => b.speed.CompareTo(a.speed));
        currentUnitIndex = 0;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject slime1GO = Instantiate(slime1Prefab, slime1Spawn);
        slime1Unit = slime1GO.GetComponent<UnitBase>();
        GameObject slime2GO = Instantiate(slime2Prefab, slime2Spawn);
        slime2Unit = slime2GO.GetComponent<UnitBase>();
        GameObject slime3GO = Instantiate(slime3Prefab, slime3Spawn);
        slime3Unit = slime3GO.GetComponent<UnitBase>();
        GameObject slime4GO = Instantiate(slime4Prefab, slime4Spawn);
        slime4Unit = slime4GO.GetComponent<UnitBase>();

        GameObject enemy1GO = Instantiate(enemy1Prefab, enemy1Spawn);
        enemy1Unit = enemy1GO.GetComponent<UnitBase>();
        GameObject enemy2GO = Instantiate(enemy2Prefab, enemy2Spawn);
        enemy2Unit = enemy2GO.GetComponent<UnitBase>();
        GameObject enemy3GO = Instantiate(enemy3Prefab, enemy3Spawn);
        enemy3Unit = enemy3GO.GetComponent<UnitBase>();
        GameObject enemy4GO = Instantiate(enemy4Prefab, enemy4Spawn);
        enemy4Unit = enemy4GO.GetComponent<UnitBase>();

        slime1GOS = slime1Unit.GetComponent<Slime1>();
        slime2GOS = slime2Unit.GetComponent<Slime2>();
        slime3GOS = slime3Unit.GetComponent<Slime3>();
        slime4GOS = slime4Unit.GetComponent<Slime4>();

        enemy1GOS = enemy1Unit.GetComponent<Enemy1>();
        enemy2GOS = enemy2Unit.GetComponent<Enemy2>();
        enemy3GOS = enemy3Unit.GetComponent<Enemy3>();
        enemy4GOS = enemy4Unit.GetComponent<Enemy4>();

        slime1HUD.SetHUD(slime1Unit);
        slime2HUD.SetHUD(slime2Unit);
        slime3HUD.SetHUD(slime3Unit);
        slime4HUD.SetHUD(slime4Unit);

        enemy1HUD.SetHUD(enemy1Unit);
        enemy2HUD.SetHUD(enemy2Unit);
        enemy3HUD.SetHUD(enemy3Unit);
        enemy4HUD.SetHUD(enemy4Unit);

        dialogue.text = "The Battle is about to start!";

        yield return new WaitForSeconds(3f);

        TurnManager();

    }
    public void TurnManager()
    {
        currentUnit = units[currentUnitIndex];
        currentUnitIndex++;

        if (currentUnit.unitName == "Water Slime" && slime4Unit.isDead == true)
        {
            TurnManager();
            return;
        }
        if (currentUnit.unitName == "Fire Slime" && slime3Unit.isDead == true)
        {
            TurnManager();
            return;
        }
        if (currentUnit.unitName == "Ice Slime" && slime2Unit.isDead == true)
        {
            TurnManager();
            return;
        }
        if (currentUnit.unitName == "Rock Slime" && slime1Unit.isDead == true)
        {
            currentUnitIndex = 0; // Reset index to start from the first unit again
            TurnManager();
            return;
        }
        if (currentUnit.unitName == "Priest" && enemy4Unit.isDead == true)
        {
            TurnManager();
            return;
        }
        if (currentUnit.unitName == "Archer" && enemy3Unit.isDead == true)
        {
            TurnManager();
            return;
        }
        if (currentUnit.unitName == "Thief" && enemy2Unit.isDead == true)
        {
            TurnManager();
            return;
        }
        if (currentUnit.unitName == "Knight" && enemy1Unit.isDead == true)
        {
            TurnManager();
            return;
        }

        if (currentUnit.unitName == "Water Slime")
            currentUnitSkills = slime4GOS;
        if (currentUnit.unitName == "Fire Slime")
            currentUnitSkills = slime3GOS;
        if (currentUnit.unitName == "Ice Slime")
            currentUnitSkills = slime2GOS;
        if (currentUnit.unitName == "Rock Slime")
            currentUnitSkills = slime1GOS;
        if (currentUnit.unitName == "Priest")
            currentUnitSkills = enemy4GOS;
        if (currentUnit.unitName == "Archer")
            currentUnitSkills = enemy3GOS;
        if (currentUnit.unitName == "Thief")
            currentUnitSkills = enemy2GOS;
        if (currentUnit.unitName == "Knight")
            currentUnitSkills = enemy1GOS;

        if (currentUnitSkills.skill1Cooldown > 0)
            currentUnitSkills.skill1Cooldown--;
        if (currentUnitSkills.skill2Cooldown > 0)
            currentUnitSkills.skill2Cooldown--;

        playerTookAction = false;

        if (currentUnitIndex >= units.Count)
        {
            currentUnitIndex = 0; // Reset index to start from the first unit again
        }

        if (currentUnit.isEnemy == true)
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }
    void PlayerTurn()
    {
        dialogue.text = currentUnit.unitName + "'s turn";
    }
    IEnumerator EnemyTurn()
    {
        dialogue.text = currentUnit.unitName + "'s turn";

        if (currentUnit.unitName == "Knight")
            skillsText.text = "Attacks a random target dealing 4 damage while healing all allies for 1 health";
        if (currentUnit.unitName == "Thief")
            skillsText.text = "Attacks a random target, dealing 11 damage";
        if (currentUnit.unitName == "Archer")
            skillsText.text = "Attacks with a voley of arrows, dealing 5 damage to all enemies, alternatively deals 10 damage to a single target";
        if (currentUnit.unitName == "Priest")
            skillsText.text = "Heals the lowest health ally for 6 health, alternatively deals 4 damage to a random target";

        yield return new WaitForSeconds(2f);

        EnemyTargetSelection();
    }
    IEnumerator ActivateEnemyAttack()
    {
        currentUnitSkills.BasicAttack(this);

        CheckForDeadUnits();

        DisableDeadAllyTargetButtons();

        yield return new WaitForSeconds(2f);

        skillsText.text = "";

        CheckIfEndBattle();
    }
    public void PlayerBasicAttack()
    {
        ClearTargetButtons();
        dialogue.text = "Choose a target to use your Basic Attack on";
        selectedSkill = 0;
        currentUnitSkills.BasicAttackTarget(this);
    }
    public void PlayerSkill1()
    {
        ClearTargetButtons();
        if (currentUnitSkills.skill1Cooldown != 0)
        {
            dialogue.text = currentUnit.unitName + "'s skill 1 is on cooldown for " + currentUnitSkills.skill1Cooldown + " more turns";
        }
        else 
            dialogue.text = "Choose a target to use skill 1 on";
        selectedSkill = 1;
        currentUnitSkills.Skill1Targets(this);
    }
    public void PlayerSkill2()
    {
        ClearTargetButtons();
        if (currentUnitSkills.skill2Cooldown != 0)
        {
            dialogue.text = currentUnit.unitName + "'s skill 2 is on cooldown for " + currentUnitSkills.skill2Cooldown + " more turns";
        }
        else 
            dialogue.text = "Choose a target to use skill 2 on";
        selectedSkill = 2;
        currentUnitSkills.Skill2Targets(this);
    }
    public void OnBasicAttackButton()
    {
        if (state != BattleState.PLAYERTURN || playerTookAction == true)
            return;

        PlayerBasicAttack();
    }
    public void OnSkill1Button()
    {
        if (state != BattleState.PLAYERTURN || playerTookAction == true)
            return;

        PlayerSkill1();
    }
    public void OnSkill2Button()
    {
        if (state != BattleState.PLAYERTURN || playerTookAction == true)
            return;

        PlayerSkill2();
    }
    public void Enemy1Selection()
    {
        selectedUnit = enemy1Unit;
        selectedUnitHUD = enemy1HUD;
        StartCoroutine(ActivateSelectedSkill());
    }
    public void Enemy2Selection()
    {
        selectedUnit = enemy2Unit;
        selectedUnitHUD = enemy2HUD;
        StartCoroutine(ActivateSelectedSkill());
    }
    public void Enemy3Selection()
    {
        selectedUnit = enemy3Unit;
        selectedUnitHUD = enemy3HUD;
        StartCoroutine(ActivateSelectedSkill());
    }
    public void Enemy4Selection()
    {
        selectedUnit = enemy4Unit;
        selectedUnitHUD = enemy4HUD;
        StartCoroutine(ActivateSelectedSkill());
    }
    public void Ally1Selection()
    {
        selectedUnit = slime1Unit;
        selectedUnitHUD = slime1HUD;
        StartCoroutine(ActivateSelectedSkill());
    }
    public void Ally2Selection()
    {
        selectedUnit = slime2Unit;
        selectedUnitHUD = slime2HUD;
        StartCoroutine(ActivateSelectedSkill());
    }
    public void Ally3Selection()
    {
        selectedUnit = slime3Unit;
        selectedUnitHUD = slime3HUD;
        StartCoroutine(ActivateSelectedSkill());
    }
    public void Ally4Selection()
    {
        selectedUnit = slime4Unit;
        selectedUnitHUD = slime4HUD;
        StartCoroutine(ActivateSelectedSkill());
    }
    public void AllAllySelection()
    {
        StartCoroutine(ActivateSelectedSkill());
    }
    public void AllEnemies4Selection()
    {
        StartCoroutine(ActivateSelectedSkill());
    }
    public void EnemyTargetSelection()
    {
        /*slime1HealthPercentage = slime1Unit.currentHealth / slime1Unit.maxHealth;
        slime2HealthPercentage = slime2Unit.currentHealth / slime2Unit.maxHealth;
        slime3HealthPercentage = slime3Unit.currentHealth / slime3Unit.maxHealth;
        slime4HealthPercentage = slime4Unit.currentHealth / slime4Unit.maxHealth;
        
         if ((slime3Unit.isDead == false) && ((slime3HealthPercentage < slime1HealthPercentage) && slime1Unit.isDead == false) && ((slime3HealthPercentage < slime2HealthPercentage) && slime2Unit.isDead == false) && ((slime3HealthPercentage < slime4HealthPercentage) && slime4Unit.isDead == false))
        {
            selectedUnit = slime3Unit;
            selectedUnitHUD = slime3HUD;
        }
        else if ((slime2Unit.isDead == false) && ((slime2HealthPercentage < slime1HealthPercentage) && slime1Unit.isDead == false) && ((slime2HealthPercentage < slime4HealthPercentage) && slime4Unit.isDead == false) && ((slime2HealthPercentage < slime3HealthPercentage) && slime3Unit.isDead == false))
        {
            selectedUnit = slime2Unit;
            selectedUnitHUD = slime2HUD;
        }
        else if ((slime4Unit.isDead == false) && ((slime4HealthPercentage < slime1HealthPercentage) && slime1Unit.isDead == false) && ((slime4HealthPercentage < slime2HealthPercentage) && slime2Unit.isDead == false) && ((slime4HealthPercentage < slime3HealthPercentage) && slime3Unit.isDead == false))
        {
            selectedUnit = slime4Unit;
            selectedUnitHUD = slime4HUD;
        }
        else if ((slime1Unit.isDead == false) && ((slime1HealthPercentage < slime4HealthPercentage) && slime4Unit.isDead == false) && ((slime1HealthPercentage < slime2HealthPercentage) && slime2Unit.isDead == false) && ((slime1HealthPercentage < slime3HealthPercentage) && slime3Unit.isDead == false))
        {
            selectedUnit = slime1Unit;
            selectedUnitHUD = slime1HUD;
        }
        else
        {*/
            bool targetSelected = false;
            do
            {
                int randomTarget = Random.Range(1, 5);
                if ((slime1Unit.isDead == false) && randomTarget == 1)
                {
                    selectedUnit = slime1Unit;
                    selectedUnitHUD = slime1HUD;
                    targetSelected = true;
                }
                if ((slime2Unit.isDead == false) && randomTarget == 2)
                {
                    selectedUnit = slime2Unit;
                    selectedUnitHUD = slime2HUD;
                    targetSelected = true;
                }
                if ((slime3Unit.isDead == false) && randomTarget == 3)
                {
                    selectedUnit = slime3Unit;
                    selectedUnitHUD = slime3HUD;
                    targetSelected = true;
                }
                if ((slime4Unit.isDead == false) && randomTarget == 4)
                {
                    selectedUnit = slime4Unit;
                    selectedUnitHUD = slime4HUD;
                    targetSelected = true;
                }
            } while (targetSelected == false);
        //}

        StartCoroutine(ActivateEnemyAttack());
    }
    public void ClearTargetButtons()
    {
        TargetEnemies.SetActive(false);
        TargetAllies.SetActive(false);
        TargetAllEnemies.SetActive(false);
        TargetAllAllies.SetActive(false);
    }
    IEnumerator ActivateSelectedSkill()
    {
        if (selectedSkill == 0 || selectedSkill == 1 || selectedSkill == 2)
        {
            if (selectedSkill == 0)
                currentUnitSkills.BasicAttack(this);
            else if (selectedSkill == 1)
                currentUnitSkills.Skill1(this);
            else if (selectedSkill == 2)
                currentUnitSkills.Skill2(this);
        }
        else
        {
            dialogue.text = "You need to choose a skill first!";
        }

        CheckForDeadUnits();

        playerTookAction = true;

        DisableDeadEnemyTargetButtons();

        yield return new WaitForSeconds(1.5f);

        skillsText.text = "";

        CheckIfEndBattle();
    }
    public void CheckForDeadUnits()
    {
        if (enemy1Unit.currentHealth <= 0)
        {
            enemy1Unit.isDead = true;
            enemy1TauntedIcon.SetActive(false);
            enemy1FrozenIcon.SetActive(false);
            enemy1IgnitedIcon.SetActive(false);
        }
        if (enemy2Unit.currentHealth <= 0)
        {
            enemy2Unit.isDead = true;
            enemy2TauntedIcon.SetActive(false);
            enemy2FrozenIcon.SetActive(false);
            enemy2IgnitedIcon.SetActive(false);
        }
        if (enemy3Unit.currentHealth <= 0)
        {
            enemy3Unit.isDead = true;
            enemy3TauntedIcon.SetActive(false);
            enemy3FrozenIcon.SetActive(false);
            enemy3IgnitedIcon.SetActive(false);
        }
        if (enemy4Unit.currentHealth <= 0)
        {
            enemy4Unit.isDead = true;
            enemy4TauntedIcon.SetActive(false);
            enemy4FrozenIcon.SetActive(false);
            enemy4IgnitedIcon.SetActive(false);
        }

        if (slime1Unit.currentHealth <= 0)
            slime1Unit.isDead = true;
        if (slime2Unit.currentHealth <= 0)
            slime2Unit.isDead = true;
        if (slime3Unit.currentHealth <= 0)
            slime3Unit.isDead = true;
        if (slime4Unit.currentHealth <= 0)
            slime4Unit.isDead = true;
    }
    public void DisableDeadEnemyTargetButtons()
    {
        if (enemy1Unit.isDead == true)
            enemy4TargetButton.gameObject.SetActive(false);
        if (enemy2Unit.isDead == true)
            enemy3TargetButton.gameObject.SetActive(false);
        if (enemy3Unit.isDead == true)
            enemy2TargetButton.gameObject.SetActive(false);
        if (enemy4Unit.isDead == true)
            enemy1TargetButton.gameObject.SetActive(false);
    }
    public void DisableDeadAllyTargetButtons()
    {
        if (slime1Unit.isDead == true)
            ally4TargetButton.gameObject.SetActive(false);
        if (slime2Unit.isDead == true)
            ally3TargetButton.gameObject.SetActive(false);
        if (slime3Unit.isDead == true)
            ally2TargetButton.gameObject.SetActive(false);
        if (slime4Unit.isDead == true)
            ally1TargetButton.gameObject.SetActive(false);
    }
    void CheckIfEndBattle()
    {
        if (enemy1Unit.isDead == true && enemy2Unit.isDead == true && enemy3Unit.isDead == true && enemy4Unit.isDead == true)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else if (slime1Unit.isDead == true && slime2Unit.isDead == true && slime3Unit.isDead == true && slime4Unit.isDead == true)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
            TurnManager();
    }
    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            wonUI.gameObject.SetActive(true);
        }
        else if (state == BattleState.LOST)
        {
            lostUI.gameObject.SetActive(true);
        }
    }
}
