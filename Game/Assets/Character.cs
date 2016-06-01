using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGuild
{
    class Character
    {
        string name;
        int level;
        string role;
        int baseHealth, baseAttack, baseDefense, baseSpeed, baseAccuracy, baseIntellegence;
        int currentHealth, currentAttack, currentDefense, currentSpeed, currentAccuracy, currentIntellegence;
        Move[] moves;
        
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        Vector2 position;
        
        public Character(string _name, Move [] _moves, string _role, int _baseHealth, int _baseAttack, int _baseDefense, int _baseSpeed, int _baseAccuracy, int_baseIntellegence)
        {
            name = _name;
            role = _role;
            moves = _moves;
            baseHealth = _baseHealth;
            baseAttack = _baseAttack;
            baseDefense = _baseDefense;
            baseSpeed = _baseSpeed;
            baseAccuracy = _baseAccuracy;
            
            this.initalizeCharacter();
        }

        public void initalizeCharacter()
        {
            currentHealth = baseHealth;
            currentAttack = baseAttack;
            currentDefense = baseDefense;
            currentSpeed = baseSpeed;
            currentAccuracy = baseAccuracy;
            currentIntellegence = baseIntellegence;
        }
        #region stats
        /** Fuctions to get character information and stats*/
        #region getBaseInfo
        public string getName()
        { return name; }
        public string getRole()
        { return role; }
        public Move[] getMoves()
        { return moves; }
        public Move getMove(int num)
        { return moves[num];  }
        public int getBaseHealth()
        { return baseHealth; }
        public int getBaseAttack()
        { return baseAttack; }
        public int getBaseDefense()
        { return baseDefense; }
        public int getBaseSpeed()
        { return baseSpeed; }
        public int getBaseAccuracy()
        { return baseAccuracy; }
        #endregion

        /** Fuction to get current character information*/
        #region getCurrentInfo
        public int getCurrentHealth()
        { return currentHealth; }
        public int getCurrentAttack()
        { return currentAttack; }
        public int getCurrentDefense()
        { return currentDefense; }
        public int getCurrentSpeed()
        { return currentSpeed; }
        public int getCurrentAccuracy()
        { return currentAccuracy; }
        #endregion

        /** Fuctions to edit character's current stats in battle states*/
        #region changeCurrentInfo
        public void ChangeCurrentHealth(int damage)
        { currentHealth -= damage; }

        public void ChangeCurrentAttack(int change, bool changeable)
        {
            if ((currentAttack += change) <= (baseAttack * (3 / 2)) || (currentAttack += change) >= (baseAttack * (1 / 2)))
                currentAttack += change;
            else
                changeable = false;
        }
        public void ChangeCurrentDefense(int change, bool changeable)
        {
            if ((currentDefense += change) <= (baseDefense * (3 / 2)) || (currentDefense += change) >= (baseDefense * (1 / 2)))
                currentDefense += change;
            else
                changeable = false;
        }
        public void ChangeCurrentSpeed(int change, bool changeable)
        {
            if ((currentSpeed += change) <= (baseSpeed * (3 / 2)) || (currentSpeed += change) >= (baseSpeed * (1 / 2)))
                currentSpeed += change;
            else
                changeable = false;
        }
        public void ChangeCurrentAccuracy(int change, bool changeable)
        {
            if ((currentAccuracy += change) <= (baseAccuracy * (3 / 2)) || (currentAccuracy += change) >= (baseAccuracy * (1 / 2)))
                currentAccuracy += change;
            else
                changeable = false;
        }
        #endregion

        /** Functions to edit character stats for situations such as leveling up*/
        #region changeBaseInfo
        public void changeMove(int moveNum, Move newMove)
        { moves[moveNum] = newMove; }
        public void changeBaseHealth(int baseIncrease)
        { baseHealth += baseIncrease; }
        public void changeBaseAttack(int baseIncrease)
        { baseAttack += baseIncrease; }
        public void changeBaseDefense(int baseIncrease)
        { baseDefense += baseIncrease; }
        public void changeBaseSpeed(int baseIncrease)
        { baseSpeed += baseIncrease; }
        public void changeBaseAccuracy(int baseIncrease)
        { baseAccuracy += baseIncrease; }
        #endregion
        #endregion
        
        public void update()
        {
            
        }
        
        public void attack(Character opponent)
        {
            int damage = currentAttack;
            opponent.setHealth(damage);
        }
        
        public void draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(gameTime, spriteBatch, Position);
        }
    }
}
