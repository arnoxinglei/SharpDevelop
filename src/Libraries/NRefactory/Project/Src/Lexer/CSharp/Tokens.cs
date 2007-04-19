// this file was autogenerated by a tool.
using System;
using System.Collections;

namespace ICSharpCode.NRefactory.Parser.CSharp
{
	public static class Tokens
	{
		// ----- terminal classes -----
		public const int EOF                  = 0;
		public const int Identifier           = 1;
		public const int Literal              = 2;

		// ----- special character -----
		public const int Assign               = 3;
		public const int Plus                 = 4;
		public const int Minus                = 5;
		public const int Times                = 6;
		public const int Div                  = 7;
		public const int Mod                  = 8;
		public const int Colon                = 9;
		public const int DoubleColon          = 10;
		public const int Semicolon            = 11;
		public const int Question             = 12;
		public const int DoubleQuestion       = 13;
		public const int Comma                = 14;
		public const int Dot                  = 15;
		public const int OpenCurlyBrace       = 16;
		public const int CloseCurlyBrace      = 17;
		public const int OpenSquareBracket    = 18;
		public const int CloseSquareBracket   = 19;
		public const int OpenParenthesis      = 20;
		public const int CloseParenthesis     = 21;
		public const int GreaterThan          = 22;
		public const int LessThan             = 23;
		public const int Not                  = 24;
		public const int LogicalAnd           = 25;
		public const int LogicalOr            = 26;
		public const int BitwiseComplement    = 27;
		public const int BitwiseAnd           = 28;
		public const int BitwiseOr            = 29;
		public const int Xor                  = 30;
		public const int Increment            = 31;
		public const int Decrement            = 32;
		public const int Equal                = 33;
		public const int NotEqual             = 34;
		public const int GreaterEqual         = 35;
		public const int LessEqual            = 36;
		public const int ShiftLeft            = 37;
		public const int PlusAssign           = 38;
		public const int MinusAssign          = 39;
		public const int TimesAssign          = 40;
		public const int DivAssign            = 41;
		public const int ModAssign            = 42;
		public const int BitwiseAndAssign     = 43;
		public const int BitwiseOrAssign      = 44;
		public const int XorAssign            = 45;
		public const int ShiftLeftAssign      = 46;
		public const int Pointer              = 47;
		public const int LambdaArrow          = 48;

		// ----- keywords -----
		public const int Abstract             = 49;
		public const int As                   = 50;
		public const int Base                 = 51;
		public const int Bool                 = 52;
		public const int Break                = 53;
		public const int Byte                 = 54;
		public const int Case                 = 55;
		public const int Catch                = 56;
		public const int Char                 = 57;
		public const int Checked              = 58;
		public const int Class                = 59;
		public const int Const                = 60;
		public const int Continue             = 61;
		public const int Decimal              = 62;
		public const int Default              = 63;
		public const int Delegate             = 64;
		public const int Do                   = 65;
		public const int Double               = 66;
		public const int Else                 = 67;
		public const int Enum                 = 68;
		public const int Event                = 69;
		public const int Explicit             = 70;
		public const int Extern               = 71;
		public const int False                = 72;
		public const int Finally              = 73;
		public const int Fixed                = 74;
		public const int Float                = 75;
		public const int For                  = 76;
		public const int Foreach              = 77;
		public const int Goto                 = 78;
		public const int If                   = 79;
		public const int Implicit             = 80;
		public const int In                   = 81;
		public const int Int                  = 82;
		public const int Interface            = 83;
		public const int Internal             = 84;
		public const int Is                   = 85;
		public const int Lock                 = 86;
		public const int Long                 = 87;
		public const int Namespace            = 88;
		public const int New                  = 89;
		public const int Null                 = 90;
		public const int Object               = 91;
		public const int Operator             = 92;
		public const int Out                  = 93;
		public const int Override             = 94;
		public const int Params               = 95;
		public const int Private              = 96;
		public const int Protected            = 97;
		public const int Public               = 98;
		public const int Readonly             = 99;
		public const int Ref                  = 100;
		public const int Return               = 101;
		public const int Sbyte                = 102;
		public const int Sealed               = 103;
		public const int Short                = 104;
		public const int Sizeof               = 105;
		public const int Stackalloc           = 106;
		public const int Static               = 107;
		public const int String               = 108;
		public const int Struct               = 109;
		public const int Switch               = 110;
		public const int This                 = 111;
		public const int Throw                = 112;
		public const int True                 = 113;
		public const int Try                  = 114;
		public const int Typeof               = 115;
		public const int Uint                 = 116;
		public const int Ulong                = 117;
		public const int Unchecked            = 118;
		public const int Unsafe               = 119;
		public const int Ushort               = 120;
		public const int Using                = 121;
		public const int Virtual              = 122;
		public const int Void                 = 123;
		public const int Volatile             = 124;
		public const int While                = 125;
		public const int Partial              = 126;
		public const int Where                = 127;
		public const int Get                  = 128;
		public const int Set                  = 129;
		public const int Add                  = 130;
		public const int Remove               = 131;
		public const int Yield                = 132;
		public const int Select               = 133;
		public const int Group                = 134;
		public const int By                   = 135;
		public const int Into                 = 136;
		public const int From                 = 137;
		public const int Ascending            = 138;
		public const int Descending           = 139;
		public const int Orderby              = 140;

		public const int MaxToken = 141;
		static BitArray NewSet(params int[] values)
		{
			BitArray bitArray = new BitArray(MaxToken);
			foreach (int val in values) {
			bitArray[val] = true;
			}
			return bitArray;
		}
		public static BitArray IdentifierTokens = NewSet(Identifier, Partial, Where, Get, Set, Add, Remove, Yield, Select, Group, By, Into, From, Ascending, Descending, Orderby);
		public static BitArray OverloadableUnaryOp = NewSet(Minus, Not, BitwiseComplement, Increment, Decrement, True, False);
		public static BitArray OverloadableBinaryOp = NewSet(Plus, Minus, Times, Div, Mod, BitwiseAnd, BitwiseOr, Xor, ShiftLeft, Equal, NotEqual, GreaterThan, LessThan, GreaterEqual, LessEqual);
		public static BitArray TypeKW = NewSet(Char, Bool, Object, String, Sbyte, Byte, Short, Ushort, Int, Uint, Long, Ulong, Float, Double, Decimal);
		public static BitArray UnaryHead = NewSet(Plus, Minus, Not, BitwiseComplement, Times, Increment, Decrement, BitwiseAnd);
		public static BitArray AssnStartOp = NewSet(Plus, Minus, Not, BitwiseComplement, Times);
		public static BitArray CastFollower = NewSet(Identifier, Partial, Where, Get, Set, Add, Remove, Yield, Select, Group, By, Into, From, Ascending, Descending, Orderby, Literal, OpenParenthesis, New, This, Base, Null, Checked, Unchecked, Typeof, Sizeof, Delegate, Minus, Not, BitwiseComplement, Increment, Decrement, True, False, Plus, Minus, Not, BitwiseComplement, Times, Increment, Decrement, BitwiseAnd);
		public static BitArray AssgnOps = NewSet(Assign, PlusAssign, MinusAssign, TimesAssign, DivAssign, ModAssign, BitwiseAndAssign, BitwiseOrAssign, ShiftLeftAssign);
		public static BitArray UnaryOp = NewSet(Plus, Minus, Not, BitwiseComplement, Times, Increment, Decrement, BitwiseAnd);
		public static BitArray TypeDeclarationKW = NewSet(Class, Interface, Struct, Enum, Delegate);

		static string[] tokenList = new string[] {
			// ----- terminal classes -----
			"<EOF>",
			"<Identifier>",
			"<Literal>",
			// ----- special character -----
			"=",
			"+",
			"-",
			"*",
			"/",
			"%",
			":",
			"::",
			";",
			"?",
			"??",
			",",
			".",
			"{",
			"}",
			"[",
			"]",
			"(",
			")",
			">",
			"<",
			"!",
			"&&",
			"||",
			"~",
			"&",
			"|",
			"^",
			"++",
			"--",
			"==",
			"!=",
			">=",
			"<=",
			"<<",
			"+=",
			"-=",
			"*=",
			"/=",
			"%=",
			"&=",
			"|=",
			"^=",
			"<<=",
			"->",
			"=>",
			// ----- keywords -----
			"abstract",
			"as",
			"base",
			"bool",
			"break",
			"byte",
			"case",
			"catch",
			"char",
			"checked",
			"class",
			"const",
			"continue",
			"decimal",
			"default",
			"delegate",
			"do",
			"double",
			"else",
			"enum",
			"event",
			"explicit",
			"extern",
			"false",
			"finally",
			"fixed",
			"float",
			"for",
			"foreach",
			"goto",
			"if",
			"implicit",
			"in",
			"int",
			"interface",
			"internal",
			"is",
			"lock",
			"long",
			"namespace",
			"new",
			"null",
			"object",
			"operator",
			"out",
			"override",
			"params",
			"private",
			"protected",
			"public",
			"readonly",
			"ref",
			"return",
			"sbyte",
			"sealed",
			"short",
			"sizeof",
			"stackalloc",
			"static",
			"string",
			"struct",
			"switch",
			"this",
			"throw",
			"true",
			"try",
			"typeof",
			"uint",
			"ulong",
			"unchecked",
			"unsafe",
			"ushort",
			"using",
			"virtual",
			"void",
			"volatile",
			"while",
			"partial",
			"where",
			"get",
			"set",
			"add",
			"remove",
			"yield",
			"select",
			"group",
			"by",
			"into",
			"from",
			"ascending",
			"descending",
			"orderby",
		};
		public static string GetTokenString(int token)
		{
			if (token >= 0 && token < tokenList.Length) {
				return tokenList[token];
			}
			throw new System.NotSupportedException("Unknown token:" + token);
		}
	}
}
