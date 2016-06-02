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
  class Dialog
  {
    SpriteFont spriteFont; 
    Rectangle dialogBox;
    string dialog
    Vector2 wordPosition;
    
    public Dialog(_spriteFont, string dialog)
    {
      spriteFont = _spriteFont;
      dialog = _dialog;
      dialogBox = new Rectangle(10, 580, 760, 200);
      wordPosition = new vector2(15, 585);
    }
    
    publiv void draw(SpriteBatch spriteBatch)
    {
      spriteBatch.draw((Content.load<Texture2D>("dialogBox")), dialogBox, Color.White);
      spriteBatch.drawString(spriteFont, dialog, wordPosition, Color.Yellow);
    }
    
  }
}
