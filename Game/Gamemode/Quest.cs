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
  class Quest
  {
    int id;
    string name;
    string description;
    string plotEffect;
    
    public Quest(int _id, string _name, string _description, string _plotEffect)
    {
      id = _id;
      name = _name;
      description = _description;
      plotEffect = _plotEffect;
    }
    
    public int getID()
    { return id; }
    public string getName()
    { return name; }
    public string description()
    { return description; }
    public string getEffect()
    { return plotEffect; }
  }
}
