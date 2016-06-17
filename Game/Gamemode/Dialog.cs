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
    string [] dialog
    Vector2 [] wordPosition;
    
    public Dialog(_spriteFont, string [] _dialog)
    {
      spriteFont = _spriteFont;
      dialog = _dialog;
      dialogBox = new Rectangle(10, 580, 760, 200);
      for(int i = 0; i < dialog.length; i++)
        wordPosition[i] = new vector2(15 + (i * 18), 585);
    }
    
    publiv void draw(SpriteBatch spriteBatch)
    {
      spriteBatch.draw((Content.load<Texture2D>("dialogBox")), dialogBox, Color.White);
      for(int i = 0; i < dialog.length;  i++)
        spriteBatch.drawString(spriteFont, dialog[i], wordPosition[i], Color.Yellow);
    }
    
  }
}
