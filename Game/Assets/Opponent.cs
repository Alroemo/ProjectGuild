using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGuild
{
    class Opponent : Fighter
    {
        Item rewardItem;
        int itemChance;

        public Opponent(Character _currentCharacter, Character[] _currentParty, Item _rewardItem, int _itemChance) 
        : base (_currentCharacter, _currentParty)
        {
            rewardItem = rewardItem;
            itemChance = _itemChance;
        }

        #region getFunctions
        public void initalize()
        {
            
        }

        public Character[] getCharacters()
        { return characters; }
        public Character getCharacter(int charNum)
        { return characters[charNum]; }
        public Item getRewardItem()
        { return rewardItem; }
        public int getItemChance()
        { return itemChance; }
        #endregion

        public void addCharacters(Character newCharacter)
        {
            ownedCharactersAmmount += 1;
            characters[ownedCharactersAmmount] = newCharacter;
        }
        
        public void isBoss()
        { return false; }
    }
}
