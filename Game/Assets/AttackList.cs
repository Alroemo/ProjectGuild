
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
  class AttackList
  {
    SpriteFont spriteFont;
    Move [] moves;
    int selectedMove;
    int finalChoice;
    vector2 choiceCursor;
    Rectangle moveBox = new rectangle(100, 400, 300, 200);
    vector2 [] position;
    
    public AttackList(SpriteFont _spriteFont, Move [] _moves)
    {
      spriteFont = _spriteFont;
      moves = _moves;
    }
    
    public void initalize()
    {
      finalChoice = 0;
      selectedMove = 1;
      choiceCursor = new vector2(95, 400);
      for (int i = 1; i <= 4; i++)
        position[i] = new vector2(100 + (10 * i), 400 + (10 * i));
      
    }
    
    public void update(KeyboardState keyboard)
    {
      if(keyboard.isKeyDown(Keys.Enter))
        finalChoice = selectedMove;
      if(keyboard.isKeyDown(Keys.Up) && selectedChoice > 1)
        selectedChoice--;
      if(keyboard.isKeyDown(Keys.Down) && selectedChoice < 4)
        selectedChoice++;
      choiceCursor.Y = 400 + (10 * selectedMove);
    }
    
    public int getFinalChoice()
    { return finalChoice; }
    
    public void draw(SpriteBatch spriteBatch)
    {
      spriteBatch.draw((Content.load<Texture2D>("dialogBox")), moveBox, Color.White);
      for (int i = 1; i <= 4; i++)
        spriteBatch.drawString(spriteFont, moves[i-1].getName() + moves[i-1].getActionDealt(), position[i], Color.Yellow);
      spriteBatch.draw((Content.load<Texture2D>("cursor")), choiceCursor, Color.White);
    }
    
    
  }
}
