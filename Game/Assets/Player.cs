using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGuild
{
    class Player : Fighter
    {
        /** Array of all characters*/
        Character[] characters;
        /** Variable to set the maximum number of characters the player can have based on base size.*/
        int maxCharacters;
        int currentOwnedCharactersAmmount;


        public Player(Character _currentCharacter, Character[] _characters, Character[] _currentParty, int _maxCharacters, int _curentOwnedCharactersAmmount) 
        : base (_currentCharacter, _currentParty)
        {
            characters = _characters;
            maxCharacters = _maxCharacters;
            currentOwnedCharactersAmmount = _curentOwnedCharactersAmmount;
        }

        #region getFunctions
        public void initalize()
        {
            currentOwnedCharactersAmmount = 0;
        }

        public Character[] getCharacters()
        { return characters; }
        public Character getCharacter(int charNum)
        { return characters[charNum]; }
        public int getMaxCharacters()
        { return maxCharacters; }
        public int getCurrentCharactersAmmount()
        { return currentOwnedCharactersAmmount; }
        #endregion

        public void addCharacters(Character newCharacter)
        {
            currentOwnedCharactersAmmount += 1;
            characters[currentOwnedCharactersAmmount] = newCharacter;
        }
    }
}
