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
        Button attackButton, defendButton, itemButton, switchButton, fleeButton;
        Button [] moveButton;
        
        public Battle(IServiceProvider serviceProvider, Player _player, Fighter _opponent)
        {
            content = new ContentManager(serviceProvider, "Content");
            
            player = _player;
            opponent = _opponent;
            
            attackButton = new Button(Content.Load<Texture2D>("AttackButton"), new vector2(10, 500));
            defendButton = new Button(Content.Load<Texture2D>("DefendButton"), new vector2(10, 530));
            itemButton = new Button(Content.Load<Texture2D>("ItemButton"), new vector2(10, 560));
            switchButton = new Button(Content.Load<Texture2D>("SwitchButton"), new vector2(10, 590));
            fleeButton = new Button(Content.Load<Texture2D>("fleeButton"), new vector2(10, 620));

            
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
            
            attackButton.update();
            defendButton.update();
            itemButton.update();    
            switchButton.update();
            fleeButton.update();
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
        
        public void Draw(SpriteFont spriteFont, SpriteBatch spriteBatch)
        {
            //Content.Load<Texture2D>("Tiles/" + name)
            spriteBatch.draw((Content.Load<Texture2D>(currentPlayerCharacter.getName())), new Vector2(300,50), Color.White);
            spriteBatch.draw((Content.Load<Texture2D>(currentEnemyCharacter.getName())), new Vector2(600,50), Color.White);
            
            if(playerTurn)
            {
                attackButton.Draw(spriteBatch);
                defendButton.Draw(spriteBatch);
                itemButton.Draw(spriteBatch);
                switchButton.Draw(spriteBatch);
                fleeButton.Draw(spriteBatch);
            }
        }
    }
}
