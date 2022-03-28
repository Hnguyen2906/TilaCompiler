using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tila_Scanner
{
    enum TokenType
    {
        EOF,
        PLUS,
        MINUS,
        MUL,
        DIV,
        LPAREN,
        RPAREN,
        NUMBER,
        CHAR,
        STRING,
        SPACE,
        POWER,
        EQUAL,
        EOS
    }
}
