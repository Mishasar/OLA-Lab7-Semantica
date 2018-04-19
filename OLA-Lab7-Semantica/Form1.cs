using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OLA_Lab7_Semantica
{

    public partial class Form1 : Form
    {
        string FileToRead = "C:\\programming\\testola7.txt";
        TreeNode TN;
        int MaxText = 1000000;
        int MaxLex = 25;
        string TEMPLex = "";
        char[] ProgText;
        char[] Lex;
        int uk = 0;
        int str = 1, stolb = 1;
        int TempStr = 1, TempStolb = 1;
        Dictionary<int, string> Lexems = new Dictionary<int, string>();

        string TypeOfOperationRes = "";
        public void SetDefault() { RTB.Text = ""; uk = 0; str = 1; stolb = 1; TempStr = 1; TempStolb = 1; TN = new TreeNode(); }

        public void SetUK(int X) { str = TempStr; stolb = TempStolb; uk = X; }
        public int GetUK()
        {
            while (ProgText[uk] == '\n' || (ProgText[uk] == '\t'))
            {
                if (ProgText[uk] == '\n') { str++; stolb = 0; }
                if (ProgText[uk] == '\t') { stolb++; }
                uk++;
            }
            TempStr = str; TempStolb = stolb; return uk;
        }

        int type_Main = 1,
            type_int = 2,
            type_char = 3,
            type_if = 4,
            type_else = 5,
            type_void = 6,
            type_id_or = 7,
            type_int_const = 8,
            type_char_const = 9,
            type_plus = 10,
            type_minus = 11,
            type_mult = 12,
            type_del = 13,
            type_AND = 14,
            type_OR = 15,
            type_Ravno = 16,
            type_NOT = 17,
            type_PointAndCommer = 18,
            type_LeftScob = 19,
            type_RightScob = 20,
            type_LeftSqScob = 21,
            type_RightSqScob = 22,
            type_LeftFigScob = 23,
            type_RightFigScob = 24,
            type_Commer = 25,
            type_UnknownLexema = 26,
            type_bolshe = 27,
            type_menshe = 28,
            type_bolsheravno = 29,
            type_mensheravno = 30,
            type_Ravnoravno = 31,
            type_neravno = 32,
            type_cav = 33,
            


            type_END = 500,





            //ERRORS
            ImpSymbol = 100,
            UnknownLexema = 101,
            ImpossibleId_or = 102,
            PiontAgainInDigit = 103,
            ErrorDigit = 104,
            OverflowMas = 105,
            NotFindEnd = 106,
            EndLess = 107,
            NotFoundMAIN = 108,
            ObyavFunc = 109,
            ErrorWithId_or = 110,
            ErrorAfterId_or = 111,
            NotFoundEndOfBlock = 112,
            NotFoundBeginOfBlock = 113,
            ErrorWithOperator = 114,
            NeedPointWithComer = 115,
            ErrorObrashMass = 116,
            ErrorCallFunc = 117,
            NeedId_or = 118,
            NeedIntConst = 119,
            ObyavIF = 120,
            NeedRavno = 121,
            ErrorMakeoperationScob = 122,
            NeedConstOrId_orOrCallFunc = 123,
            NeedSquareScob = 124,
            Id_orAlreadyExists = 125,
            Id_orNotFound = 126,
            Id_orNotMassiv = 127,
            ImpId_orName = 128,
            IrreducibleFuncType = 129,
            ImpToAssign = 130,
            WrongCallElementOfMassiv = 131,
            IrreduciblePeremType = 132,
            ValueOfFunctionMustBeAssigned = 133,
            ERROR = 200;

        void InitLexType()
        {
            Lexems.Add(1, "main");
            Lexems.Add(2, "int");
            Lexems.Add(3, "char");
            Lexems.Add(4, "if");
            Lexems.Add(5, "else");
            Lexems.Add(6, "void");
            Lexems.Add(7, "Id-or");
            Lexems.Add(8, "int_const");
            Lexems.Add(9, "char_const");
            Lexems.Add(10, "+");
            Lexems.Add(11, "-");
            Lexems.Add(12, "*");
            Lexems.Add(13, "/");
            Lexems.Add(14, "&&");
            Lexems.Add(15, "||");
            Lexems.Add(16, "=");
            Lexems.Add(17, "!");
            Lexems.Add(18, ";");
            Lexems.Add(19, "(");
            Lexems.Add(20, ")");
            Lexems.Add(21, "[");
            Lexems.Add(22, "]");
            Lexems.Add(23, "{");
            Lexems.Add(24, "}");
            Lexems.Add(25, ",");
            Lexems.Add(26, ">");
            Lexems.Add(27, "<");
            Lexems.Add(28, ">=");
            Lexems.Add(29, "<=");
            Lexems.Add(30, "==");
            Lexems.Add(31, "!=");
            Lexems.Add(33, Convert.ToString('"'));



            Lexems.Add(100, "!!!ImpSymbol!!!");
            Lexems.Add(101, "!!!UnknownLexema!!!");
            Lexems.Add(102, "!!!ImpossibleId_or!!!");
            Lexems.Add(103, "!!!PiontAgainInDigit!!!");
            Lexems.Add(104, "!!!ErrorDigit!!!");
            Lexems.Add(105, "!!!OverflowMas!!!");
            Lexems.Add(106, "!!!NotFindEnd!!!");
            Lexems.Add(107, "!!!EndLess!!!");
            Lexems.Add(108, "!!!NotFoundMAIN!!!");
            Lexems.Add(109, "!!!ObyavFunc!!!");
            Lexems.Add(110, "!!!ErrorWithId_or!!!");
            Lexems.Add(111, "!!!ErrorAfterId_or!!!");
            Lexems.Add(112, "!!!NotFoundEndOfBlock!!!");
            Lexems.Add(113, "!!!NotFoundBeginOfBlock!!!");
            Lexems.Add(114, "!!!ErrorWithOperator!!!");
            Lexems.Add(115, "!!!NeedPointWithComer!!!");
            Lexems.Add(116, "!!!ErrorObrashMass!!!");
            Lexems.Add(117, "!!!ErrorCallFunc!!!");
            Lexems.Add(118, "!!!NeedId_or!!!");
            Lexems.Add(119, "!!!NeedIntConst!!!");
            Lexems.Add(120, "!!!ObyavIF!!!");
            Lexems.Add(121, "!!!NeedRavno!!!");
            Lexems.Add(122, "!!!NotCorectPrisvaivanie!!!");
            Lexems.Add(123, "!!!NeedConstOrId_orOrCallFunc!!!");
            Lexems.Add(124, "!!!NeedSquareScob!!!");
            Lexems.Add(500, "#");
        }

        void WriteLex(string TEMPLex, int X)
        {
            //RTB.Text +=(TEMPLex + " - " + X); 
        }

        void PrintError(int TypeError)
        {
            switch (TypeError)
            {
                case 100:
                    RTB.Text += ("!!!ERORR!!!\nНедопустимый символ! Cтрока " + str + ", столбец " + stolb + ".\nТип ошибки: " + TypeError);
                    break;
                case 101:
                    RTB.Text += ("!!!ERORR!!!\nНеизвестная лексема! Cтрока " + str + ", столбец " + stolb + ".\nТип ошибки: " + TypeError);
                    break;
                case 102:
                    RTB.Text += ("!!!ERORR!!!\nНедопустимый идентификатор! Cтрока " + str + ", столбец " + stolb + ".\nТип ошибки: " + TypeError);
                    break;
                case 103:
                    RTB.Text += ("!!!ERORR!!!\nВторая точка в числе! Cтрока " + str + ", столбец " + stolb + ".\nТип ошибки: " + TypeError + TypeError);
                    break;
                case 104:
                    RTB.Text += ("!!!ERORR!!!\nОжидалась цифра или ',' или ';'! Cтрока " + str + ", столбец " + stolb + ".\nТип ошибки: " + TypeError);
                    break;
                case 105:
                    RTB.Text += ("!!!ERORR!!!\nДлинна лексемы больше размера буффера (переполнение)! Cтрока " + str + ", столбец " + stolb + ".\nТип ошибки: " + TypeError);
                    break;
                case 106:
                    RTB.Text += ("!!!ERORR!!!\nНе найден конец программы!\nТип ошибки: " + TypeError);
                    break;
                case 107:
                    RTB.Text += ("!!!ERORR!!!\nНе найден конец программы(Не закрыт многострочный коментарий)!\nТип ошибки: " + TypeError);
                    break;
                case 108:
                    RTB.Text += ("!!!ERORR!!!\nНе найдена функция main()" + TypeError);
                    break;
                case 109:
                    RTB.Text += ("!!!ERORR!!!\nОбъявление функции!!! Cтрока " + str + ", столбец " + stolb + ".\nТип ошибки: " + TypeError);
                    break;
                case 110:
                    RTB.Text += ("!!!ERORR!!!\nОжидался идентификатор!!! Cтрока " + str + ", столбец " + stolb + ".\nТип ошибки: " + TypeError);
                    break;
                case 111:
                    RTB.Text += ("!!!ERORR!!!\nОжидалось ';', '!', '+', '-', '*', '/', '(' или '['!!! Cтрока " + str + ", столбец " + stolb + ".\nТип ошибки: " + TypeError);
                    break;
                case 112:
                    RTB.Text += ("!!!ERORR!!!\nОжидалось }, конец блока!!! Cтрока " + str + ", столбец " + stolb + ".\nТип ошибки: " + TypeError);
                    break;
                case 113:
                    RTB.Text += ("!!!ERORR!!!\nОжидалось {, начало блока!!! Cтрока " + str + ", столбец " + stolb + ".\nТип ошибки: " + TypeError);
                    break;
                case 114:
                    RTB.Text += ("!!!ERORR!!!\nОжидалось int, float, ид-ор, if, return, '[' или ';'!!! Cтрока " + str + ", столбец " + stolb + ".\nТип ошибки: " + TypeError);
                    break;
                case 115:
                    RTB.Text += ("!!!ERORR!!!\nОжидалось ';'!!! Cтрока " + str + ", столбец " + stolb + ".\nТип ошибки: " + TypeError);
                    break;
                case 116:
                    RTB.Text += ("!!!ERORR!!!\nНекоректное обращение к массиву (необходима ']')!!! Cтрока " + str + ", столбец " + stolb + ".\nТип ошибки: " + TypeError);
                    break;
                case 117:
                    RTB.Text += ("!!!ERORR!!!\nНекоректное обращение к функции (найден параметр или необходима ')' )!!! Cтрока " + str + ", столбец " + stolb + ".\nТип ошибки: " + TypeError);
                    break;
                case 118:
                    RTB.Text += ("!!!ERORR!!!\nНеобходим ид-ор (переменная или элемент массива)!!! Cтрока " + str + ", столбец " + stolb + ".\nТип ошибки: " + TypeError);
                    break;
                case 119:
                    RTB.Text += ("!!!ERORR!!!\nНужена целочисленная константа типа int!!! Cтрока " + str + ", столбец " + stolb + ".\nТип ошибки: " + TypeError);
                    break;
                case 120:
                    RTB.Text += ("!!!ERORR!!!\nНекоректное объявление if!!! Cтрока " + str + ", столбец " + stolb + ".\nТип ошибки: " + TypeError);
                    break;
                case 121:
                    RTB.Text += ("!!!ERORR!!!\nНекоректное присваивание, требуется '='!!! Cтрока " + str + ", столбец " + stolb + ".\nТип ошибки: " + TypeError);
                    break;
                case 122:
                    RTB.Text += ("!!!ERORR!!!\nТребуется ')' !!! Cтрока " + str + ", столбец " + stolb + ".\nТип ошибки: " + TypeError);
                    break;
                case 123:
                    RTB.Text += ("!!!ERORR!!!\nНужна константа, идентификатор или вызов функции!!! Cтрока " + str + ", столбец " + stolb + ".\nТип ошибки: " + TypeError);
                    break;
                case 124:
                    RTB.Text += ("!!!ERORR!!!\nТребуется ']' (объявление массива или обращение к элементу)!!! Cтрока " + str + ", столбец " + stolb + ".\nТип ошибки: " + TypeError);
                    break;
                case 125:
                    RTB.Text += ("!!!ERORR!!!\nИдентификатор " + "'" + TEMPLex + "' уже объявлен!!! Cтрока " + str + ", столбец " + stolb + ".\nТип ошибки: " + TypeError);
                    break;
                case 126:
                    RTB.Text += ("!!!ERORR!!!\nИдентификатор " + "'" + TEMPLex + "' не объявлен!!! Cтрока " + str + ", столбец " + stolb + ".\nТип ошибки: " + TypeError);
                    break;
                case 127:
                    RTB.Text += ("!!!ERORR!!!\nНе удаётся применить индексирование через [] к выражению типа 'int'!!! Cтрока " + str + ", столбец " + stolb + ".\nТип ошибки: " + TypeError);
                    break;
                case 128:
                    RTB.Text += ("!!!ERORR!!!\nИдентификатор имеет недопустимое имя!!! Cтрока " + str + ", столбец " + stolb + ".\nТип ошибки: " + TypeError);
                    break;
                case 129:
                    RTB.Text += ("!!!ERORR!!!\nНедопустимый возвращаемый тип: возвращаемый тип: " + TN.ObjectType + ", тип выражения: " + TypeOfOperationRes + "!!! Cтрока " + str + ", столбец " + stolb + ".\nТип ошибки: " + TypeError);
                    break;
                case 130:
                    RTB.Text += RTB.Text += ("!!!ERORR!!!\nНе удается преобразовать тип '" + TEMPLex + "' в '" + TEMPLex + "[]'!!! Cтрока " + str + ", столбец " + stolb + ".\nТип ошибки: " + TypeError);
                    break;
                case 131:
                    RTB.Text += ("!!!ERORR!!!\nНекоректное обращение к массиву!!! Cтрока " + str + ", столбец " + stolb + ".\nТип ошибки: " + TypeError);
                    break;
                case 132:
                    RTB.Text += ("!!!ERORR!!!\nНедопустимый тип присвоиемого значения: переменная: " + TN.ObjectType + ", присвояемый тип: " + TypeOfOperationRes + "!!! Cтрока " + str + ", столбец " + stolb + ".\nТип ошибки: " + TypeError);
                    break;
                case 133:
                    RTB.Text += ("!!!ERORR!!!\nЗначение функции '"+ TN.NAME +"() ' должно быть присвоенно!!! Cтрока " + str + ", столбец " + stolb + ".\nТип ошибки: " + TypeError);
                    break;
                default:
                    RTB.Text += ("!!!UNKNOWN ERORR!!! Cтрока " + str + ", столбец " + stolb + ".\nТип ошибки: " + TypeError);
                    break;
            }
        }
        public Form1()
        {
            InitializeComponent();
            InitLexType();
            ProgText = new char[MaxText];
            Lex = new char[MaxLex];
        }

        public string TypeConversionTable(string Operat, string T1, string T2)
        {
            string res = "";
            if (Operat == "+" || Operat == "-" || Operat == "*" || Operat == "/")
            {
                if (T1 == "int" && T2 == "int") res = "int";
                if (T1 == "int" && T2 == "float" || T1 == "float" && T2 == "int" || T1 == "float" && T2 == "float") res = "float";
            }
            if (Operat == "==" || Operat == "!" || Operat == "&&" || Operat == "||")
            {
                if (T1 == "int" && T2 == "int" || T1 == "int" && T2 == "float" || T1 == "float" && T2 == "int" || T1 == "float" && T2 == "float") res = "int";
            }
            if (Operat == "=")
            {
                if (T1 == "int" && T2 == "int") res = "int";
                if (T1 == "int" && T2 == "float") res = "ERROR";//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                if (T1 == "float" && T2 == "int" || T1 == "float" && T2 == "float") res = "float";
            }
            return res;
        }

        private void TestProgCode_Click(object sender, EventArgs e)
        {
            SetDefault();
            StreamReader ReFile;
            FileStream MF;
            string Ts = "", Line = "";
            MF = new FileStream(FileToRead, FileMode.Open, FileAccess.Read);
            ReFile = new StreamReader(MF);
            while ((Line = ReFile.ReadLine()) != null)
            {
                Ts += Line + "\n";
            }
            Ts += '#';
            ReFile.Close();
            ProgText = Ts.ToCharArray();
            S();
        }
        public bool S()
        {
            ///
            TreeNode TempTN = new TreeNode();
            TN.ObjectType = "int"; TN.NAME = "int";
            TempTN.ObjectType = "char"; TempTN.NAME = "char";
            TN.LeftN = TempTN;
            TN.LeftN.Parent = TN;
            TN = TN.LeftN;
            ///
            int TempUK = GetUK();
            int type = Scaner();
            SetUK(TempUK);
            while (Lexems[type] == "int" || Lexems[type] == "char")
            {
                if (!OpisanieFunk()) { return false; }
                TempUK = GetUK();
                type = Scaner();
                SetUK(TempUK);
            }
            type = Scaner();
            if (Lexems[type] == "main")
            {
                TempUK = GetUK();
                type = Scaner();
                if (Lexems[type] == "(")
                {
                    TempUK = GetUK();
                    type = Scaner();
                    if (Lexems[type] == ")")
                    {
                        if (!BLOCK()) { return false; }
                    }
                    else { SetUK(TempUK); PrintError(ObyavFunc); return false; }
                }
                else { SetUK(TempUK); PrintError(ObyavFunc); return false; }
            }
            else { SetUK(TempUK); PrintError(NotFoundMAIN); return false; }
            RTB.Text += (" Ошибок не обнаружено. Проверка завершена успешно.");
            return true;
        }
        public bool OpisanieFunk()
        {
            int TempUK = GetUK();
            int type = Scaner();
            if (Lexems[type] == "int" || Lexems[type] == "float")
            {
                ///
                string RemObjType = Lexems[type];
                ///
                TempUK = GetUK();
                type = Scaner();
                if (Lexems[type] == "Id-or")
                {
                    ///
                    if (TEMPLex == "int" || TEMPLex == "float") { SetUK(TempUK); PrintError(ImpId_orName); return false; }
                    TreeNode RemTN = new TreeNode();
                    TreeNode TempTN = new TreeNode();
                    RemTN = TN;
                    while (RemTN != null)
                    {
                        if (RemTN.NAME == TEMPLex) { SetUK(TempUK); PrintError(Id_orAlreadyExists); return false; }
                        RemTN = RemTN.Parent;
                    }
                    ///
                    TempTN.NAME = TEMPLex;
                    TempTN.FUNC = true;
                    TempTN.ObjectType = RemObjType;
                    TempTN.Parent = TN;
                    TN.LeftN = TempTN;
                    TN = TN.LeftN;
                    ///
                    TempUK = GetUK();
                    type = Scaner();
                    if (Lexems[type] == "(")
                    {
                        TempUK = GetUK();
                        type = Scaner();
                        if (Lexems[type] == ")")
                        {
                            if (!BLOCK()) { return false; }
                        }
                        else { SetUK(TempUK); PrintError(ObyavFunc); return false; }
                    }
                    else { SetUK(TempUK); PrintError(ObyavFunc); return false; }
                }
                else { SetUK(TempUK); PrintError(ErrorWithId_or); return false; }
            }
            return true;
        }

        public bool BLOCK()
        {
            ///
            TreeNode RemTN = new TreeNode();
            ///
            int TempUK = GetUK();
            int type = Scaner();
            if (Lexems[type] == "{")
            {
                ///
                RemTN = TN;
                TreeNode TempTN = new TreeNode();
                TempTN.NAME = "!!!EMPTY!!!";
                TempTN.Parent = TN;
                TN.RightN = TempTN;
                TN = TN.RightN;
                ///
                TempUK = GetUK();
                type = Scaner();
                SetUK(TempUK);
                while (Lexems[type] == "Id-or" || Lexems[type] == "if" || Lexems[type] == "int" || Lexems[type] == "float" || Lexems[type] == "{" || Lexems[type] == "return" || Lexems[type] == ";")
                {
                    if (!OneOperator()) { return false; }
                    TempUK = GetUK();
                    type = Scaner();
                    SetUK(TempUK);
                }
                TempUK = GetUK();
                type = Scaner();
                if (Lexems[type] != "}")
                { SetUK(TempUK); PrintError(NotFoundEndOfBlock); return false; }
            }
            else { SetUK(TempUK); PrintError(NotFoundBeginOfBlock); return false; }
            ///
            while (RemTN.NAME != TN.NAME)
            {
                TN = TN.Parent;
            }
            ///
            return true;
        }

        bool OneOperator()
        {
            int TempUK = GetUK();
            int type = Scaner();
            if (Lexems[type] == "Id-or") { SetUK(TempUK); if (!Prisvaivanie()) { return false; } }
            else
            {
                if (Lexems[type] == "if")
                {
                    SetUK(TempUK);
                    if (!IFF()) { return false; }
                }
                else
                {
                    if (Lexems[type] == "int" || Lexems[type] == "float") { SetUK(TempUK); if (!OpisaniePerem()) { return false; } }
                    else
                    {
                        if (Lexems[type] == "{") { SetUK(TempUK); if (!BLOCK()) { return false; } }
                        else
                        {
                            if (Lexems[type] == "return")
                            {
                                TempUK = GetUK();
                                type = Scaner();
                                SetUK(TempUK);
                                if (!A0()) { return false; }
                                ///
                                TreeNode RemTN = new TreeNode();
                                RemTN = TN;
                                while (true)
                                {
                                    if (TN.FUNC)
                                    {
                                        string temp = TypeConversionTable("=", TN.ObjectType, TypeOfOperationRes);
                                        if (temp == "ERROR") { SetUK(TempUK); PrintError(IrreduciblePeremType); return false; }
                                        break;
                                    }
                                    TN = TN.Parent;
                                }
                                TN = RemTN;
                                ///
                                type = Scaner();
                                if (Lexems[type] != ";") { SetUK(TempUK); PrintError(NeedPointWithComer); return false; }
                                TempUK = GetUK(); SetUK(TempUK);
                            }
                            else
                            {
                                if (Lexems[type] != ";") { SetUK(TempUK); PrintError(ErrorWithOperator); return false; }
                            }
                        }
                    }
                }
            }
            return true;
        }

        bool Prisvaivanie()
        {
            int TempUK = GetUK();
            int type = Scaner();
            if (Lexems[type] != "Id-or") { SetUK(TempUK+2); PrintError(ErrorWithId_or); return false; }
            ///
            string TempNameId_or = TEMPLex;
            string TypeId_or = "";
            TreeNode RemTN = new TreeNode();
            TreeNode TempTN = new TreeNode();
            RemTN = TN;
            while (true)
            {
                if (TN == null) { SetUK(TempUK); PrintError(Id_orNotFound); return false; }
                if (TN.FUNC && TN.NAME == TEMPLex) { SetUK(TempUK); PrintError(ValueOfFunctionMustBeAssigned); return false; }
                if (TN.NAME == TEMPLex)
                {
                     TempTN = TN; TypeId_or = TN.ObjectType; break;
                }
                TN = TN.Parent;
            }
            ///
            TempUK = GetUK();
            type = Scaner();
            if (Lexems[type] == "[")
            {
                ///
                if (!TN.MAS) { SetUK(TempUK); TEMPLex = TempNameId_or; PrintError(Id_orNotMassiv); return false; }
                ///
                if (!A0()) { return false; }
                ///
                if (TypeOfOperationRes != "int") { SetUK(TempUK); PrintError(WrongCallElementOfMassiv); return false; }
                TN = RemTN;
                ///
                TempUK = GetUK();
                type = Scaner();
                if (Lexems[type] == "]")
                {
                    TempUK = GetUK();
                    type = Scaner();
                }
                else { SetUK(TempUK); PrintError(NeedSquareScob); return false; }
            }
            if (Lexems[type] == "=")
            {
                if (!A0()) { return false; }
                ///
                if (TN.PEREM)
                {
                    string temp = TypeConversionTable("=", TN.ObjectType, TypeOfOperationRes);
                    if (temp == "ERROR") { SetUK(TempUK); PrintError(IrreduciblePeremType); return false; }
                }
                else { SetUK(TempUK); PrintError(ImpToAssign); return false; }
                TN = RemTN;
                ///
                TempUK = GetUK();
                type = Scaner();
                if (Lexems[type] != ";") { SetUK(TempUK); PrintError(NeedPointWithComer); return false; }
            }
            else { SetUK(TempUK); PrintError(NeedRavno); return false; }
            return true;
        }
        bool OpisaniePerem()
        {
            int TempUK = GetUK();
            int type = Scaner();
            if (Lexems[type] == "int" || Lexems[type] == "float")
            {
                ///
                string RemObjType = Lexems[type];
                ///
                do
                {
                    TempUK = GetUK();
                    type = Scaner();
                    if (Lexems[type] == "Id-or")
                    {
                        ///
                        TreeNode RemTN = new TreeNode();
                        TreeNode TempTN = new TreeNode();
                        RemTN = TN;
                        if (RemObjType != "int" && RemObjType != "float") { SetUK(TempUK); PrintError(ImpId_orName); return false; }
                        while (TN != null)
                        {
                            if (TN.NAME == TEMPLex) { SetUK(TempUK); PrintError(Id_orAlreadyExists); return false; }
                            TN = TN.Parent;
                        }
                        ///
                        TN = RemTN;
                        TempTN.NAME = TEMPLex;
                        TempTN.ObjectType = RemObjType;
                        TempTN.PEREM = true;
                        TempTN.Parent = TN;
                        TN.LeftN = TempTN;
                        TN = TN.LeftN;
                        ///
                        TempUK = GetUK();
                        type = Scaner();
                        if (Lexems[type] == ";")
                            SetUK(TempUK);
                        if (Lexems[type] != ";")
                        {
                            if (Lexems[type] == "=")
                            {
                                if (!A0()) { return false; }
                                ///
                                string temp = TypeConversionTable("=", RemObjType, TypeOfOperationRes);
                                if (temp == "ERROR") { SetUK(TempUK); PrintError(IrreduciblePeremType); return false; }
                                ///
                                TempUK = GetUK();
                                type = Scaner();
                                SetUK(TempUK);
                                //if (Lexems[type] != ";") { SetUK(TempUK); PrintError(NeedPointWithComer); return false; }
                            }
                            else
                            {
                                if (Lexems[type] == "[")
                                {
                                    TempUK = GetUK();
                                    type = Scaner();
                                    if (Lexems[type] == "int_const")
                                    {
                                        ///
                                        TN.MAS = true;
                                        TN.PEREM = false;
                                        TN.MASLength = Convert.ToInt32(TEMPLex);
                                        ///
                                        TempUK = GetUK();
                                        type = Scaner();
                                        if (Lexems[type] != "]") { SetUK(TempUK); PrintError(NeedSquareScob); return false; }
                                    }
                                    else { SetUK(TempUK); PrintError(NeedIntConst); return false; }
                                }
                                else { SetUK(TempUK); PrintError(NeedRavno); return false; }
                            }
                        }
                    }
                    else { SetUK(TempUK); PrintError(NeedId_or); return false; }
                    TempUK = GetUK();
                    type = Scaner();
                } while ((Lexems[type] == ","));
                TempUK = GetUK();
                type = Scaner();
                SetUK(TempUK);
            }
            return true;
        }
        bool IFF()
        {
            int TempUK = GetUK();
            int type = Scaner();
            if (Lexems[type] == "if")
            {
                TempUK = GetUK();
                type = Scaner();
                if (Lexems[type] == "(")
                {
                    if (!A0()) { return false; }
                    TempUK = GetUK();
                    type = Scaner();
                    if (Lexems[type] == ")")
                    {
                        if (!OneOperator()) { return false; }
                        TempUK = GetUK();
                        type = Scaner();
                        SetUK(TempUK);
                        if (Lexems[type] == "else")
                        {
                            type = Scaner();
                            if (!OneOperator()) { return false; }
                        }
                    }
                    else { SetUK(TempUK); PrintError(ObyavIF); return false; }
                }
                else { SetUK(TempUK); PrintError(ObyavIF); return false; }
            }
            return true;
        }
        bool A0()
        {
            ///
            string Oper1 = "";
            string Oper2 = "";
            string Operation = "";
            ///
            int TempUK = GetUK();
            int type = Scaner();
            if (Lexems[type] == "!") { TempUK = GetUK(); type = Scaner(); }
            else
            {
                if (Lexems[type] == "+") { TempUK = GetUK(); type = Scaner(); }
                else
                {
                    if (Lexems[type] == "-") { TempUK = GetUK(); type = Scaner(); }
                }
            }

            if (Lexems[type] == "int_const" || Lexems[type] == "float_const" || Lexems[type] == "(" || Lexems[type] == "Id-or")
            {
                SetUK(TempUK);
                if (!A1()) { return false; }
                /**/
                Oper1 = TypeOfOperationRes;
                TempUK = GetUK();
                type = Scaner();
                while (Lexems[type] == "&&" || Lexems[type] == "||")
                {
                    /**/
                    Operation = Lexems[type];
                    if (!A1()) { return false; }
                    ///
                    Oper2 = TypeOfOperationRes;
                    string temp = TypeConversionTable(Operation, Oper1, Oper2);
                    if (temp == "ERROR") { SetUK(TempUK); PrintError(IrreduciblePeremType); return false; }
                    Oper1 = temp;
                    ///
                    TempUK = GetUK();
                    type = Scaner();
                }
                SetUK(TempUK);
            }
            else { SetUK(TempUK); PrintError(NeedConstOrId_orOrCallFunc); return false; }
            TypeOfOperationRes = Oper1;
            return true;
        }
        bool A1()
        {
            ///
            string Oper1 = "";
            string Oper2 = "";
            string Operation = "";
            ///
            int TempUK = GetUK();
            int type = Scaner();
            if (Lexems[type] == "int_const" || Lexems[type] == "float_const" || Lexems[type] == "(" || Lexems[type] == "Id-or")
            {
                SetUK(TempUK);
                if (!A2()) { return false; }
                /**/
                Oper1 = TypeOfOperationRes;
                TempUK = GetUK();
                type = Scaner();
                while (Lexems[type] == "+" || Lexems[type] == "-")
                {
                    /**/
                    Operation = Lexems[type];
                    if (!A2()) { return false; }
                    ///
                    Oper2 = TypeOfOperationRes;
                    string temp = TypeConversionTable(Operation, Oper1, Oper2);
                    if (temp == "ERROR") { SetUK(TempUK); PrintError(IrreduciblePeremType); return false; }
                    Oper1 = temp;
                    ///
                    TempUK = GetUK();
                    type = Scaner();
                }
                SetUK(TempUK);
            }
            else { SetUK(TempUK); PrintError(NeedConstOrId_orOrCallFunc); return false; }
            TypeOfOperationRes = Oper1;
            return true;
        }
        bool A2()
        {
            ///
            string Oper1 = "";
            string Oper2 = "";
            string Operation = "";
            ///
            int TempUK = GetUK();
            int type = Scaner();
            if (Lexems[type] == "int_const" || Lexems[type] == "float_const" || Lexems[type] == "(" || Lexems[type] == "Id-or")
            {
                SetUK(TempUK);
                if (!A3()) { return false; }
                /**/
                Oper1 = TypeOfOperationRes;
                TempUK = GetUK();
                type = Scaner();
                while (Lexems[type] == "*" || Lexems[type] == "/")
                {
                    /**/
                    Operation = Lexems[type];
                    if (!A3()) { return false; }
                    ///
                    Oper2 = TypeOfOperationRes;
                    string temp = TypeConversionTable(Operation, Oper1, Oper2);
                    if (temp == "ERROR") { SetUK(TempUK); PrintError(IrreduciblePeremType); return false; }
                    Oper1 = temp;
                    ///
                    TempUK = GetUK();
                    type = Scaner();
                }
                SetUK(TempUK);
            }
            else { SetUK(TempUK); PrintError(NeedConstOrId_orOrCallFunc); return false; }
            TypeOfOperationRes = Oper1;
            return true;
        }
        bool A3()
        {
            ///
            string Oper1 = "";
            ///
            int TempUK = GetUK();
            int type = Scaner();
            if (Lexems[type] == "int_const" || Lexems[type] == "float_const") { Oper1 = Lexems[type].Replace("_const", ""); }
            else
            {
                if (Lexems[type] == "(")
                {
                    if (!A0()) { return false; }
                    Oper1 = TypeOfOperationRes;
                    TempUK = GetUK();
                    type = Scaner();
                    if (Lexems[type] != ")") { SetUK(TempUK); PrintError(ErrorMakeoperationScob); return false; }
                }
                else
                {
                    if (Lexems[type] == "Id-or")
                    {
                        ///
                        string TempNameId_or = TEMPLex;
                        TreeNode RemTN = new TreeNode();
                        TreeNode TempTN = new TreeNode();
                        RemTN = TN;
                        while (true)
                        {
                            if (TN == null) { SetUK(TempUK); PrintError(Id_orNotFound); return false; }
                            if (TN.NAME == TEMPLex) { TempTN = TN; Oper1 = TN.ObjectType; break; }
                            TN = TN.Parent;
                        }
                        TN = RemTN;
                        ///
                        TempUK = GetUK();
                        type = Scaner();
                        if (Lexems[type] == "[")
                        {
                            /**/
                            if (!TempTN.MAS) { SetUK(TempUK); TEMPLex = TempNameId_or; PrintError(Id_orNotMassiv); return false; }
                            TempUK = GetUK();
                            type = Scaner();
                            if (Lexems[type] == "int_const" || Lexems[type] == "Id-or")
                            {
                                if (Lexems[type] == "Id-or")
                                {
                                    ///
                                    RemTN = new TreeNode();
                                    TempTN = new TreeNode();
                                    RemTN = TN;
                                    while (true)
                                    {
                                        if (TN == null) { SetUK(TempUK); PrintError(Id_orNotFound); return false; }
                                        if (TN.NAME == TEMPLex) { TempTN = TN; Oper1 = TN.ObjectType; break; }
                                        TN = TN.Parent;
                                    }
                                    TN = RemTN;
                                    ///
                                }
                                TempUK = GetUK();
                                type = Scaner();
                                if (Lexems[type] != "]") { SetUK(TempUK); PrintError(ErrorObrashMass); return false; }
                            }
                            else { SetUK(TempUK); PrintError(NeedIntConst); return false; }
                        }
                        else { SetUK(TempUK); }
                        TempUK = GetUK();
                        type = Scaner();
                        if (Lexems[type] == "(")
                        {
                            ///
                            RemTN = new TreeNode();
                            TempTN = new TreeNode();
                            RemTN = TN;
                            while (true)
                            {
                                if (TN == null) { SetUK(TempUK); PrintError(Id_orNotFound); return false; }
                                if (TN.NAME == TempNameId_or) { TempTN = TN; Oper1 = TN.ObjectType; break; }
                                TN = TN.Parent;
                            }
                            TN = RemTN;
                            ///
                            TempUK = GetUK();
                            type = Scaner();
                            if (Lexems[type] != ")") { SetUK(TempUK); PrintError(ErrorCallFunc); return false; }
                        }
                        else { SetUK(TempUK); }
                    }
                    else { SetUK(TempUK); PrintError(NeedConstOrId_orOrCallFunc); return false; }
                }
            }
            TypeOfOperationRes = Oper1;
            return true;
        }
        public int Scaner()
        {
            int type = 0;
            TEMPLex = "";
            int iter = 0;
            char[] l = new char[MaxLex];
            for (int i = 0; i < MaxLex; i++) l[i] = '/';
            //Пропуск пробелов и переносов строк

            if (ProgText[uk] == '\n') { uk++; str++; stolb = 1; }
            if (uk == ProgText.Length) { PrintError(NotFindEnd); return NotFindEnd; }
            while ((ProgText[uk] == ' ') || (ProgText[uk] == '\t') || (ProgText[uk] == '\n')) { if (ProgText[uk] == '\n') { str++; stolb = 0; }; stolb++; uk++; if (uk == ProgText.Length) { PrintError(NotFindEnd); return NotFindEnd; } }

            //Пропуск комментариев
            if (ProgText[uk] == '/' && ProgText[uk + 1] == '/')
            {
                stolb = 1;
                uk += 2;
                while (ProgText[uk] != '\n' || (ProgText[uk] == '\t')) { if (ProgText[uk] == '\n') { str++; stolb = 0; } if (ProgText[uk] == '\t') { stolb++; } uk++; }
            }
            if (ProgText[uk] == '/' && ProgText[uk + 1] == '*')
            {
                uk += 2;

                while (true) { if (ProgText[uk] == '\n') { str++; } if (ProgText[uk] == '#') { PrintError(EndLess); return EndLess; } if (ProgText[uk] == '*' && ProgText[uk + 1] == '/') { uk++; break; } uk++; }
                uk++;
            }

            //Пропуск пробелов и переносов строк
            while ((ProgText[uk] == ' ') || (ProgText[uk] == '\t') || (ProgText[uk] == '\n')) { if (ProgText[uk] == '\n') { str++; stolb = 0; }; stolb++; uk++; if (uk == ProgText.Length) { PrintError(NotFindEnd); return NotFindEnd; } }

            //Конец программы

            if (ProgText[uk] == '#')
            {
                l[0] = ProgText[uk]; return type_END; }

            else
            {
                if (Char.IsLetter(ProgText[uk]))
                {
                    // считывание всей лексемы
                    while (true)
                    {
                        l[iter] = ProgText[uk]; uk++; iter++; stolb++;
                        if (iter >= MaxLex) { stolb -= TEMPLex.Length; PrintError(OverflowMas); return OverflowMas; }
                        if (ProgText[uk] == ' ') break;
                        if (ProgText[uk] == '.') break;
                        if (ProgText[uk] == ',') break;
                        if (ProgText[uk] == ';') break;
                        if (ProgText[uk] == ')') break;
                        if (ProgText[uk] == '(') break;
                        if (ProgText[uk] == '[') break;
                        if (ProgText[uk] == ']') break;
                        if (ProgText[uk] == '{') break;
                        if (ProgText[uk] == '}') break;
                        if (ProgText[uk] == '=') break;
                        if (ProgText[uk] == '+') break;
                        if (ProgText[uk] == '-') break;
                        if (ProgText[uk] == '/') break;
                        if (ProgText[uk] == '*') break;
                        if (ProgText[uk] == '!') break;
                        if (ProgText[uk] == '|') break;
                        if (ProgText[uk] == '&') break;
                        if (ProgText[uk] == ';') break;
                        if (ProgText[uk] == '\n') break;
                        if (ProgText[uk] == '\t') break;
                    }
                    //Идентификация лексемы
                    

                    iter = 0;
                    while (l[iter] != '/')
                    { TEMPLex += l[iter]; iter++; }
                    if (TEMPLex == "void")
                    {
                        WriteLex(TEMPLex, type_void);
                        return type_void;
                    }
                    if (TEMPLex == "main")
                    {
                        WriteLex(TEMPLex, type_Main);
                        return type_Main;
                    }
                    if (TEMPLex == "int") { WriteLex(TEMPLex, type_int); return type_int; }
                    if (TEMPLex == "char") { WriteLex(TEMPLex, type_char); return type_char; }
                    if (TEMPLex == "if") { WriteLex(TEMPLex, type_if); return type_if; }
                    if (TEMPLex == "else") { WriteLex(TEMPLex, type_else); return type_else; }
                    return type_id_or;



                }
                if (Char.IsDigit(ProgText[uk]))
                {
                    // предположение, что считываемое число - целая константа
                    type = type_int_const;

                    if (ProgText[uk] == '0')
                    {
                        l[iter] = ProgText[uk];
                        uk++; iter++; stolb++;

                        //если дальше не ' ', ',' и не ';' то выдаем ошибку
                        if (iter == 1)
                        {
                            if (ProgText[uk] != '.')
                                if (!Char.IsDigit(ProgText[uk]))
                                    if (ProgText[uk] == '+' || ProgText[uk] == '-' || ProgText[uk] == '*' || ProgText[uk] == '/' || ProgText[uk] == '=' || ProgText[uk] == '=' || ProgText[uk] == ';' || ProgText[uk] == '(' || ProgText[uk] == ')' || ProgText[uk] == '[' || ProgText[uk] == ']' || ProgText[uk] == '{' || ProgText[uk] == '}' || ProgText[uk] == ',' || ProgText[uk] == '&' || ProgText[uk] == '|')
                                    { }
                                    else
                                    {
                                        if (ProgText[uk] != ' ' && ProgText[uk] != '\t' && ProgText[uk] != '\n')
                                            if (!(Char.IsLetter(ProgText[uk])))
                                            { PrintError(ErrorDigit); return ErrorDigit; }
                                            else { PrintError(ImpossibleId_or); return ImpossibleId_or; }
                                        else { }
                                    }
                                else { PrintError(ErrorDigit); return ErrorDigit; }
                        }
                        type = type_int_const;
                        

                    }
                    else
                    {
                        l[iter] = ProgText[uk];
                        uk++; iter++; stolb++;
                        while (true)
                        {
                            if (ProgText[uk] == ' ') break;
                            if (ProgText[uk] == '.') break;
                            if (ProgText[uk] == ',') break;
                            if (ProgText[uk] == ';') break;
                            if (ProgText[uk] == ')') break;
                            if (ProgText[uk] == '(') break;
                            if (ProgText[uk] == '[') break;
                            if (ProgText[uk] == ']') break;
                            if (ProgText[uk] == '{') break;
                            if (ProgText[uk] == '}') break;
                            if (ProgText[uk] == '=') break;
                            if (ProgText[uk] == '+') break;
                            if (ProgText[uk] == '-') break;
                            if (ProgText[uk] == '/') break;
                            if (ProgText[uk] == '*') break;
                            if (ProgText[uk] == '!') break;
                            if (ProgText[uk] == '|') break;
                            if (ProgText[uk] == '&') break;
                            if (ProgText[uk] == ';') break;
                            if (ProgText[uk] == '\n') break;
                            if (ProgText[uk] == '\t') break;
                            if (!Char.IsDigit(ProgText[uk])) { PrintError(ErrorDigit); return ErrorDigit; }
                            l[iter] = ProgText[uk];
                            uk++; iter++; stolb++;
                            if (iter >= MaxLex) { stolb -= TEMPLex.Length; PrintError(OverflowMas); return OverflowMas; }
                        }
                        
                    }
                    iter = 0;
                    while (l[iter] != '/')
                    { TEMPLex += l[iter]; iter++; }
                    WriteLex(TEMPLex, type);
                    return type;
                }
                TEMPLex += ProgText[uk];
                if (ProgText[uk] == '>') { stolb++; uk++; if (ProgText[uk] == '=') { uk++; WriteLex(TEMPLex, type_bolsheravno); return type_bolsheravno; } else { uk++; WriteLex(TEMPLex, type_bolshe); return type_bolshe; } }
                if (ProgText[uk] == '<') { stolb++; uk++; if (ProgText[uk] == '=') { uk++; WriteLex(TEMPLex, type_mensheravno); return type_mensheravno; } else { uk++; WriteLex(TEMPLex, type_menshe); return type_menshe; } }
                if (ProgText[uk] == '!') { stolb++; uk++; if (ProgText[uk] == '=') { uk++; WriteLex(TEMPLex, type_neravno); return type_neravno; } else { PrintError(UnknownLexema); return UnknownLexema; } }
                if (ProgText[uk] == '"') { stolb++; uk++; TEMPLex = Convert.ToString(ProgText[uk]); WriteLex(TEMPLex, type_cav); uk++; stolb++; TEMPLex = Convert.ToString(ProgText[uk]);
                    if (ProgText[uk] != '"') {
                        //PrintError(charlong); return charlong;
                    }
                    uk++; stolb++; stolb++; WriteLex(TEMPLex, type_char_const); return type_char_const; }
                if (ProgText[uk] == '+') { stolb++; uk++; WriteLex(TEMPLex, type_plus); return type_plus; }
                if (ProgText[uk] == '-') { stolb++; uk++; WriteLex(TEMPLex, type_minus); return type_minus; }
                if (ProgText[uk] == '*') { stolb++; uk++; WriteLex(TEMPLex, type_mult); return type_mult; }
                if (ProgText[uk] == '/') { stolb++; uk++; WriteLex(TEMPLex, type_del); return type_del; }
                if (ProgText[uk] == '&') { stolb++; uk++; if (ProgText[uk] == '&') { uk++; WriteLex(TEMPLex, type_AND); return type_AND; } else { PrintError(UnknownLexema); return UnknownLexema; } }
                if (ProgText[uk] == '|') { stolb++; uk++; if (ProgText[uk] == '|') { uk++; WriteLex(TEMPLex, type_OR); return type_OR; } else { PrintError(UnknownLexema); return UnknownLexema; } }
                if (ProgText[uk] == '=') { stolb++; uk++; if (ProgText[uk] == '=') { uk++; WriteLex(TEMPLex, type_Ravnoravno); return type_Ravnoravno; } else { uk++; WriteLex(TEMPLex, type_Ravno); return type_Ravno; }}
                if (ProgText[uk] == '!') { stolb++; uk++; WriteLex(TEMPLex, type_NOT); return type_NOT; }
                if (ProgText[uk] == ';') { stolb++; uk++; WriteLex(TEMPLex, type_PointAndCommer); return type_PointAndCommer; }
                if (ProgText[uk] == '(') { stolb++; uk++; WriteLex(TEMPLex, type_LeftScob); return type_LeftScob; }
                if (ProgText[uk] == ')') { stolb++; uk++; WriteLex(TEMPLex, type_RightScob); return type_RightScob; }
                if (ProgText[uk] == '[') { stolb++; uk++; WriteLex(TEMPLex, type_LeftSqScob); return type_LeftSqScob; }
                if (ProgText[uk] == ']') { stolb++; uk++; WriteLex(TEMPLex, type_RightSqScob); return type_RightSqScob; }
                if (ProgText[uk] == '{') { stolb++; uk++; WriteLex(TEMPLex, type_LeftFigScob); return type_LeftFigScob; }
                if (ProgText[uk] == '}') { stolb++; uk++; WriteLex(TEMPLex, type_RightFigScob); return type_RightFigScob; }
                if (ProgText[uk] == ',') { stolb++; uk++; WriteLex(TEMPLex, type_Commer); return type_Commer; }

                PrintError(UnknownLexema); return type_UnknownLexema;

















            }
        }
        private void Form1_Load(object sender, EventArgs e) { }
    }
    public class TreeNode
    {
        public TreeNode LeftN = null;
        public TreeNode RightN = null;
        public TreeNode Parent = null;
        public bool MAS = false;
        public bool FUNC = false;
        public bool PEREM = false;
        public bool CONST = false;
        public string NAME = "empty";
        public string ObjectType = "";
        public double VAL = 0;
        public int MASLength = 0;
        public float[] MASStartAdres;
    }
}
