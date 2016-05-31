

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
  class Area
  {
    char [][] area;
    int [][2]rooms;
    int width;
    int height;
    //the number of rectangled rooms in the area
    int areaCount;
    //the level of mazes and halls to add
    int complexity;
    
    public Area(int _width, int _height, int _areaCount, int _complexity)
    {
      width = _width;
      height = _height;
      areaCount = _areaCount;
      complexity = _complexity;
    }
    
    void initalizeArea()
    {
      for(int row = 0; row < height; row++)
      {
        for(int col = 0; col < width; col++)
        {
          area[i][j] = '.';
        }
      }
      
      for (int roomCount = 0; roomCount < areaCount; roomCount++)
      {
        
      }
    }
    
    public void makeArea()
    {
      
    }
    
  }
}
