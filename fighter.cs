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
        Character[] currentParty;
        int partyCount;

        public Fighter(Character[] _currentParty, int _partyCount)
        {
            partyCount = _partyCount;
            currentParty = _currentParty;
        }

        #region getFunctions
        public Character[] getPartyCharacters()
        { return currentParty; }
        public Character getPartyCharacter(int charNum)
        { return currentParty[charNum]; }
        #endregion

        public void initalize()
        {
            partyCount = 0;
        }

        public void addCharacters(Character newCharacter)
        {
            partyCount += 1;
            currentParty[partyCount] = newCharacter;
        }
    }
}
