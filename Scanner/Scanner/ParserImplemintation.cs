namespace Scanner
{
    public class ParserImplemintation
    {
        public List<TokenData> tokensList = new List<TokenData>();
        public string[,] parsingTable = new string[49, 42];
        Stack parsingStack = new Stack();
        Stack actionsStack = new Stack();
        public ParserImplemintation(List<TokenData> tokensList)
        {
            this.tokensList = tokensList;
            readParsingTable();
        }
        void readParsingTable()
        {
            //Terminals
            int col = 1;
            parsingTable[0, col++] = "@";
            parsingTable[0, col++] = "^";
            parsingTable[0, col++] = "$";
            parsingTable[0, col++] = "#";
            parsingTable[0, col++] = "+";
            parsingTable[0, col++] = "-";
            parsingTable[0, col++] = "/";
            parsingTable[0, col++] = "*";
            parsingTable[0, col++] = "=";
            parsingTable[0, col++] = "!";
            parsingTable[0, col++] = "<";
            parsingTable[0, col++] = ">";
            parsingTable[0, col++] = "&";
            parsingTable[0, col++] = "|";
            parsingTable[0, col++] = "{";
            parsingTable[0, col++] = "}";
            parsingTable[0, col++] = ")";
            parsingTable[0, col++] = ",";
            parsingTable[0, col++] = ";";
            parsingTable[0, col++] = "[";
            parsingTable[0, col++] = "Ipok";
            parsingTable[0, col++] = "Sipok";
            parsingTable[0, col++] = "Craf";
            parsingTable[0, col++] = "Sequence";
            parsingTable[0, col++] = "Ipokf";
            parsingTable[0, col++] = "Sipokf";
            parsingTable[0, col++] = "Valueless";
            parsingTable[0, col++] = "Rational";
            parsingTable[0, col++] = "Require";
            parsingTable[0, col++] = "ID";
            parsingTable[0, col++] = "None";
            parsingTable[0, col++] = "If";
            parsingTable[0, col++] = "However";
            parsingTable[0, col++] = "When";
            parsingTable[0, col++] = "Respondwith";
            parsingTable[0, col++] = "Endthis";
            parsingTable[0, col++] = "Number";
            parsingTable[0, col++] = "STR";
            parsingTable[0, col++] = "return";
            parsingTable[0, col++] = "Infer";
            parsingTable[0, col++] = "Else";

            //Non-terminals
            int row = 1;
            parsingTable[row++, 0] = "Program";
            parsingTable[row++, 0] = "Start-Symbols";
            parsingTable[row++, 0] = "End-Symbols";
            parsingTable[row++, 0] = "ClassDeclaration";
            parsingTable[row++, 0] = "ClassDeclaration'";
            parsingTable[row++, 0] = "Type";
            parsingTable[row++, 0] = "Class_Implementation";
            parsingTable[row++, 0] = "Variable_decl";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";
            parsingTable[row++, 0] = "Else";

        }
    }
}
