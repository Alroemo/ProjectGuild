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
    int itemAverage;
    Random Rand = new Random();
    
    public Map(int _areaCount, string _size, int _itemAverage)
    {
      areaCount = _areaCount;
      size = _size;
      itemAverage = _itemAverage;
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
    
    /// <summary>
    /// Iterates over every tile in the structure file and loads its
    /// appearance and behavior. This method also validates that the
    /// file is well-formed with a player start point, exit, etc.
    /// </summary>
    /// <param name="fileStream">
    /// A stream containing the tile data.
    /// </param>
    private void LoadTiles(Stream fileStream)
    {
      // Load the level and ensure all of the lines are the same length.
      int width;
      List<string> lines = new List<string>();
      using (StreamReader reader = new StreamReader(fileStream))
      {
        string line = reader.ReadLine();
        width = line.Length;
        while (line != null)
        {
          lines.Add(line);
          if (line.Length != width)
            throw new Exception(String.Format("The length of line {0} is different from all preceeding lines.", lines.Count));
          line = reader.ReadLine();
        }
      }
      
      
  }
}
