using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGuild
{
    class Battle
    {
        Random Rand;
        
        Player player;
        Opponent opponent;
        Character currentPlayerCharacter;
        Character currentEnemyCharacter;
        vector2 pointerPosition;
        bool playerTurn;
        string [] mainChoices = {"Attack", "Defend", "Item", "Switch", "Flee"};
        Move [] attack = { "move1", "move2", "move3", "move4"};
        Character [] charSwitch = {"char1", "char2","char3", "char4"};
        
        public Battle(Player _player, Fighter _opponent)
        {
            player = _player;
            opponent = _opponent;
        }

        public void startBattle()
        {
            currentPlayerCharacter = player.getPartyCharacter(0);
            currentEnemyCharacter = opponent.getPartyCharacter(0);
            currentPlayerCharacter.initalizeCharacter();
            opponent.initalize();
            pointerPosition = new vector(0,0);
            playerTurn = true;
        }

        public void changePlayerCharacter(int partyNum)
        { currentPlayerCharacter = player.getPartyCharacter(partyNum); }
        public void changeEnemyCharacter(int partyNum)
        { currentEnemyCharacter = opponent.getPartyCharacter(partyNum); }

        
        
        #region attack
        public void playerAttackEnemy(int moveNum)
        {
            Move currentMove = currentPlayerCharacter.getMove(moveNum);
            int damage = 0;
            bool changeable = true;
            damage = currentMove.getActionDealt();
            if (currentMove.getType() == "Physical" || currentMove.getType() == "Cast")
            {
                currentEnemyCharacter.ChangeCurrentHealth(damage);
            }
            else if (currentMove.getType() == "AStatus")
            {
                currentEnemyCharacter.ChangeCurrentAttack(damage, changeable);
            }
            else if (currentMove.getType() == "DStatus")
            {
                currentEnemyCharacter.ChangeCurrentDefense(damage, changeable);
            }
            else if (currentMove.getType() == "SStatus")
            {
                currentEnemyCharacter.ChangeCurrentSpeed(damage, changeable);
            }
            else if (currentMove.getType() == "CStatus")
            {
                currentEnemyCharacter.ChangeCurrentAccuracy(damage, changeable);
            }

        }

        public void enemyAttackPlayer(int moveNum)
        {
            Move currentMove = currentEnemyCharacter.getMove(moveNum);
            int damage = 0;
            bool changeable = true;
            damage = currentMove.getActionDealt();
            if (currentMove.getType() == "Physical" || currentMove.getType() == "Cast")
            {
                currentPlayerCharacter.ChangeCurrentHealth(damage);
            }
            else if (currentMove.getType() == "AStatus")
            {
                currentPlayerCharacter.ChangeCurrentAttack(damage, changeable);
            }
            else if (currentMove.getType() == "DStatus")
            {
                currentPlayerCharacter.ChangeCurrentDefense(damage, changeable);
            }
            else if (currentMove.getType() == "SStatus")
            {
                currentPlayerCharacter.ChangeCurrentSpeed(damage, changeable);
            }
            else if (currentMove.getType() == "CStatus")
            {
                currentPlayerCharacter.ChangeCurrentAccuracy(damage, changeable);
            }
            
        }
        #endregion
        
        public bool turn()
        {
            bool first;
            if(player.getCurrentSpeed() > opponent.getCurrentSpeed())
                first = true;
            else
                first = false;
            return fiirst;
        }
        
        public void update(KeyboardState keyboardState)
        {
            for(int i = 0; i < 4; i++)
            {
                attack[i] = currentPlayerCharacter.getMove[i]; 
                charSwitch[i] = player.getCharacter[i];
            }
            
            int currentChoice = 0;
            KeyboardState oldKeyState = keyboardState;
            if(playerTurn == true)
            {
                if (keyboardState.IsKeyDown(Keys.Down) ||  keyboardState.IsKeyDown(Keys.S))
                {
                    if(currentChoice <= 5)
                        currentChoice++;
                }
                if (keyboardState.IsKeyDown(Keys.Up) ||  keyboardState.IsKeyDown(Keys.W))
                {
                    if(currentChoice > 0)
                        currentChoice--;
                }
                if (keyboardState.IsKeyDown(Keys.Enter) ||  keyboardState.IsKeyDown(Keys.E))
                {
                    //this.makeChoice(currentChoice);
                     //attack
                    if(currentChoice == 1)
                    {
                        int attackChoice = 0;
                        if (keyboardState.IsKeyDown(Keys.Down) ||  keyboardState.IsKeyDown(Keys.S))
                        {
                            if(attackChoice < 4)
                                attackChoice++;
                        }
                        if (keyboardState.IsKeyDown(Keys.Down) ||  keyboardState.IsKeyDown(Keys.S))
                        {
                            if(attackChoice >= 0)
                                attackChoice--;   
                        }
                        if(keyboardState.IsKeyDown(Keys.Enter) ||  keyboardState.IsKeyDown(Keys.E))
                        {
                            runTurns(attackChoice);
                            playerTurn = false;
                        }
                    }
                    //defend
                    else if(currentChoice == 2)
                    {
                        player.getCurrentCharacter.defend();
                        runTurns(-1);
                        playerTurn = false;
                    }
                    else if(currentChoice == 3)
                        player.openItemList();
                    else if(currentChoice == 4)
                        player.openCurrentParty();
                    else
                    {
                        this.playerFlee();
                        playerTurn = false;
                    }
                }
            }
        }
        
        public void runTurns(int playerChoice)
        {
            bool playerFirst = this.getTurn();
            int enemyMove = Rand.next(0,3);
            if(playerChoice == -1)
            {
                enemyAttackPlayer(enemyMove);
                playerTurn = true;    
            }
            if(playerFirst)
            {
                playerAttackEnemy(playerChoice);
                enemyAttackPlayer(enemyMove);
                playerTurn = true;
            }
            else if(!playerFirst)
            {
                enemyAttackPlayer(enemyMove);
                playerAttackEnemy(playerChoice);
                playerTurn = true;
            }
            
        }
        
        public void playerFlee()
        {
            int fleeChance = Rand.next(0, 100);
            int flee = Rand.next(0,100);
            
            if(opponent.isBoss())
                fleeChance = 0;
                
            if(flee < fleeChance)
                this.endGame();
            else
                runTurns(-1);
        }
        
        
        public void endBattle()
        {
            
        }
        
        public void draw(SpriteFont spriteFont, SpriteBatch spriteBatch)
        {
            
        }
    }
}
