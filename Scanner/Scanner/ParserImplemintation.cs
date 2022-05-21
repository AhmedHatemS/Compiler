namespace Scanner
{
    public class ParserImplemintation
    {
        List<TokenData> tokensList = new List<TokenData>();
        List<TokenData> matchedTokensList = new List<TokenData>();
        List<TokenData> notMatchedTokensList = new List<TokenData>();
        string[,] parsingTable = new string[49, 42];
        Stack parsingStack = new Stack();
        Stack actionsStack = new Stack();
        TokenData curr_token = new TokenData();
        bool matched = false, accepted = true;
        string popped = " ";
        int curr_token_Index = 0, curr_parsing_col = 1, curr_parsing_row = 1;

        public ParserImplemintation(List<TokenData> tokensList)
        {
            this.tokensList = tokensList;
            parsingStack.Push("Program");
            readParsingTable();
            Parse();
            if (!parsingStack.IsEmpty())
            {
                accepted = false;
                //Code not accepted
                //error ... + Code not accepted
                //matched ... + Code not accepted
                //matched ... + error ... + Code not accepted
                //matched .... + Code accepted
            }
        }
        public List<TokenData> GetMatchedTokensList()
        {
            return matchedTokensList;
        }
        public List<TokenData> GetNotMatchedTokensList()
        {
            return notMatchedTokensList;
        }
        public bool GetAcceptanceState()
        {
            return accepted;
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
            parsingTable[0, col++] = "return";
            parsingTable[0, col++] = "[";
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
            parsingTable[row++, 0] = "Variable_decl'";
            parsingTable[row++, 0] = "Method_decl";
            parsingTable[row++, 0] = "Method_decl'";
            parsingTable[row++, 0] = "Comment";
            parsingTable[row++, 0] = "require_command";
            parsingTable[row++, 0] = "Func_Call";
            parsingTable[row++, 0] = "Func Decl";
            parsingTable[row++, 0] = "ParameterList";
            parsingTable[row++, 0] = "Non-Empty List";
            parsingTable[row++, 0] = "Non-Empty List'";
            parsingTable[row++, 0] = "ID_List";
            parsingTable[row++, 0] = "ID_List'";
            parsingTable[row++, 0] = "Statements";
            parsingTable[row++, 0] = "Statement";
            parsingTable[row++, 0] = "Assignment";
            parsingTable[row++, 0] = "If_Statement";
            parsingTable[row++, 0] = "If_Statement'";
            parsingTable[row++, 0] = "However_Statement";
            parsingTable[row++, 0] = "When_Statement";
            parsingTable[row++, 0] = "Respondwith_Statement";
            parsingTable[row++, 0] = "Endthis_Statement";
            parsingTable[row++, 0] = "Argument_List";
            parsingTable[row++, 0] = "NonEmpty_Argument_List";
            parsingTable[row++, 0] = "NonEmpty_Argument_List'";
            parsingTable[row++, 0] = "Expression";
            parsingTable[row++, 0] = "Expression'";
            parsingTable[row++, 0] = "Term";
            parsingTable[row++, 0] = "Term'";
            parsingTable[row++, 0] = "Add_Op";
            parsingTable[row++, 0] = "factor";
            parsingTable[row++, 0] = "Multi_Op";
            parsingTable[row++, 0] = "Block Statements";
            parsingTable[row++, 0] = "Condition_Expression";
            parsingTable[row++, 0] = "Condition_Expression'";
            parsingTable[row++, 0] = "Condition";
            parsingTable[row++, 0] = "Condition_Op";
            parsingTable[row++, 0] = "Comparison_Op";
            parsingTable[row++, 0] = "Comparison_Op'";
            parsingTable[row++, 0] = "Comparison_Op\"";
            parsingTable[row++, 0] = "F_Name";


            //Values
            col = 1;
            parsingTable[1, col] = "Start-Symbols ClassDeclaration End-Symbols";
            parsingTable[2, col] = "@";
            col++; //col = 2
            parsingTable[1, col] = "Start-Symbols ClassDeclaration End-Symbols";
            parsingTable[2, col] = "^";
            col++; //col = 3
            parsingTable[3, col] = "$";
            col++; //col = 4
            parsingTable[3, col] = "#";
            col++; //col = 5
            parsingTable[34, col] = "Add_Op Term Expression'";
            parsingTable[36, col] = "em";
            parsingTable[37, col] = "+";
            col++; //col = 6
            parsingTable[34, col] = "Add_Op Term Expression'";
            parsingTable[36, col] = "em";
            parsingTable[37, col] = "-";
            col++; //col = 7
            parsingTable[36, col] = "Multi_Op Factor Term'";
            parsingTable[39, col] = "/";
            col++; //col = 8
            parsingTable[7, col] = "Variable_Decl Class_Implementation| Method_Decl Class_Implementation | Comment Class_Implementation | require_command Class_Implementation| Func _Call Class_Implementation";
            parsingTable[12, col] = "***ID";
            parsingTable[36, col] = "Multi_Op Factor Term'";
            parsingTable[39, col] = "*";
            col++; //col = 9
            parsingTable[8, col] = "Type ID_List ; Variable_Decl | Type ID_List [ID] ; ";
            parsingTable[34, col] = "em";
            parsingTable[36, col] = "em";
            parsingTable[45, col] = "==";
            parsingTable[47, col] = "=";
            col++; //col = 10
            parsingTable[34, col] = "em";
            parsingTable[36, col] = "em";
            parsingTable[45, col] = "!=";
            col++; //col = 11
            parsingTable[7, col] = "Variable_Decl Class_Implementation| Method_Decl Class_Implementation | Comment Class_Implementation | require_command Class_Implementation| Func _Call ";
            parsingTable[8, col] = "Type ID_List ; Variable_Decl | Type ID_List [ID] ; Variable_Decl";
            parsingTable[12, col] = "</ ID />";
            parsingTable[34, col] = "em";
            parsingTable[36, col] = "em";
            parsingTable[45, col] = "Comparison _Op’";
            parsingTable[46, col] = "< Comparison _Op’’";
            col++; //col = 12
            parsingTable[34, col] = "em";
            parsingTable[36, col] = "em";
            parsingTable[45, col] = "Comparison _Op’";
            parsingTable[46, col] = "> Comparison _Op‘’";
            col++; //col = 13
            parsingTable[34, col] = "em";
            parsingTable[36, col] = "em";
            parsingTable[42, col] = "Condition_Op Condition";
            parsingTable[44, col] = "&&";
            col++; //col = 14
            parsingTable[34, col] = "em";
            parsingTable[36, col] = "em";
            parsingTable[42, col] = "Condition_Op Condition";
            parsingTable[44, col] = "||";
            col++; //col = 15
            parsingTable[5, col] = "{ Class_Implementation }";
            parsingTable[11, col] = "{ Variable_Decl Statements }";
            parsingTable[40, col] = "{ statements }";
            col++; //col = 16
            parsingTable[7, col] = "Variable_Decl Class_Implementation| Method_Decl Class_Implementation | Comment Class_Implementation | require_command Class_Implementation| Func _Call Class_Implementation";
            parsingTable[8, col] = "Type ID_List ; Variable_Decl | Type ID_List";
            parsingTable[21, col] = "em";
            parsingTable[22, col] = "Assignment | If _Statement | However _Statement | when_Statement | Respondwith _ Statement | Endthis _Statement;";
            parsingTable[23, col] = "Variable_Decl = Expression ;";
            parsingTable[25, col] = "em";
            col++; //col = 17
            parsingTable[16, col] = "em";
            parsingTable[18, col] = "em";
            parsingTable[30, col] = "em";
            parsingTable[32, col] = "em";
            parsingTable[34, col] = "em";
            parsingTable[36, col] = "em";
            parsingTable[42, col] = "em";
            col++; //col = 18
            parsingTable[18, col] = ", Type ID Non-Empty List’";
            parsingTable[20, col] = ", ID ID_List ‘";
            parsingTable[32, col] = ", Expression NonEmpty_Argument_List’";
            col++; //col = 19
            parsingTable[9, col] = "; Variable_Decl";
            parsingTable[11, col] = ";";
            parsingTable[20, col] = "em";
            parsingTable[34, col] = "em";
            parsingTable[36, col] = "em";
            col++; //col = 20
            parsingTable[4, col] = "Type ID ClassDeclaration’";
            parsingTable[6, col] = "Ipok";
            parsingTable[7, col] = "Variable_Decl Class_Implementation| Method_Decl Class_Implementation | Comment Class_Implementation | require_command Class_Implementation| Func _Call Class_Implementation";
            parsingTable[8, col] = "Type ID_List Variable_Decl’";
            parsingTable[10, col] = "Func Decl Method_Decl’";
            parsingTable[15, col] = "Type ID ( ParameterList )";
            parsingTable[16, col] = "Non-Empty List";
            parsingTable[17, col] = "Type ID Non-Empty List’";
            parsingTable[21, col] = "Statement Statements";
            parsingTable[22, col] = "Assignment | If _Statement | However _Statement | when_Statement | Respondwith _ Statement | Endthis _Statement;";
            parsingTable[23, col] = "Variable_Decl = Expression ;";
            parsingTable[25, col] = "em";
            col++; //col = 21
            parsingTable[4, col] = "Type ID ClassDeclaration’";
            parsingTable[6, col] = "Sipok";
            parsingTable[7, col] = "Variable_Decl Class_Implementation| Method_Decl Class_Implementation | Comment Class_Implementation | require_command Class_Implementation| Func _Call Class_Implementation";
            parsingTable[8, col] = "Type ID_List Variable_Decl’";
            parsingTable[10, col] = "Func Decl Method_Decl’";
            parsingTable[15, col] = "Type ID ( ParameterList )";
            parsingTable[16, col] = "Non-Empty List";
            parsingTable[17, col] = "Type ID Non-Empty List’";
            parsingTable[21, col] = "Statement Statements";
            parsingTable[22, col] = "Assignment | If _Statement | However _Statement | when_Statement | Respondwith _ Statement | Endthis _Statement;";
            parsingTable[23, col] = "Variable_Decl = Expression ;";
            parsingTable[25, col] = "em";
            col++; //col = 22
            parsingTable[4, col] = "Type ID ClassDeclaration’";
            parsingTable[6, col] = "Craf";
            parsingTable[7, col] = "Variable_Decl Class_Implementation| Method_Decl Class_Implementation | Comment Class_Implementation | require_command Class_Implementation| Func _Call Class_Implementation";
            parsingTable[8, col] = "Type ID_List Variable_Decl’";
            parsingTable[10, col] = "Func Decl Method_Decl’";
            parsingTable[15, col] = "Type ID ( ParameterList )";
            parsingTable[16, col] = "Non-Empty List";
            parsingTable[17, col] = "Type ID Non-Empty List’";
            parsingTable[21, col] = "Statement Statements";
            parsingTable[22, col] = "Assignment | If _Statement | However _Statement | when_Statement | Respondwith _ Statement | Endthis _Statement;";
            parsingTable[23, col] = "Variable_Decl = Expression ;";
            parsingTable[25, col] = "em";
            col++; //col = 23
            parsingTable[4, col] = "Type ID ClassDeclaration’";
            parsingTable[6, col] = "Sequence";
            parsingTable[7, col] = "Variable_Decl Class_Implementation| Method_Decl Class_Implementation | Comment Class_Implementation | require_command Class_Implementation| Func _Call Class_Implementation";
            parsingTable[8, col] = "Type ID_List Variable_Decl’";
            parsingTable[10, col] = "Func Decl Method_Decl’";
            parsingTable[15, col] = "Type ID ( ParameterList )";
            parsingTable[16, col] = "Non-Empty List";
            parsingTable[17, col] = "Type ID Non-Empty List’";
            parsingTable[21, col] = "Statement Statements";
            parsingTable[22, col] = "Assignment | If _Statement | However _Statement | when_Statement | Respondwith _ Statement | Endthis _Statement;";
            parsingTable[23, col] = "Variable_Decl = Expression ;";
            parsingTable[25, col] = "em";
            col++; //col = 24
            parsingTable[4, col] = "Type ID ClassDeclaration’";
            parsingTable[6, col] = "Ipokf";
            parsingTable[7, col] = "Variable_Decl Class_Implementation| Method_Decl Class_Implementation | Comment Class_Implementation | require_command Class_Implementation| Func _Call Class_Implementation";
            parsingTable[8, col] = "Type ID_List Variable_Decl’";
            parsingTable[10, col] = "Func Decl Method_Decl’";
            parsingTable[15, col] = "Type ID ( ParameterList )";
            parsingTable[16, col] = "Non-Empty List";
            parsingTable[17, col] = "Type ID Non-Empty List’";
            parsingTable[21, col] = "Statement Statements";
            parsingTable[22, col] = "Assignment | If _Statement | However _Statement | when_Statement | Respondwith _ Statement | Endthis _Statement;";
            parsingTable[23, col] = "Variable_Decl = Expression ;";
            parsingTable[25, col] = "em";
            col++; //col = 25
            parsingTable[4, col] = "Type ID ClassDeclaration’";
            parsingTable[6, col] = "Sipokf";
            parsingTable[7, col] = "Variable_Decl Class_Implementation| Method_Decl Class_Implementation | Comment Class_Implementation | require_command Class_Implementation| Func _Call Class_Implementation";
            parsingTable[8, col] = "Type ID_List Variable_Decl’";
            parsingTable[10, col] = "Func Decl Method_Decl’";
            parsingTable[15, col] = "Type ID ( ParameterList )";
            parsingTable[16, col] = "Non-Empty List";
            parsingTable[17, col] = "Type ID Non-Empty List’";
            parsingTable[21, col] = "Statement Statements";
            parsingTable[22, col] = "Assignment | If _Statement | However _Statement | when_Statement | Respondwith _ Statement | Endthis _Statement;";
            parsingTable[23, col] = "Variable_Decl = Expression ;";
            parsingTable[25, col] = "em";
            col++; //col = 26
            parsingTable[4, col] = "Type ID ClassDeclaration’";
            parsingTable[6, col] = "Valueless";
            parsingTable[7, col] = "Variable_Decl Class_Implementation| Method_Decl Class_Implementation | Comment Class_Implementation | require_command Class_Implementation| Func _Call Class_Implementation";
            parsingTable[8, col] = "Type ID_List Variable_Decl’";
            parsingTable[10, col] = "Func Decl Method_Decl’";
            parsingTable[15, col] = "Type ID ( ParameterList )";
            parsingTable[16, col] = "Non-Empty List";
            parsingTable[17, col] = "Type ID Non-Empty List’";
            parsingTable[21, col] = "Statement Statements";
            parsingTable[22, col] = "Assignment | If _Statement | However _Statement | when_Statement | Respondwith _ Statement | Endthis _Statement;";
            parsingTable[23, col] = "Variable_Decl = Expression ;";
            parsingTable[25, col] = "em";
            col++; //col = 27
            parsingTable[4, col] = "Type ID ClassDeclaration’";
            parsingTable[6, col] = "Rational";
            parsingTable[7, col] = "Variable_Decl Class_Implementation| Method_Decl Class_Implementation | Comment Class_Implementation | require_command Class_Implementation| Func _Call Class_Implementation";
            parsingTable[8, col] = "Type ID_List Variable_Decl’";
            parsingTable[10, col] = "Func Decl Method_Decl’";
            parsingTable[15, col] = "Type ID ( ParameterList )";
            parsingTable[16, col] = "Non-Empty List";
            parsingTable[17, col] = "Type ID Non-Empty List’";
            parsingTable[21, col] = "Statement Statements";
            parsingTable[22, col] = "Assignment | If _Statement | However _Statement | when_Statement | Respondwith _ Statement | Endthis _Statement;";
            parsingTable[23, col] = "Variable_Decl = Expression ;";
            parsingTable[25, col] = "em";
            col++; //col = 28
            parsingTable[7, col] = "Variable_Decl Class_Implementation| Method_Decl Class_Implementation | Comment Class_Implementation | require_command Class_Implementation| Func _Call Class_Implementation";
            parsingTable[8, col] = "Type ID_List ; Variable_Decl | Type ID_List [ID] ; Variable_Decl";
            parsingTable[13, col] = "Require ( F_name . txt ) ;";
            col++; //col = 29
            parsingTable[7, col] = "Variable_Decl Class_Implementation| Method_Decl Class_Implementation | Comment Class_Implementation | require_command Class_Implementation| Func _Call Class_Implementation";
            parsingTable[8, col] = "Type ID_List ; Variable_Decl | Type ID_List [ID] ; Variable_Decl";
            parsingTable[14, col] = "ID ( Argument_List ) ;";
            parsingTable[19, col] = "ID ID_List’";
            parsingTable[30, col] = "NonEmpty_Argument_List";
            parsingTable[31, col] = "Expression NonEmpty_Argument_List’";
            parsingTable[33, col] = "Term Expression’";
            parsingTable[35, col] = "Factor Term’";
            parsingTable[38, col] = "ID";
            parsingTable[41, col] = "Condition Condition _Expression’";
            parsingTable[43, col] = "Expression Comparison _Op Expression";
            parsingTable[47, col] = "em";
            col++; //col = 30
            parsingTable[16, col] = "None";
            col++; //col = 31
            parsingTable[8, col] = "Type ID_List ; Variable_Decl | Type ID_List [ID] ; Variable_Decl";
            parsingTable[21, col] = "Statement Statements";
            parsingTable[22, col] = "Assignment | If _Statement | However _Statement | hen_Statement | Respondwith _ Statement | Endthis _Statement;";
            parsingTable[23, col] = "Variable_Decl = Expression ;";
            parsingTable[24, col] = "if ( Condition_Expression ) Block Statements If_Statement’";
            parsingTable[25, col] = "em";
            col++; //col = 32
            parsingTable[8, col] = "Type ID_List ; Variable_Decl | Type ID_List [ID] ;";
            parsingTable[21, col] = "Statement Statements";
            parsingTable[22, col] = "Assignment | If _Statement | However _Statement | When_Statement | Respondwith _ Statement | Endthis _Statement;";
            parsingTable[23, col] = "Variable_Decl = Expression ;";
            parsingTable[25, col] = "em";
            parsingTable[26, col] = "However ( Condition_Expression ) Block Statements";
            col++; //col = 33
            parsingTable[8, col] = "Type ID_List ; Variable_Decl | Type ID_List [ID] ;";
            parsingTable[21, col] = "Statement Statements";
            parsingTable[22, col] = "Assignment | If _Statement | However _Statement | When_Statement | Respondwith _ Statement | Endthis _Statement;";
            parsingTable[23, col] = "Variable_Decl = Expression ;";
            parsingTable[25, col] = "em";
            parsingTable[27, col] = "When ( expression ; expression ; expression ) Block Statements";
            col++; //col = 34
            parsingTable[8, col] = "Type ID_List ; Variable_Decl | Type ID_List [ID] ;";
            parsingTable[21, col] = "Statement Statements";
            parsingTable[22, col] = "Assignment | If _Statement | However _Statement | When_Statement | Respondwith _ Statement | Endthis _Statement;";
            parsingTable[23, col] = "Variable_Decl = Expression ;";
            parsingTable[25, col] = "em";
            parsingTable[28, col] = "Respondwith Expression ;";
            col++; //col = 35
            parsingTable[8, col] = "Type ID_List ; Variable_Decl | Type ID_List [ID] ;";
            parsingTable[21, col] = "Statement Statements";
            parsingTable[22, col] = "Assignment | If _Statement | However _Statement | When_Statement | Respondwith _ Statement | Endthis _Statement;";
            parsingTable[23, col] = "Variable_Decl = Expression ;";
            parsingTable[25, col] = "em";
            parsingTable[29, col] = "Endthis ;";
            col++; //col = 36
            parsingTable[30, col] = "NonEmpty_Argument_List";
            parsingTable[31, col] = "Expression NonEmpty_Argument_List’";
            parsingTable[33, col] = "Term Expression’";
            parsingTable[38, col] = "Factor Term’";
            parsingTable[36, col] = "Number";
            parsingTable[41, col] = "Condition Condition_Expression’";
            parsingTable[43, col] = "Expression Comparison_Op Expression";
            parsingTable[47, col] = "em";
            col++; //col = 37
            parsingTable[21, col] = "Statement Statements";
            parsingTable[22, col] = "Assignment | If _Statement | However _Statement | when_Statement | Respondwith _ Statement | Endthis _Statement;";
            parsingTable[23, col] = "Variable_Decl = Expression ;";
            parsingTable[25, col] = "em";
            parsingTable[28, col] = "return ID ;";
            col++; //col = 38
            parsingTable[9, col] = "[ID] ; Variable_Decl";
            parsingTable[20, col] = "em";
            col++; //col = 39
            parsingTable[5, col] = "Infer { Class_Implementation }";
            col++; //col = 40
            parsingTable[25, col] = "else Block Statements";
        }

        void Parse()
        {//@ Ipok
            curr_token = tokensList[curr_token_Index];
            while (curr_token_Index < tokensList.Count())
            {
                if (IsTerminal(curr_token.keyword))
                {
                    //Check parsingStack top terminal or nonterminal
                    if (!CheckParsingStackTopTerminalOrNot())
                    {
                        return;
                    }                   
                }
                else if (curr_token.returnToken == "Identifier")
                {
                    curr_token.keyword = "ID";
                }
                else if (curr_token.returnToken == "Constant")
                {
                    curr_token.keyword = "Number";
                }
            }
        }
        private bool ActionToDo()
        {
            if (parsingTable[curr_parsing_row, curr_parsing_col].Length > 0)
            {
                parsingStack.Pop();
                PushToParsingStack();
                return true;
            }
            saveToNotMatchedTokens(curr_token);
            return false;
        }
        private bool CheckParsingStackTopTerminalOrNot()
        {
            if (matched && popped.Equals(curr_token))
            {
                return true;
            }
            if (IsTerminal(parsingStack.GetTop()))
            {
                if (curr_token.keyword.Equals(parsingStack.GetTop())) //Matched
                {
                    Matched();
                    return true;
                }
                else
                {
                    saveToNotMatchedTokens(curr_token);
                    return false;
                }
            }
            else if (IsNonTerminal(parsingStack.GetTop()))
            {
                if (ActionToDo() == false)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        private void Matched()
        {
            matched = true;
            saveToMatchedTokens(curr_token);
            popped = parsingStack.Pop();
            curr_token_Index++;
            curr_parsing_col = 1;
            CheckParsingStackTopTerminalOrNot();
            if (curr_token_Index < tokensList.Count())
            {
                curr_token = tokensList[curr_token_Index];
            }
            matched = false;
            popped = " ";
        }
        private void PushToParsingStack()
        {
            string actionCell = parsingTable[curr_parsing_row, curr_parsing_col];
            string action = "";
            for (int i = 0; i < actionCell.Length; i++)
            {
                if (actionCell[i] != ' ')
                {
                    action += actionCell[i];
                }
                else
                {
                    actionsStack.Push(action);
                    action = "";
                }
            }
            actionsStack.Push(action);
            while (!actionsStack.IsEmpty())
            {
                parsingStack.Push(actionsStack.Pop());
            }
        }

        //private void setTerminal(string word)
        //{
        //    string terminal = parsingTable[0, curr_parsing_col];
        //    while (!word.Equals(terminal))
        //    {
        //        curr_parsing_col++;
        //        if (curr_parsing_col == parsingTable.GetLength(1))
        //        {
        //            curr_parsing_col = 1; //reset value
        //            return;
        //        }
        //        terminal = parsingTable[0, curr_parsing_col];
        //    }
        //}
        private bool IsTerminal(string word)
        {
            string terminal = parsingTable[0, curr_parsing_col];
            int temp = curr_parsing_col;
            while (!word.Equals(terminal))
            {
                curr_parsing_col++;
                if (curr_parsing_col == parsingTable.GetLength(1))
                {
                    curr_parsing_col = temp;
                    return false;
                }
                terminal = parsingTable[0, curr_parsing_col];
            }
            return true;
        }
        private bool IsNonTerminal(string word)
        {
            string nonTerminal = parsingTable[curr_parsing_row, 0];
            int temp = curr_parsing_row;
            while (!word.Equals(nonTerminal))
            {
                curr_parsing_row++;
                if (curr_parsing_row == parsingTable.GetLength(0))
                {
                    curr_parsing_row = temp; //reset value
                    return false;
                }
                nonTerminal = parsingTable[curr_parsing_row, 0];
            }
            return true;
        }
        private void saveToMatchedTokens(TokenData token)
        {
            TokenData tokenData = new TokenData();
            tokenData.line = token.line;
            tokenData.keyword = tokensList[curr_token_Index].keyword;
            tokenData.returnToken = parsingTable[curr_parsing_row, 0];
            matchedTokensList.Add(tokenData);
        }
        private void saveToNotMatchedTokens(TokenData token)
        {
            matchedTokensList.RemoveAll(t => t.line == token.line);
            TokenData tokenData = new TokenData();
            tokenData.line = token.line;
            notMatchedTokensList.Add(tokenData);
        }
    }
}
