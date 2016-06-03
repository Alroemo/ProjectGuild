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
            currentEnemyCharacter.initalizeCharacter();
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
        
        public void turn()
        {
            bool first;
            if(player.getCurrentSpeed() > opponent.getCurrentSpeed())
                first = true;
            else
                first = false;
        }
        
        public void makeChoice(int choiceTier, int choice)
        {
            string [] main = {"Attack", "Defend", "Item", "Switch", "Flee"};
            Move [] attack = { "move1", "move2", "move3", "move4"};
            Character [] charSwitch = {"char1", "char2","char3", "char4"};
            for(int i = 0; i < 4; i++)
            {
                attack[i] = currentPlayerCharacter.getMove[i]; 
                charSwitch[i] = player.getCharacter[i];
            }
            
            switch(choice):
                //attack
                case 1:
                    makeChoice(2,0);
                //defend
                case 2:
                    player.getCurrentCharacter.defend();
                case 3:
                    player.openItemList();
                case 4:
                    player.openCurrentParty();
                case 5:
                    this.flee;
        }
        
        public void playerFlee()
        {
            int fleeChance = Rand.next(0, 100);
            int flee = Rand.next(0,100);
            
            if(opponent.isBoss())
                fleeChance = 0;
                
            if(flee < fleeChance)
                this.endGame();
        }
        
        public void endBattle(int xp, Item rewardItem, int itemChance)
        {
            
        }
    }
}
