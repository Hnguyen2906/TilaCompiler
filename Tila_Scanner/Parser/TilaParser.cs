using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tila_Scanner
{
    class TilaParser
    {
        private List<Token> _stream;

        public TilaParser(List<Token> stream)
        {
            this._stream = stream.Where(x => x.Value != " ").ToList();
        }

        public bool NoSyntaxErrors()
        {
            if (IsProgram(_stream))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsProgram(List<Token> tokens)
        {
            var filteredList = tokens.Where(x => x.Type != TokenType.EOF).ToList();

            if (IsBegin(filteredList.First())
                && IsEnd(filteredList.Last()))
            {
                filteredList.RemoveAt(0);
                filteredList.RemoveAt(filteredList.Count - 1);

                if (IsStatements(filteredList))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool IsDeclaration(List<Token> tokens)
        {
            if (tokens.Count == 2)
            {
                if (IsType(tokens[0]))
                {
                    if (tokens[1].Type == TokenType.STRING)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool IsStatements(List<Token> tokens)
        {
            List<List<Token>> sentences = new List<List<Token>>();
            int prevIndex = 0;


            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i].Type == TokenType.EOS)
                {
                    sentences.Add(tokens.Skip(prevIndex).Take(i - prevIndex).ToList());
                    prevIndex = i + 1;
                }
            }
            
            foreach (var setence in sentences)
            {
                if (!IsStatement(setence))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsAssignment(List<Token> tokens)
        {
            if (tokens[0].Type == TokenType.STRING)
            {
                if (tokens[1].Type == TokenType.EQUAL
                    && IsExpression(tokens.Skip(2).ToList()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool IsStatement(List<Token> tokens)
        {
            if (IsDeclaration(tokens))
            {
                return true;
            }
            else if (IsAssignment(tokens))
            {
                return true;
            }
            else if(IsLoop(tokens))
            {
                return true;
            }
            else if ((tokens[0].Type == TokenType.STRING && tokens[0].Value == "print") 
                    && IsExpression(tokens.Skip(1).ToList()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsExpression(List<Token> tokens)
        {
            if (tokens.Count == 1 && 
                (tokens[0].Type == TokenType.STRING || tokens[0].Type == TokenType.NUMBER))
            {
                return true;
            }

            if (tokens.First().Type == TokenType.LPAREN 
                && tokens.Last().Type == TokenType.RPAREN 
                && IsExpression(tokens.Skip(1).Take(tokens.Count - 1).ToList()))
            {
                return true;
            }

            if (IsContainOperators(tokens, out int index))
            {
                if (index == 0 || index == tokens.Count - 1)
                {
                    return false;
                }
                else
                {
                    var firstEpr = tokens.Take(index).ToList();
                    var secondEpr = tokens.Skip(index + 1).ToList();

                    if (IsExpression(firstEpr) && IsExpression(secondEpr))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return false;
        }

        private bool IsLoop(List<Token> tokens)
        {
            if (IsWhile(tokens[0]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsType(Token token)
        {
            if (token.Type == TokenType.STRING && token.Value == "int")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsWhile(Token token)
        {
            if (token.Type == TokenType.STRING && token.Value == "while")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsDo(Token token)
        {
            if (token.Type == TokenType.STRING && token.Value == "do")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsBegin(Token token)
        {
            if (token.Type == TokenType.STRING && token.Value == "begin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsEnd(Token token)
        {
            if (token.Type == TokenType.STRING && token.Value == "end")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsContainOperators(List<Token> tokens, out int index)
        {
            index = 0;
            foreach (var item in tokens)
            {
                if (item.Type == TokenType.MINUS
                    || item.Type == TokenType.MUL
                    || item.Type == TokenType.POWER)
                {
                    return true;
                }
                index++;
            }

            return false;
        }
    }
}
