using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IEntity
{
    [Header("Health")]
    public int currentHealth;
    public int maxHealth;
    public int healthRegenAmount;
    public int healthRegenDelay;

    private float lastDamagesTime = -1;

    private float regeneratedHealth;

    [Header("XP")]
    public int currentXp;
    public int maxXp;
    public int currentLevel;

    [Header("Stats")]
    public int allocationPoints = 0;
    public int attack = 0;
    public int speed = 0;
    public int health = 0;
    public int defense = 0;
    public int intelect = 0;
    public int vitality = 0;

    public PlayerController controller;

    public int healthCurrent { get => CurrentHealth(); }
    public int healthMax { get => MaxHealth(); }

    public int xpCurrent => CurrentXP();

    public int xpMax => MaxXP();

    public int level => Level();

    public int Attack => ActiveAttack();

    public int Speed => ActiveSpeed();

    public int Health => ActiveHealth();

    public int Defense => ActiveDefense();

    public int Intelect => ActiveIntelect();

    public int regenHealth => CurrentHealthRegenAmount();

    public int regenDelay => CurrentHealthRegenDelay();

    public int Vitality => ActiveVitality();

    private int CurrentHealthRegenAmount()
    {
        return healthRegenAmount;
    }

    private int CurrentHealthRegenDelay()
    {
        return healthRegenDelay;
    }

    private int CurrentHealth()
    {
        return currentHealth;
    }

    private int MaxHealth()
    {
        return maxHealth;
    }

    private int CurrentXP()
    {
        return currentHealth;
    }

    private int MaxXP()
    {
        return maxHealth;
    }

    private int Level()
    {
        return currentLevel;
    }

    private int ActiveAttack()
    {
        return attack;
    }

    private int ActiveSpeed()
    {
        return speed;
    }

    private int ActiveHealth()
    {
        return health;
    }

    private int ActiveDefense()
    {
        return defense;
    }

    private int ActiveIntelect()
    {
        return intelect;
    }

    private int ActiveVitality()
    {
        return vitality;
    }

    public void AddHealth(int health)
    {
        if (currentHealth + health <= healthMax)
        {
            currentHealth += health;
        }
        else
        {
            currentHealth = maxHealth;
        }
    }

    public void RemoveHealth(int health)
    {
        if (currentHealth - health >= 0)
        {
            currentHealth -= health;
            lastDamagesTime = Time.time;
        }
    }

    public void SetHealth(int health)
    {
        if (health >= 0)
        {
            currentHealth = health;
        }
    }

    public void SetMaxHealth(int health)
    {
        maxHealth += health * (int)(8.39 * ActiveHealth());
    }

    public int GetCurrentHealth()
    {
        return CurrentHealth();
    }

    public int GetMaxHealth()
    {
        return MaxHealth();
    }

    public void RemoveXP(int xp)
    {
        if (currentXp - xp >= 0)
        {
            currentXp -= xp;
        }
    }

    public void AddXP(int xp)
    {
        if (currentXp + xp <= maxXp)
        {
            currentXp += xp;
        }
        else
        {
            currentXp = maxXp;
        }
    }

    public int GetMaxXP()
    {
        return maxXp;
    }

    public int GetCurrentXP()
    {
        return currentXp;
    }

    public void LevelUp()
    {
        currentLevel++;
        currentXp = 0;
        allocationPoints = Random.Range(1, 5);
        maxXp = (int)(maxXp * 2.5f);
        StatUpdate();
        SetMaxHealth(currentLevel * 15);
        SetHealthRegen(vitality * 3);

        UpdateSpeed();
    }

    public void SetHealthRegen(int num)
    {
        healthRegenAmount = num;
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    private void Update()
    {
        if (currentHealth < maxHealth && lastDamagesTime == -1)
        {
            lastDamagesTime = Time.time;
        }

        if (currentXp == maxXp)
        {
            LevelUp();
        }

        if (lastDamagesTime >= 0 && Time.time - lastDamagesTime >= healthRegenDelay)
        {
            RegenerateHealth();
        }
    }

    public void RegenerateHealth()
    {
        regeneratedHealth += healthRegenAmount * Time.deltaTime;
        int flooredRegeneratedHealth = Mathf.FloorToInt(regeneratedHealth);
        regeneratedHealth -= flooredRegeneratedHealth;
        Heal(flooredRegeneratedHealth);
    }

    public void Heal(int amount)
    {
        if (amount < 0)
            throw new System.ArgumentException("Healed amount must be greater or equal to 0", nameof(amount));

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        if (currentHealth == maxHealth)
        {
            lastDamagesTime = -1;
            regeneratedHealth = 0;
            // Full health
        }
    }

    public void StatButtonAdd(StatButton button)
    {
        if (allocationPoints != 0)
        {
            switch (button)
            {
                case StatButton.Attack:
                    attack++;
                    allocationPoints--;
                    break;
                case StatButton.Defense:
                    defense++;
                    allocationPoints--;
                    break;
                case StatButton.Health:
                    health++;
                    allocationPoints--;
                    SetMaxHealth(1);
                    lastDamagesTime = Time.time;
                    break;
                case StatButton.Intelect:
                    intelect++;
                    allocationPoints--;
                    break;
                case StatButton.Speed:
                    speed++;
                    allocationPoints--;
                    UpdateSpeed();
                    break;
                case StatButton.Vitality:
                    vitality++;
                    allocationPoints--;
                    SetHealthRegen(vitality * 3);
                    break;
            }
        }
    }

    private void StatUpdate()
    {
        int heavy = Random.Range(1, 7);
        switch (heavy)
        {
            case 1:
                attack += 4;
                speed += Random.Range(0, 4);
                health += Random.Range(0, 4);
                defense += Random.Range(0, 4);
                intelect += Random.Range(0, 4);
                vitality += Random.Range(0, 4);
                break;
            case 2:
                attack += Random.Range(0, 4);
                speed += 4;
                health += Random.Range(0, 4);
                defense += Random.Range(0, 4);
                intelect += Random.Range(0, 4);
                vitality += Random.Range(0, 4);
                break;
            case 3:
                attack += Random.Range(0, 4);
                speed += Random.Range(0, 4);
                health += 4;
                defense += Random.Range(0, 4);
                intelect += Random.Range(0, 4);
                vitality += Random.Range(0, 4);
                break;
            case 4:
                attack += Random.Range(0, 4);
                speed += Random.Range(0, 4);
                health += Random.Range(0, 4);
                defense += 4;
                intelect += Random.Range(0, 4);
                vitality += Random.Range(0, 4);
                break;
            case 5:
                attack += Random.Range(0, 4);
                speed += Random.Range(0, 4);
                health += Random.Range(0, 4);
                defense += Random.Range(0, 4);
                intelect += 4;
                vitality += Random.Range(0, 4);
                break;
            case 6:
                attack += Random.Range(0, 4);
                speed += Random.Range(0, 4);
                health += Random.Range(0, 4);
                defense += Random.Range(0, 4);
                intelect += Random.Range(0, 4);
                vitality += 4;
                break;
        }
    }

    public void UpdateSpeed()
    {
        controller.runningSpeed += 0.25f * speed;
        controller.walkingSpeed += 0.25f * speed;
    }
}
