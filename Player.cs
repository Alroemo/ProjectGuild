

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
  class Player
  {
    /** Array of all characters*/
    character [200] characters;
    /** Variable to set the maximum number of characters the player can have based on base size.*/
    int maxCharacters;
    int currentOwnedCharacters;
    /** Array of all characters in use*/
    character [4] currentParty;
    
    public Player(Character [] _characters, int _maxCharacters, int _curentOwnedCharacters, character [4] _currentParty)
    {
      
    }
    
  }
}
