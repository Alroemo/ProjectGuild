using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGuild
{
    class Fighter
    {

        /** Array of all characters in use*/
        Character currentCharacter;
        Character[] currentParty;
        int partyCount;

        public Fighter(Character _currentCharacter, Character[] _currentParty, int _partyCount)
        {
            currentCharacter = _currentCharacter;
            partyCount = _partyCount;
            currentParty = _currentParty;
        }

        #region getFunctions
        public Character[] getPartyCharacters()
        { return currentParty; }
        public Character getCharacter()
        { return currentCharacter; }
        public Character getPartyCharacter(int charNum)
        { return currentParty[charNum]; }
        #endregion

        public void initalize()
        {
            partyCount = 0;
            currentCharacter = currentParty[0];
        }
        
        public void changeCurrentCharacter(int charNum)
        {
            currentCharacter = currentParty[charNum];
        }
        public void addCharacters(Character newCharacter)
        {
            partyCount += 1;
            currentParty[partyCount] = newCharacter;
        }
    }
}
