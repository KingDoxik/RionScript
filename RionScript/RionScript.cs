using System;

namespace RionScript
{
    public class RionScript
    {
        public void Exec(string line)
        {
            var lexer = new Lexer(line);
            var tokens = lexer.GenerateTokens();
            Console.Write('[');
            foreach(var token in tokens)
            {
                Console.Write(token.ToString() + ", ");
            }
            Console.Write(']');
            Console.WriteLine();
        }
    }
}
