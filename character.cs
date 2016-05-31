
#region File Description
//-----------------------------------------------------------------------------
// Player.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjectGuild
{
  class character
  {
    string name;
    int level;
    string race;
    string role;
    int baseHealth, baseAttack, baseDefense, baseSpeed, baseAccuracy;
    int currentHealth, currentAttack, currentDefense, currentSpeed, currentAccuracy;
    Move [4] moves;
    
    public character (string _name, string _race, string _role, Move [4] _moves, int _baseHealth, int _baseAttack, int _baseDefense, int _baseSpeed, int _baseAccuracy)
    {
      name = _name;
      race = _race;
      role = _role;
      move = _moves;
      baseHealth = _baseHealth;
      baseAttack = _baseAttack;
      baseDefense = _baseDefense;
      baseSpeed = _baseSpeed;
      baseAccuracy = _baseAccuracy;
      
    }
    
    public initalizeCharacter()
    {
      currentHealth = baseHealth;
      currentAttack = baseAttack;
      currentDefense = baseDefense;
      currentSpeed = baseSpeed;
      currentAccuracy = baseAccuracy;
    }
    
    /** Fuctions to get character information and stats*/
    #region getBaseInfo
    public string getName()
    { return name; }
    public getRace()
    { return race; }
    public getRole()
    { return role; }
    public Move [] getMoves()
    { return moves; }
    public int getBaseHealth()
    { return baseHealth; }
    public int getBaseAttack()
    { return baseAttack; }
    public int getBaseDefense()
    { return baseDefense; }
    public int getBaseSpeed()
    { return baseSpeed; }
    public int getBaseAccuracy()
    { return baseAccuracy; }
    #endregion
    
    /** Fuction to get current character information*/
    #region getCurrentInfo
    public int getCurrentHealth()
    { return currentHealth; }
    public int getCurrentAttack()
    { return currentAttack; }
    public int getCurrentDefense()
    { return currentDefense; }
    public int getCurrentSpeed()
    { return currentSpeed; }
    public int getCurrentAccuracy()
    { return currentAccuracy; }
    #endregion
    
    /** Fuctions to edit character's current stats in battle states*/
    #region changeCurrentInfo
    public void ChangeCurrentHealth(int damage)
    { currentHealth -= damage }
    
    public void ChangeCurrentAttack(int change, bool changeable)
    { 
      if((currentAttack+= change) <= (baseAttack * (3/2)) || (currentAttack+= change) >= (baseAttack * (1/2)))
        currentAttack += change;
      else
        changeable = false;
    }
    public void ChangeCurrentDefense(int change, bool changeable)
    { 
      if((currentDefense += change) <= (baseDefense * (3/2)) || (currentDefense += change) >= (baseDefense * (1/2)))
        currentDefense += change;
      else
        changeable = false;
    }
    public void ChangeCurrentSpeed(int change, bool changeable)
    { 
      if((currentSpeed += change) <= (baseSpeed * (3/2)) || (currentSpeed+= change) >= (baseSpeed * (1/2)))
        currentSpeed += change;
      else
        changeable = false;
    }
    public void ChangeCurrentAccuracy(int change, bool changeable)
    { 
      if((currentAccuracy += change) <= (baseAccuracy * (3/2)) || (currentAccuracy += change) >= (baseAccuracy * (1/2)))
        currentAccuracy += change;
      else
        changeable = false;
    }
    #endregion
    
    /** Functions to edit character stats for situations such as leveling up*/
    #region changeBaseInfo
    public void changeSpeed(int moveNum, move newMove)
    { moves[moveNum] = newMove; }
    public void changeBaseHealth(int baseIncrease)
    { baseHealth += baseIncrease; }
    public void changeBaseAttack(int baseIncrease)
    { baseAttack += baseIncrease; }
    public void changeBaseDefense(int baseIncrease)
    { baseDefense += baseIncrease; }
    public void changeBaseSpeed(int baseIncrease)
    { baseSpeed += baseIncrease; }
    public void changeBaseAccuracy(int baseIncrease)
    { baseAccuracy += baseIncrease; }
    #endRegion
    
  }
}
