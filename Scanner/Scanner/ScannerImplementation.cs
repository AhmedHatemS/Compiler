namespace Scanner
{
    public class ScannerImplementation
    {
        Dictionary<string, string> tokensTable = new Dictionary<string, string>();
        public List<OutputItems> outputTokensList = new List<OutputItems>();
        public List<OutputItems> outputErrorsList = new List<OutputItems>();
        public string[,] transitionTable = new string[138, 58];        
        public string inputText = "";
        string checkedString = "";
        public int nOfErrors = 0;
        int line = 1, i=0, curr_state_row = 1, curr_transition_col = 1;

        public ScannerImplementation(string input)
        {
            readTransitionTable();
            readTokensType();
            inputText = input+" ";
            Scan();
        }      
        private void readTransitionTable()
             {
                 for(int i = 0; i < 138; i++)
                 {
                     for(int j = 0; j < 58; j++)
                     {
                         transitionTable[i,j] = "0";
                     }
                 }
                 for(int i = 1; i < 138; i++)
                     transitionTable[i, 57] = "NO";

                 //Transitions
                 int col = 0;
                 transitionTable[0, ++col] = "C";
                 transitionTable[0, ++col] = "E";
                 transitionTable[0, ++col] = "H";
                 transitionTable[0, ++col] = "W";
                 transitionTable[0, ++col] = "I";
                 transitionTable[0, ++col] = "R";
                 transitionTable[0, ++col] = "S";
                 transitionTable[0, ++col] = "T";
                 transitionTable[0, ++col] = "V";
                 transitionTable[0, ++col] = "a";
                 transitionTable[0, ++col] = "c";
                 transitionTable[0, ++col] = "d";
                 transitionTable[0, ++col] = "e";
                 transitionTable[0, ++col] = "f";
                 transitionTable[0, ++col] = "h";
                 transitionTable[0, ++col] = "i";
                 transitionTable[0, ++col] = "k";
                 transitionTable[0, ++col] = "l";
                 transitionTable[0, ++col] = "n";
                 transitionTable[0, ++col] = "o";
                 transitionTable[0, ++col] = "p";
                 transitionTable[0, ++col] = "q";
                 transitionTable[0, ++col] = "r";
                 transitionTable[0, ++col] = "s";
                 transitionTable[0, ++col] = "t";
                 transitionTable[0, ++col] = "u";
                 transitionTable[0, ++col] = "v";
                 transitionTable[0, ++col] = "w";
                 transitionTable[0, ++col] = "y";
                 transitionTable[0, ++col] = "Digit";
                 transitionTable[0, ++col] = "@";
                 transitionTable[0, ++col] = "^";
                 transitionTable[0, ++col] = "$";
                 transitionTable[0, ++col] = "#";
                 transitionTable[0, ++col] = "+";
                 transitionTable[0, ++col] = "-";
                 transitionTable[0, ++col] = "*";
                 transitionTable[0, ++col] = ">";
                 transitionTable[0, ++col] = "<";
                 transitionTable[0, ++col] = "/";
                 transitionTable[0, ++col] = "&";
                 transitionTable[0, ++col] = "~";
                 transitionTable[0, ++col] = "|";
                 transitionTable[0, ++col] = "=";
                 transitionTable[0, ++col] = "!";
                 transitionTable[0, ++col] = ".";
                 transitionTable[0, ++col] = "{";
                 transitionTable[0, ++col] = "}";
                 transitionTable[0, ++col] = "[";
                 transitionTable[0, ++col] = "]";
                 transitionTable[0, ++col] = "(";
                 transitionTable[0, ++col] = ")";
                 transitionTable[0, ++col] = "\"";
                 transitionTable[0, ++col] = "\'";
                 transitionTable[0, ++col] = "Letter";
                 transitionTable[0, ++col] = "Other";
                 transitionTable[0, ++col] = "Accept";

                 //States
                 int row = 0;
                 transitionTable[++row, 0] = "0";
                 transitionTable[++row, 0] = "2";
                 transitionTable[++row, 0] = "4";
                 transitionTable[++row, 0] = "5";
                 transitionTable[++row, 0] = "6";
                 transitionTable[++row, 0] = "7";
                 transitionTable[++row, 0] = "8";
                 transitionTable[++row, 0] = "9";
                 transitionTable[++row, 0] = "10";
                 transitionTable[++row, 0] = "11";
                 transitionTable[++row, 0] = "12";
                 transitionTable[++row, 0] = "13";
                 transitionTable[++row, 0] = "15";
                 transitionTable[++row, 0] = "16";
                 transitionTable[++row, 0] = "17";
                 transitionTable[++row, 0] = "19";
                 transitionTable[++row, 0] = "21";
                 transitionTable[++row, 0] = "22";
                 transitionTable[++row, 0] = "23";
                 transitionTable[++row, 0] = "25";
                 transitionTable[++row, 0] = "26";
                 transitionTable[++row, 0] = "27";
                 transitionTable[++row, 0] = "28";
                 transitionTable[++row, 0] = "29";
                 transitionTable[++row, 0] = "30";
                 transitionTable[++row, 0] = "33";
                 transitionTable[++row, 0] = "34";
                 transitionTable[++row, 0] = "35";
                 transitionTable[++row, 0] = "36";
                 transitionTable[++row, 0] = "37";
                 transitionTable[++row, 0] = "38";
                 transitionTable[++row, 0] = "39";
                 transitionTable[++row, 0] = "41";
                 transitionTable[++row, 0] = "42";
                 transitionTable[++row, 0] = "43";
                 transitionTable[++row, 0] = "44";
                 transitionTable[++row, 0] = "47";
                 transitionTable[++row, 0] = "49";
                 transitionTable[++row, 0] = "51";
                 transitionTable[++row, 0] = "52";
                 transitionTable[++row, 0] = "53";
                 transitionTable[++row, 0] = "54";
                 transitionTable[++row, 0] = "56";
                 transitionTable[++row, 0] = "57";
                 transitionTable[++row, 0] = "58";
                 transitionTable[++row, 0] = "59";
                 transitionTable[++row, 0] = "61";
                 transitionTable[++row, 0] = "63";
                 transitionTable[++row, 0] = "64";
                 transitionTable[++row, 0] = "65";
                 transitionTable[++row, 0] = "66";
                 transitionTable[++row, 0] = "67";
                 transitionTable[++row, 0] = "68";
                 transitionTable[++row, 0] = "69";
                 transitionTable[++row, 0] = "71";
                 transitionTable[++row, 0] = "73";
                 transitionTable[++row, 0] = "74";
                 transitionTable[++row, 0] = "75";
                 transitionTable[++row, 0] = "76";
                 transitionTable[++row, 0] = "77";
                 transitionTable[++row, 0] = "79";
                 transitionTable[++row, 0] = "80";
                 transitionTable[++row, 0] = "81";
                 transitionTable[++row, 0] = "82";
                 transitionTable[++row, 0] = "83";
                 transitionTable[++row, 0] = "84";
                 transitionTable[++row, 0] = "85";
                 transitionTable[++row, 0] = "86";
                 transitionTable[++row, 0] = "87";
                 transitionTable[++row, 0] = "89";
                 transitionTable[++row, 0] = "91";
                 transitionTable[++row, 0] = "92";
                 transitionTable[++row, 0] = "93";
                 transitionTable[++row, 0] = "94";
                 transitionTable[++row, 0] = "96";
                 transitionTable[++row, 0] = "98";
                 transitionTable[++row, 0] = "99";
                 transitionTable[++row, 0] = "100";
                 transitionTable[++row, 0] = "101";
                 transitionTable[++row, 0] = "102";
                 transitionTable[++row, 0] = "103";
                 transitionTable[++row, 0] = "104";
                 transitionTable[++row, 0] = "106";
                 transitionTable[++row, 0] = "107";
                 transitionTable[++row, 0] = "108";
                 transitionTable[++row, 0] = "110";
                 transitionTable[++row, 0] = "111";
                 transitionTable[++row, 0] = "112";
                 transitionTable[++row, 0] = "114";
                 transitionTable[++row, 0] = "115";
                 transitionTable[++row, 0] = "116";
                 transitionTable[++row, 0] = "117";
                 transitionTable[++row, 0] = "119";
                 transitionTable[++row, 0] = "120";
                 transitionTable[++row, 0] = "121";
                 transitionTable[++row, 0] = "122";
                 transitionTable[++row, 0] = "123";
                 transitionTable[++row, 0] = "124";
                 transitionTable[++row, 0] = "125";
                 transitionTable[++row, 0] = "126";
                 transitionTable[++row, 0] = "127";
                 transitionTable[++row, 0] = "130";
                 transitionTable[++row, 0] = "132";
                 transitionTable[++row, 0] = "136";
                 transitionTable[++row, 0] = "138";
                 transitionTable[++row, 0] = "142";
                 transitionTable[++row, 0] = "144";
                 transitionTable[++row, 0] = "145";
                 transitionTable[++row, 0] = "147";
                 transitionTable[++row, 0] = "148";
                 transitionTable[++row, 0] = "149";
                 transitionTable[++row, 0] = "151";
                 transitionTable[++row, 0] = "152";
                 transitionTable[++row, 0] = "155";
                 transitionTable[++row, 0] = "156";
                 transitionTable[++row, 0] = "158";
                 transitionTable[++row, 0] = "160";          
                 transitionTable[++row, 0] = "161";          
                 transitionTable[++row, 0] = "165";          
                 transitionTable[++row, 0] = "166";          
                 transitionTable[++row, 0] = "168";          
                 transitionTable[++row, 0] = "170";          
                 transitionTable[++row, 0] = "172";          
                 transitionTable[++row, 0] = "174";          
                 transitionTable[++row, 0] = "177";          
                 transitionTable[++row, 0] = "178";          
                 transitionTable[++row, 0] = "179";          
                 transitionTable[++row, 0] = "182";          
                 transitionTable[++row, 0] = "184";          
                 transitionTable[++row, 0] = "186";          
                 transitionTable[++row, 0] = "188";          
                 transitionTable[++row, 0] = "191";          
                 transitionTable[++row, 0] = "193";          
                 transitionTable[++row, 0] = "197";          
                 transitionTable[++row, 0] = "199";          
                 transitionTable[++row, 0] = "200";          
                 transitionTable[++row, 0] = "201";

                 //Values
                 col = 1;
                 transitionTable[1, col] = "2";
                 col++;
                 transitionTable[1, col] = "19";
                 col++;
                 transitionTable[1, col] = "33";
                 col++;
                 transitionTable[1, col] = "41";
                 col++;
                 transitionTable[1, col] = "47";
                 col++;
                 transitionTable[1, col] = "61";
                 col++;
                 transitionTable[1, col] = "89";
                 col++;
                 transitionTable[1, col] = "114";
                 col++;
                 transitionTable[1, col] = "119";
                 col++;
                 transitionTable[13, col] = "16";
                 transitionTable[47, col] = "63";
                 transitionTable[52, col] = "68";
                 transitionTable[83, col] = "107";
                 transitionTable[86, col] = "111";
                 transitionTable[93, col] = "120";
                 col++;
                 transitionTable[70, col] = "106";
                 transitionTable[80, col] = "103";
                 col++;
                 transitionTable[4, col] = "6";
                 transitionTable[20, col] = "26";
                 transitionTable[64, col] = "83";
                 col++;
                 transitionTable[18, col] = "23";
                 transitionTable[28, col] = "36";
                 transitionTable[30, col] = "38";
                 transitionTable[34, col] = "43";
                 transitionTable[40, col] = "53";
                 transitionTable[47, col] = "71";
                 transitionTable[59, col] = "77";
                 transitionTable[70, col] = "98";
                 transitionTable[78, col] = "101";
                 transitionTable[81, col] = "104";
                 transitionTable[91, col] = "117";
                 transitionTable[96, col] = "123";
                 transitionTable[98, col] = "125";
                 col++;
                 transitionTable[11, col] = "13";
                 transitionTable[14, col] = "17";
                 transitionTable[37, col] = "49";
                 transitionTable[39, col] = "52";
                 transitionTable[45, col] = "59";
                 transitionTable[74, col] = "96";
                 col++;
                 transitionTable[22, col] = "28";
                 transitionTable[33, col] = "42";
                 transitionTable[68, col] = "87";
                 col++;
                 transitionTable[5, col] = "7";
                 transitionTable[7, col] = "9";
                 transitionTable[23, col] = "29";
                 transitionTable[49, col] = "65";
                 transitionTable[57, col] = "75";
                 transitionTable[66, col] = "85";
                 transitionTable[70, col] = "91";
                 col++;
                 transitionTable[44, col] = "58";
                 transitionTable[73, col] = "94";
                 col++;
                 transitionTable[16, col] = "21";
                 transitionTable[53, col] = "69";
                 transitionTable[94, col] = "121";
                 transitionTable[97, col] = "124";
                 col++;
                 transitionTable[3, col] = "5";
                 transitionTable[9, col] = "11";
                 transitionTable[16, col] = "25";
                 transitionTable[35, col] = "44";
                 transitionTable[37, col] = "51";
                 transitionTable[51, col] = "67";
                 transitionTable[63, col] = "82";
                 transitionTable[79, col] = "102";
                 transitionTable[84, col] = "108";
                 col++;
                 transitionTable[2, col] = "4";
                 transitionTable[8, col] = "10";
                 transitionTable[10, col] = "12";
                 transitionTable[26, col] = "34";
                 transitionTable[43, col] = "57";
                 transitionTable[50, col] = "66";
                 transitionTable[62, col] = "81";
                 transitionTable[72, col] = "93";
                 col++;
                 transitionTable[37, col] = "56";
                 transitionTable[61, col] = "80";
                 transitionTable[71, col] = "92";
                transitionTable[87, col] = "112";
                transitionTable[90, col] = "116";            
                col++;
                 transitionTable[55, col] = "73";
                 transitionTable[76, col] = "99";
                 col++;
                 transitionTable[2, col] = "15";
                 transitionTable[31, col] = "39";
                 transitionTable[41, col] = "54";
                 transitionTable[58, col] = "76";
                 transitionTable[70, col] = "110";                 
                 col++;
                 transitionTable[17, col] = "22";
                 transitionTable[24, col] = "30";
                 transitionTable[55, col] = "79";
                 transitionTable[99, col] = "126";
                 transitionTable[100, col] = "127";
                 col++;
                 transitionTable[6, col] = "8";
                 transitionTable[21, col] = "27";
                 transitionTable[48, col] = "64";
                 transitionTable[67, col] = "86";
                 col++;
                 transitionTable[56, col] = "74";
                 transitionTable[77, col] = "100";
                 transitionTable[95, col] = "122";
                 col++;
                 transitionTable[29, col] = "37";
                 col++;
                 transitionTable[27, col] = "35";
                 transitionTable[65, col] = "84";
                 col++;
                 transitionTable[89, col] = "115";
                 col++;
                 transitionTable[1, col] = "177";
                 transitionTable[106, col] = "177";
                 transitionTable[107, col] = "177";
                 transitionTable[125, col] = "177";
                 transitionTable[126, col] = "179";
                 transitionTable[127, col] = "179";
                 transitionTable[137, col] = "201";
                 col++;
                 transitionTable[1, col] = "130";
                 col++;
                 transitionTable[1, col] = "132";
                 col++;
                 transitionTable[1, col] = "136";
                 col++;
                 transitionTable[1, col] = "138";
                 col++;
                 transitionTable[1, col] = "142";
                 col++;
                 transitionTable[1, col] = "144";
                 col++;
                 transitionTable[1, col] = "147";
                 transitionTable[109, col] = "148";
                 transitionTable[110, col] = "149";
                 col++;
                 transitionTable[1, col] = "168";
                 transitionTable[107, col] = "145";
                 transitionTable[112, col] = "152";
                 col++;
                 transitionTable[1, col] = "165";
                 col++;
                 transitionTable[1, col] = "151";
                 transitionTable[119, col] = "166";
                 col++;
                 transitionTable[1, col] = "155";
                 transitionTable[114, col] = "156";
                 col++;
                 transitionTable[1, col] = "158";
                 col++;
                 transitionTable[1, col] = "160";
                 transitionTable[117, col] = "161";
                 col++;
                 transitionTable[1, col] = "172";
                 transitionTable[119, col] = "174";
                 transitionTable[121, col] = "174";
                 transitionTable[122, col] = "174";
                 transitionTable[123, col] = "174";
                 col++;
                 transitionTable[1, col] = "170";
                 col++;
                 transitionTable[125, col] = "178";
                 col++;
                 transitionTable[1, col] = "182";
                 col++;
                 transitionTable[1, col] = "184";
                 col++;
                 transitionTable[1, col] = "188";
                 col++;
                 transitionTable[1, col] = "186";
                 col++;
                 transitionTable[1, col] = "197";
                 col++;
                 transitionTable[1, col] = "199";
                 col++;
                 transitionTable[1, col] = "193";
                 col++;
                 transitionTable[1, col] = "191";
                 col++;
                 transitionTable[1, col] = "201";
                 transitionTable[137, col] = "201";
                 col++;
                 transitionTable[12, col] = "200";
                 transitionTable[15, col] = "200";
                 transitionTable[19, col] = "200";
                 transitionTable[25, col] = "200";
                 transitionTable[32, col] = "200";
                 transitionTable[36, col] = "200";
                 transitionTable[38, col] = "200";
                 transitionTable[42, col] = "200";
                 transitionTable[45, col] = "200";
                 transitionTable[46, col] = "200";
                 transitionTable[54, col] = "200";
                 transitionTable[60, col] = "200";
                 transitionTable[69, col] = "200";
                 transitionTable[74, col] = "200";
                 transitionTable[75, col] = "200";
                 transitionTable[82, col] = "200";
                 transitionTable[85, col] = "200";
                 transitionTable[88, col] = "200";
                 transitionTable[92, col] = "200";
                 transitionTable[101, col] = "200";
                 transitionTable[102, col] = "200";
                 transitionTable[103, col] = "200";
                 transitionTable[104, col] = "200";
                 transitionTable[105, col] = "200";
                 transitionTable[106, col] = "200";
                 transitionTable[107, col] = "200";
                 transitionTable[108, col] = "200";
                 transitionTable[109, col] = "200";
                 transitionTable[111, col] = "200";
                 transitionTable[112, col] = "200";
                 transitionTable[113, col] = "200";
                 transitionTable[115, col] = "200";
                 transitionTable[116, col] = "200";
                 transitionTable[118, col] = "200";
                 transitionTable[119, col] = "200";
                 transitionTable[120, col] = "200";
                 transitionTable[121, col] = "200";
                 transitionTable[123, col] = "200";
                 transitionTable[124, col] = "200";
                 transitionTable[125, col] = "200";
                 transitionTable[127, col] = "200";
                 transitionTable[128, col] = "200";
                 transitionTable[129, col] = "200";
                 transitionTable[130, col] = "200";
                 transitionTable[131, col] = "200";
                 transitionTable[132, col] = "200";
                 transitionTable[133, col] = "200";
                 transitionTable[134, col] = "200";
                 transitionTable[135, col] = "200";
                 transitionTable[137, col] = "200";
                 col++;
                 transitionTable[136, col] = "YES";
             }
        private void readTokensType()
             {
                 tokensTable.Add("Type", "Class");
                 tokensTable.Add("Infer", "Inheritance");
                 tokensTable.Add("If", "Condition");
                 tokensTable.Add("Else", "Condition");
                 tokensTable.Add("Ipok", "Integer");
                 tokensTable.Add("Sipok", "SInteger");
                 tokensTable.Add("Craf", "Character");
                 tokensTable.Add("Sequence", "String");
                 tokensTable.Add("Ipokf", "Float");
                 tokensTable.Add("Sipokf", "SFloat");
                 tokensTable.Add("Valueless", "Void");
                 tokensTable.Add("Rational", "Boolean");
                 tokensTable.Add("Endthis", "Break");
                 tokensTable.Add("However", "Loop");
                 tokensTable.Add("When", "Loop");
                 tokensTable.Add("Respondwith", "Return");
                 tokensTable.Add("Srap", "Struct");
                 tokensTable.Add("Scan", "Switch");
                 tokensTable.Add("Conditionof", "Switch");
                 tokensTable.Add("@", "Start Symbol");
                 tokensTable.Add("^", "Start Symbol");
                 tokensTable.Add("$", "End Symbol");
                 tokensTable.Add("#", "End Symbol");
                 tokensTable.Add("+", "Arithmetic Operation");
                 tokensTable.Add("-", "Arithmetic Operation");
                 tokensTable.Add("*", "Arithmetic Operation");
                 tokensTable.Add("/", "Arithmetic Operation");
                 tokensTable.Add("&&", "Logic operators");
                 tokensTable.Add("||", "Logic operators");
                 tokensTable.Add("~", "Logic operators");
                 tokensTable.Add("==", "relational operators");
                 tokensTable.Add("<", "relational operators");
                 tokensTable.Add(">", "relational operators");
                 tokensTable.Add("!=", "relational operators");
                 tokensTable.Add("<=", "relational operators");
                 tokensTable.Add(">=", "relational operators");
                 tokensTable.Add("=", "Assignment operator");
                 tokensTable.Add("->", "Access Operator");
                 tokensTable.Add("{", "Braces");
                 tokensTable.Add("}", "Braces");
                 tokensTable.Add("[", "Braces");
                 tokensTable.Add("]", "Braces");
                 tokensTable.Add("(", "Braces");
                 tokensTable.Add(")", "Braces");
                 tokensTable.Add("Digit", "Constant");
                 tokensTable.Add("\"", "Quotation Mark");
                 tokensTable.Add("\'", "Quotation Mark");
                 tokensTable.Add("Require", "Inclusion");
                 tokensTable.Add("</", "Multiline Comment start");
                 tokensTable.Add("/>", "Multiline Comment end");
                 tokensTable.Add("***", "Comment");
                 tokensTable.Add(";", "Semi colon");
                 tokensTable.Add(".", "Dot");
             }
        private void Scan()
        {
            for(i=0; i<inputText.Length; i++)
            {
                bool found = true;

                //Check to save token
                CheckToSaveToken();
                GoToNextWord();
                if (i < inputText.Length)
                {
                    //Search for character in transition table
                    SearchForCharInTransitionTable(ref found);
                    if (found)//Character found in header of transition table
                    {
                        if ("0".Equals(transitionTable[curr_state_row, curr_transition_col]))//null
                        {
                            NotToken();
                        }
                        else //Ok
                        {
                            reinializeNextCurrent();
                            checkedString += inputText[i];
                        }
                    }
                    else
                    {
                        NotToken();
                    }
                }
            }
        }

        private void SearchForCharInTransitionTable(ref bool found)
        {
            char c = inputText[i];            
            string c2 = transitionTable[0, curr_transition_col];
            while (!c.Equals(c2[0]))
            {
                curr_transition_col++;
                if (curr_transition_col == transitionTable.GetLength(1))
                {
                    found = false;
                    break;
                }
                c2 = transitionTable[0, curr_transition_col];
            }
        }

        private void CheckToSaveToken()
        {
            if (checkedString.Length > 0 &&
                                (inputText[i] == ' ' || inputText[i] == '\t' ||
                                    inputText[i] == '\n' || inputText[i] == '\r'))
            {
                if (!tokensTable.ContainsKey(checkedString))
                {
                    i -= checkedString.Length;
                    IdentifierOrConstantOrError();
                }
                else
                {
                    AddToList(outputTokensList, checkedString, tokensTable[checkedString]);
                    checkedString = "";
                }
            }
        }

        private void AddToList(List<OutputItems> list, string keyword, string returnToken)
        {
            OutputItems item = new OutputItems();
            item.line = line;
            item.keyword = keyword;
            item.returnToken = returnToken;
            list.Add(item);
        }

        private void NotToken()
        {
            ResetColAndRow();
            i -= checkedString.Length;
            IdentifierOrConstantOrError();            
        }

        private void ResetColAndRow()
        {
            curr_state_row = 1;
            curr_transition_col = 1;
        }

        private void reinializeNextCurrent()
        {
            var state_val = transitionTable[curr_state_row, curr_transition_col];
            for (int i = 1; i < transitionTable.GetLength(0); i++)
            {
                if (transitionTable[i, 0] == state_val)
                {
                    curr_state_row = i;
                    break;
                }
            }
            curr_transition_col = 1;
        }

        private void IdentifierOrConstantOrError()
        {//1478 14ahmed Ahmed
            string temp = "";
            bool isError = false,
                identifierOrConst = true, containsDot = false;
            
            while ((i < inputText.Length) && (inputText[i] != ' ' && inputText[i] != '\t' && inputText[i] != '\r' && inputText[i] != '\n'))//in word
            {//0ahmed =>  error , ah4ed => identifier , 1478 => constant , 14.78 => constant
                bool curIsLetter = CheckLetter(i), curIsDigit = CheckDigit(inputText[i]),
                    starttIsLetter = false, starttIsDigit = false;

                if (temp.Length > 0)
                {
                    starttIsLetter = CheckLetter(0);
                    starttIsDigit = CheckDigit(temp[0]);
                }
                if (temp.Length > 0 &&
                            (
                            (curIsLetter && starttIsDigit) || //1ah
                            (containsDot && curIsDigit && starttIsLetter) //a1.47
                            )) //error
                {
                    isError = true;
                    identifierOrConst = false;
                    IsError(temp);
                    break;
                }
                else if (temp.Length > 0 && inputText[i] == '.' && starttIsDigit) //dot
                {
                    containsDot = true;
                    temp += inputText[i];
                    i++;
                }
                else if (curIsDigit) //digit
                {
                    temp += inputText[i];
                    i++;
                }
                else if (!containsDot && curIsLetter) //letter with no previous dot
                {
                    temp += inputText[i];
                    i++;
                }
                else //error
                {
                    isError = true;
                    identifierOrConst = false;
                    IsError(temp);
                    break;
                }
            }
            if (identifierOrConst && !isError)
            {
                if (CheckDigit(temp[0]))
                {
                    AddToList(outputTokensList, temp, "Constant");
                }
                else
                {
                    AddToList(outputTokensList, temp, "Identifier");
                }                
            }
            checkedString = "";
        }

        private void IsError(string word)
        {
            nOfErrors++;
            word += GoToNextSpace();
            AddToList(outputErrorsList, word, "Error");
            GoToNextWord();
            i--;
        }

        public int GetErrorsNum()
        {
            return nOfErrors;
        }
        public List<OutputItems> GetTokens()
        {
            return outputTokensList;
        }

        private string GoToNextSpace()
        {
            string str = "";
            while (i < inputText.Length && (inputText[i] != ' ' && inputText[i] != '\t' && inputText[i] != '\n'))
            {
                str+= inputText[i];
                i++;
            }
            return str;
        }
        private void GoToNextWord()
        {
            
            if (i < inputText.Length && (inputText[i] == ' ' || inputText[i] == '\t' ||
                    inputText[i] == '\n' || inputText[i] == '\r'))
            {
                ResetColAndRow();
            }
            while (i<inputText.Length && (inputText[i] == ' ' || inputText[i] == '\t' ||
                    inputText[i] == '\n' || inputText[i] == '\r'))
            {                
                if (inputText[i] == '\n')
                    line++;
                i++;
            }
        }

        private bool CheckDigit(char c)
        {
            return c == '0' || c == '1' || c == '2' || c == '3' || c == '4' || c == '5' ||
                c == '6' || c == '7' || c == '8' || c == '9';
        }

        private bool CheckLetter(int i)
        {
            return inputText[i] == 'A' || inputText[i] == 'B' || inputText[i] == 'C' ||
                   inputText[i] == 'D' || inputText[i] == 'E' || inputText[i] == 'F' ||
                   inputText[i] == 'G' || inputText[i] == 'H' || inputText[i] == 'I' ||
                   inputText[i] == 'J' || inputText[i] == 'K' || inputText[i] == 'L' ||
                   inputText[i] == 'M' || inputText[i] == 'N' || inputText[i] == 'O' ||
                   inputText[i] == 'P' || inputText[i] == 'Q' || inputText[i] == 'R' ||
                   inputText[i] == 'S' || inputText[i] == 'T' || inputText[i] == 'U' ||
                   inputText[i] == 'V' || inputText[i] == 'W' || inputText[i] == 'X' ||
                   inputText[i] == 'Y' || inputText[i] == 'Z' ||
                   inputText[i] == 'a' || inputText[i] == 'b' || inputText[i] == 'c' ||
                   inputText[i] == 'd' || inputText[i] == 'e' || inputText[i] == 'f' ||
                   inputText[i] == 'g' || inputText[i] == 'h' || inputText[i] == 'i' ||
                   inputText[i] == 'j' || inputText[i] == 'k' || inputText[i] == 'l' ||
                   inputText[i] == 'm' || inputText[i] == 'n' || inputText[i] == 'o' ||
                   inputText[i] == 'p' || inputText[i] == 'q' || inputText[i] == 'r' ||
                   inputText[i] == 's' || inputText[i] == 't' || inputText[i] == 'u' ||
                   inputText[i] == 'v' || inputText[i] == 'w' || inputText[i] == 'x' ||
                   inputText[i] == 'y' || inputText[i] == 'z' ||
                   inputText[i] == '_';
        }      
    }
}
