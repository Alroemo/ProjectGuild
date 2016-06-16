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
  class moveList
  {
    public Move [] moves = {
      new Move("testMove", "Physical", 10, 10, "Basic")
    };
    
    public Move getMove(int num)
    {
      return moves[num];
    }
  }
}
