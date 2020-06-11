using System;
namespace RionScript.Exceptions
{
    public class IllegalCharacterException : Exception
    {
        public char IllegalCharacter { get;  }
        public IllegalCharacterException(char illegalCharacter)
        {
            IllegalCharacter = illegalCharacter;
        }

        public override string ToString()
        {
            // TODO x:y location
            return string.Format("Illegal character {0} found on x:y", IllegalCharacter);
        }
    }
}
