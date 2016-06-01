using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGuild
{
    class Move
    {
        string name;
        string type;
        int actionDealt;
        int actionAmmount;
        string element;

        public Move(string _name, string _type, int _actionDealt, int _actionAmmount, string _element)
        {
            name = _name;
            type = _type;
            actionDealt = _actionDealt;
            actionAmmount = _actionAmmount;
            element = _element;
        }

        /** functions to get move information*/
        public string getName()
        { return name; }
        public string getType()
        { return type; }
        public int getActionDealt()
        { return actionDealt; }
        public int getActionAmmount()
        { return actionAmmount; }
        public string getElement()
        { return element; }
    }
}
