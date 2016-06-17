
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
  class Button
  {
    Texture2D texture;
    vector2 position;
    bool pressed;
    
    public Button(Texture2D _texture, vector2 _position)
    {
      texture = _texture;
      position = _position;
    }
    
    
    
    public void Update()
    {
      
    }
    
    public void Draw(SpriteBatch spriteBatch)
    {
      spriteBatch.Draw(texture, position, color.White);
    }
  }
}
