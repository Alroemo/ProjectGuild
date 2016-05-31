using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input.Touch;

namespace ProjectGuild
{
  public class ProjectGuild : Microsoft.Xna.Framework.Game
  {
    public ProjectGuild()
    {
      graphics = new GraphicsDeviceManager(this);
      Content.RootDirectory = "Content";

      //graphics.IsFullScreen = true;

      graphics.PreferredBackBufferWidth = 800;
      graphics.PreferredBackBufferHeight = 480;
      graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;

      Accelerometer.Initialize();
    }
    protected override void LoadContent()
    {
     // Create a new SpriteBatch, which can be used to draw textures.
      spriteBatch = new SpriteBatch(GraphicsDevice);
    }
    
    protected override void Update(GameTime gameTime)
    {
      base.Update(gameTime);
    }
        
    protected override void Draw(GameTime gameTime)
    {
      graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
      base.Draw(gameTime);
    }
  }

}
