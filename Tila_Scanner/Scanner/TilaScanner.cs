using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tila_Scanner
{
    class TilaScanner
    {
        private readonly string _input;

        private int _position;

        public TilaScanner(string input)
        {
            _input = input;
            _position = 0;
        }

        private Token NextToken()
        {
            if (_position >= _input.Length)
            {
                return new Token(TokenType.EOF, string.Empty);
            }

            if (char.IsDigit(_input[_position]))
            {
                return Number();
            }

            if (char.IsLetter(_input[_position]))
            {
                return String();
            }

            #region unused
            //if (_input[_position] == '+')
            //{
            //    _position++;
            //    return new Token(TokenType.PLUS, "+");
            //}

            //if (_input[_position] == '/')
            //{
            //    _position++;
            //    return new Token(TokenType.DIV, "/");
            //}
            #endregion

            if (_input[_position] == '-')
            {
                _position++;
                return new Token(TokenType.MINUS, "-");
            }

            if (_input[_position] == '*')
            {
                _position++;
                return new Token(TokenType.MUL, "*");
            }

            if (_input[_position] == '^')
            {
                _position++;
                return new Token(TokenType.POWER, "^");
            }

            if (_input[_position] == '(')
            {
                _position++;
                return new Token(TokenType.LPAREN, "(");
            }

            if (_input[_position] == ')')
            {
                _position++;
                return new Token(TokenType.RPAREN, ")");
            }

            if (_input[_position] == ' ')
            {
                _position++;
                return new Token(TokenType.SPACE, " ");
            }

            if (_input[_position] == '=')
            {
                _position++;
                return new Token(TokenType.EQUAL, "=");
            }

            if (_input[_position] == ';')
            {
                _position++;
                return new Token(TokenType.EOS, ";");
            }

            throw new Exception($"Invalid character: {_input[_position]}");

        }

        public List<Token> ConvertToTokenStream()
        {
            List<Token> outputStream = new List<Token>();
            foreach (char item in _input)
            {
                outputStream.Add(NextToken());
            }

            return outputStream;
        }

        private Token Number()
        {
            var result = new StringBuilder();
            while (_position < _input.Length)
            {
                if (char.IsDigit(_input[_position]))
                {
                    result.Append(_input[_position]);
                    _position++;
                }
                else
                    break;
            }
            return new Token(TokenType.NUMBER, result.ToString());
        }

        private Token String()
        {
            var result = new StringBuilder();
            while (_position < _input.Length)
            {
                if (result.Length == 0)
                {
                    if (char.IsLetter(_input[_position]))
                    {
                        result.Append(_input[_position]);
                        _position++;
                    }
                    else
                        break;
                }
                else
                {
                    if (char.IsLetterOrDigit(_input[_position]))
                    {
                        result.Append(_input[_position]);
                        _position++;
                    }
                    else
                        break;
                }

            }
            return new Token(TokenType.STRING, result.ToString());
        }
    }
}
