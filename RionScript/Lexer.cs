using System;
using System.Collections.Generic;
using RionScript.Exceptions;

namespace RionScript
{
    public class Lexer
    {
        public string Text { get;  }

        private int _currentIndex = 0;
        private char _currentCharacter;
        private bool _eof = false;


        public Lexer(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                _eof = true;
                return;
            }

            Text = text;
            _currentCharacter = Text[_currentIndex];
        }

        public IEnumerable<Token> GenerateTokens()
        {
            var tokens = new List<Token>();
            while (!HasEnded())
            {
                if (char.IsWhiteSpace(_currentCharacter))
                {
                    Advance();
                }
                else if(_currentCharacter == '.' || char.IsNumber(_currentCharacter))
                {
                    tokens.Add(GenerateNumber());
                }
                else if(_currentCharacter == '+')
                {
                    tokens.Add(new Token(TokenType.Plus, null));
                    Advance();
                }
                else if (_currentCharacter == '-')
                {
                    tokens.Add(new Token(TokenType.Minus, null));
                    Advance();
                }
                else if (_currentCharacter == '*')
                {
                    tokens.Add(new Token(TokenType.Multiply, null));
                    Advance();
                }
                else if (_currentCharacter == '/')
                {
                    tokens.Add(new Token(TokenType.Divide, null));
                    Advance();
                }
                else if (_currentCharacter == '(')
                {
                    tokens.Add(new Token(TokenType.LeftParenth, null));
                    Advance();
                }
                else if (_currentCharacter == ')')
                {
                    tokens.Add(new Token(TokenType.RightParenth, null));
                    Advance();
                } else
                {
                    throw new IllegalCharacterException(_currentCharacter);
                }
            }
            return tokens;
        }

        private void Advance()
        {
            if (_currentIndex == GetMaxIndex()) _eof = true;
            else if(_currentIndex < GetMaxIndex())
            {
                _currentIndex++;
                _currentCharacter = Text[_currentIndex];
            }
        }

        private Token GenerateNumber()
        {
            int numberOfDecimalPoints = 0;
            string number = _currentCharacter.ToString();
            Advance();

            while (!HasEnded() && (_currentCharacter == '.' || char.IsNumber(_currentCharacter)))
            {
                if (_currentCharacter == '.') numberOfDecimalPoints++;
                if (numberOfDecimalPoints > 1) break;

                number += _currentCharacter;
                Advance();
            }

            if (number.StartsWith('.')) number = '0' + number;
            if (number.EndsWith('.')) number += '0';

            return new Token(TokenType.Number, double.Parse(number));
        }

        private int GetMaxIndex() { return Text.Length - 1; }
        
        private bool HasEnded()
        {
            return _eof;
        }
    }
}
