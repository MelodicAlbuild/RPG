using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntity : IStats
{
    // Health
    public int healthCurrent { get; }
    public int healthMax { get; }
    public int regenHealth { get; }
    public int regenDelay { get; } 
    public void SetHealth(int health);
    public int GetCurrentHealth();
    public int GetMaxHealth();
    public void RemoveHealth(int health);
    public void AddHealth(int health);

    // XP
    public int xpCurrent { get; }
    public int xpMax { get; }
    public int level { get; }
    public void RemoveXP(int xp);
    public void AddXP(int xp);
    public void LevelUp();
    public int GetMaxXP();
    public int GetCurrentXP();
    public int GetCurrentLevel();
}
