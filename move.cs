#region File Description
//-----------------------------------------------------------------------------
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
  class move
  {
    string name;
    string type;
    int actionDealt;
    int actionAmmount;
    string element;
    
    public move(string _name, string _type, int _actionDealt, int _actionAmmount, string _element)
    {
      name = _name;
      type = _type;
      actionDealt = _actionDealt;
      actionAmmount = _actionAmmount;
      element = _element;
    }
    
    /** functions to get move information*/
    public string getName()
    { return name; }
    public string getType()
    { return type; }
    public int getActionDealt()
    { return actionDealt; }
    public int getActionAmmount()
    { return actionAmmount; }
    public string getElement()
    { return element; }
    
  }
}
