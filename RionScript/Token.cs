using System;
namespace RionScript
{
    public class Token
    {
        public TokenType TokenType { get; }
        public dynamic Value { get; }

        public Token(TokenType tokenType, dynamic value)
        {
            TokenType = tokenType;
            Value = value;
        }
        
        public override string ToString()
        {
            return string.Format("{0}: {1}", TokenType.ToString(), Value != null ? Value.ToString() : "");
        }
    }
}
