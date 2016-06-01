#region File Description
//-----------------------------------------------------------------------------
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using System.IO;
using Microsoft.Xna.Framework.Input;

namespace ProjectGuild
{
  class Map
  {
    Area [] area;
    private float cameraPosition;
  
    private Tile[,] tiles;
    // The layer which entities are drawn on top of.
    private const int EntityLayer = 2;
    //number of ares per map zone
    int areaCount;
    string size;

    Random Rand = new Random();
    
    public Map(int _areaCount, string _size)
    {
      areaCount = _areaCount;
      size = _size;
      
      createAreas();
    }
        
    //Creates the areas
    private void createAreas()
    {
      int width, height, roomCount, hallCount, itemCount;
      
      for (int i = 0; i < areaCount; i++)
      {
        if(size == "Small")
        {
          width = Rand.Next(10,15);
          height = Rand.Next(10,15);
          roomCount = Rand.Next(3,5);
          itemCount = Rand.Next(0,3);
        }
        if(size == "Medium")
        {
          width = Rand.Next(15,20);
          height = Rand.Next(15,20);
          roomCount = Rand.Next(5,7);
          itemCount = Rand.Next(0,5);
        }
        if(size == "Large")
        {
          width = Rand.Next(20,25);
          height = Rand.Next(20,25);
          roomCount = Rand.Next(7,9);
          itemCount = Rand.Next(0,7);
        }
        area[i] = new Area(width, height, roomCount, (roomCount * (3/2)), itemCount);
      }
    }
    // Entities in the level.
    public Player Player
    {
      get { return player; }
    }
    Player player;
    
    private List<Enemy> enemies = new List<Enemy>();
    private Vector2 start;
    private Point exit = InvalidPosition;
    private static readonly Point InvalidPosition = new Point(-1, -1);
    
    public Area getArea(int areaNum)
    { 
      return area[areaNum];
      
    }
    
    public bool ReachedExit
    {
      get { return reachedExit; }
    }
    bool reachedExit;
    
     public ContentManager Content
    {
      get { return content; }
    }
    ContentManager content; 
    
    #region tiles
    private void loadTiles(Area area)
    {
      // Allocate the tile grid.
      tiles = new Tile[width, lines.Count];
            
      for (int y = 0; y < area.getHeight(); ++y)
            {
                for (int x = 0; x < area.getWidth(); ++x)
                {
                    // to load each tile.
                    char tileType = lines[y][x];
                    tiles[x, y] = LoadTile(tileType, x, y);
                }
            }
    }
    
    private void loadTile(char tileType, int x, int y)
    {
      switch (tileType)
      {
        case '.':
          return LoadVarietyTile("Walls", 1, TileCollision.Impassable);
        case '#':
          return LoadVarietyTile("Floor", 1, TileCollision.Passable);
        case 's':
          return LoadStartTile(x,y);
        case 'e':
          return LoadExitTile(x,y);
        case 'i':
          return LoadItemTile(x,y);
      }
    }
    private Tile LoadTile(string name, TileCollision collision)
    {
      return new Tile(Content.Load<Texture2D>(name), collision);
    }
    /// <summary>
    /// Instantiates a player, puts him in the level, and remembers where to put him when he is resurrected.
    /// </summary>
    private Tile LoadStartTile(int x, int y)
    {
      if (Player != null)
      throw new NotSupportedException("A level may only have one starting point.");

      start = RectangleExtensions.GetBottomCenter(GetBounds(x, y));
      player = new Player(this, start);

      return new Tile(null, TileCollision.Passable);
    }

    /// <summary>
    /// Remembers the location of the level's exit.
    /// </summary>
    private Tile LoadExitTile(int x, int y)
    {
      if (exit != InvalidPosition)
        throw new NotSupportedException("A level may only have one exit.");

      exit = GetBounds(x, y).Center;

      return LoadTile("Exit", TileCollision.Passable);
    }
    
    private Tile LoadVarietyTile(string baseName, int variationCount, TileCollision collision)
    {
      int index = random.Next(variationCount);
      return LoadTile(baseName + index, collision);
    }
    
    /// <summary>
    /// Instantiates a gem and puts it in the level.
    /// </summary>
    private Tile LoadItemTile(int x, int y)
    {
      Point position = GetBounds(x, y).Center;
      gems.Add(new Gem(this, new Vector2(position.X, position.Y)));

      return new Tile(null, TileCollision.Passable);
    }
    #endregion
    
    public void update( GameTime gameTime, KeyboardState keyboardState, GamePadState gamePadState)
    {
      if(reachedExit)
      {
        
      }
      else
      {
        Player.Update(gameTime, keyboardState, gamePadState);
      }
    }//end of update
    
    private void updateItems()
    {
      
    }
    
    #region draw
    public void drawTiles(int areaNum, SpriteBatch spriteBatch)
    {
      this.loadTiles(area[areaNum]);
      // For each tile position
      for (int y = 0; y < Height; ++y)
      {
        for (int x = 0; x < Width; ++x)
        {
          // If there is a visible tile in that position
          Texture2D texture = tiles[x, y].Texture;
          if (texture != null)
          {
            // Draw it in screen space.
            Vector2 position = new Vector2(x, y) * Tile.Size;
            spriteBatch.Draw(texture, position, Color.White);
          }
        }
      }
    }
    
    public void Draw(int areaNum, SpriteBatch spriteBatch)
    {
      ScrollCamera(spriteBatch.GraphicsDevice.Viewport);
      Matrix cameraTransform = Matrix.CreateTranslation(-cameraPosition, 0.0f, 0.0f);
      spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, null, cameraTransform);
      DrawTiles(areaNum, spriteBatch);
    
      Player.Draw(spriteBatch);
  
    }
    
    private void ScrollCamera(Viewport viewport)
    {
      // Calculate the edges of the screen.
      float marginWidth = viewport.Width * ViewMargin;
      float marginLeft = cameraPosition + marginWidth;
      float marginRight = cameraPosition + viewport.Width - marginWidth;

      // Calculate how far to scroll when the player is near the edges of the screen.
      float cameraMovement = 0.0f;
      if (Player.Position.X < marginLeft)
        cameraMovement = Player.Position.X - marginLeft;
      else if (Player.Position.X > marginRight)
        cameraMovement = Player.Position.X - marginRight;

      // Update the camera position, but prevent scrolling off the ends of the level.
      float maxCameraPosition = Tile.Width * Width - viewport.Width;
      cameraPosition = MathHelper.Clamp(cameraPosition + cameraMovement, 0.0f, maxCameraPosition);
    }
    #endregion
}
