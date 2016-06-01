using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGuild
{
    class Area
    {
        char[][] area;
        int[][] rooms;
        int width;
        int height;
        int itemCount;
        //the number of rectangled rooms in the area
        int areaCount;
        //the level of mazes and halls to add
        int complexity;

        public Area(int _width, int _height, int _areaCount, int _complexity, int _itemCount)
        {
            width = _width;
            height = _height;
            areaCount = _areaCount;
            complexity = _complexity;
            itemCount = _itemCount;
            
            initalizeMap();
            makeRooms();
            makeHalls();
            makeStartPoint();
            makeEndPoint();
            makeItems();
        }

        private void initalizeMap()
        {
            /** Sets up an array of empty spaces*/
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    area[row][col] = '.';
                }
            }

            /** Sets up a bunch of random room's heights and widths*/
            for (int roomCount = 0; roomCount < areaCount; roomCount++)
            {
                Random rand = new Random();
                int randHeight = rand.Next(1, 10);
                int randWidth = rand.Next(1, 10);
                rooms[roomCount][0] = randHeight;
                rooms[roomCount][1] = randWidth;
            }
        }

        private void makeRooms()
        {
            for (int roomCount = 0; roomCount < areaCount; roomCount++)
            {
                Random rand = new Random();
                int randRow = rand.Next(0, height);
                int randCol = rand.Next(0, width);

                //loop to check if room position 
                for (int i = randRow; i < randRow + rooms[roomCount][0]; i++)
                {
                    bool interceptRoom = false;
                    randRow = rand.Next(0, height);
                    randCol = rand.Next(0, width);
                    for (int j = randCol; j < randCol + rooms[roomCount][1]; j++)
                    {
                        while (interceptRoom == true)
                        {
                            if (area[i][j] == '#')
                            {
                                interceptRoom = true;
                            }
                            else
                            {
                                randRow = rand.Next(0, height);
                                randCol = rand.Next(0, width);
                            }

                        }
                    }
                }//end of check loop

                /** Creates the room*/
                for (int i = randRow; i < randRow + rooms[roomCount][0]; i++)
                {
                    for (int j = randCol; j < randCol + rooms[roomCount][1]; j++)
                    {
                        area[i][j] = '#';
                    }
                }

            }
        } // end of makeRooms()

        private void makeHalls()
        {
            int hallCount = 0;
            Random Rand = new Random();
            for (int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    if(hallCount == Complexity)
                        break;
                    else if(area[i][j] == '#')
                    {
                        int [] possibleHalls;
                        int numOfHalls = 0;
                        int chosenHall;
                        
                        #region horizontal//make horizontal halls
                        for(int checkWidth = j; checkWidth < width; checkWidth++)
                        {
                            
                            
                            if(area[i][checkWidth]=='#')
                            {
                                
                                possibleHalls[numOfHalls] = checkWidth;
                                numOfHalls++;
                                hallCount++;
                                
                            }
                            else if(area[i][checkWidth]=='.')
                                break;
                                
                            
                        }
                        chosenHall = possibleHalls[rand.Next(0, numOfHalls)];
                        //adds the hallway
                        for(int hallMake = j; hallMake < chosenHall; hallMake++)
                        {
                            area[i][hallMake] = '#';
                        }
                        #endregion//end of make horizontal halls loop
                        
                        #region vertical//make vertical halls
                        for(int checkHeight = j; checkHeight < height; checkHeight++)
                        {
                            
                            
                            if(area[checkHeight][j]=='#')
                            {
                                
                                possibleHalls[numOfHalls] = checkHeight;
                                numOfHalls++;
                                hallCount++;
                                
                            }
                            else if(area[checkHeight][j]=='.')
                                break;
                                
                            
                        }
                        chosenHall = possibleHalls[rand.Next(0, numOfHalls)];
                        //adds the hallway
                        for(int hallMake = i; hallMake < chosenHall; hallMake++)
                        {
                            area[hallmake][j] = '#';
                        }
                        #endregion//end of make vertical halls loop
                        
                    }
                    
                }
            }//end of loop
        }//end of makeHalls
        
        private void makeStartPoint()
        {
            int x, y;
            Random Rand = New Random();
            do{
                x = Rand.Next(0, width);
                y = Rand.Next(0, height);
            }while(area[x][y]=='#')
            area[x][y]='s';
        }
        
        private void makeEndPoint()
        {
            int x, y;
            Random Rand = New Random();
            do{
                x = Rand.Next(0, width);
                y = Rand.Next(0, height);
            }while(area[x][y]=='#')
            area[x][y]='e';
        }
        
        private void makeItems()
        {
            int x, y;
            Random Rand = New Random();
            for (int i = 0; i < itemCount; i++)
            {
                do{
                    x = Rand.Next(0, width);
                    y = Rand.Next(0, height);
                }while(area[x][y]=='#')
                area[x][y]='i';
            }
        }
        
        
    }
}
