﻿// Copyright (c) https://github.com/ddur
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ICSharpCode.CodeCoverage
{
    /// <summary>StringTextSource (ReadOnly)
	/// <remarks>Line and column counting starts at 1.</remarks>
    /// <remarks>IDocument/ITextBuffer/ITextSource fails returning single char "{"?</remarks>
    /// </summary>
    public class CodeCoverageStringTextSource
    {
        private readonly string textSource;
        private struct lineInfo {
            public int Offset;
            public int Length;
        }
        private readonly lineInfo[] lines;
        public CodeCoverageStringTextSource(string source)
        {
            
            this.textSource = source.Clone() as string; // disconnect from source

            List<lineInfo> lineInfoList = new List<lineInfo>();
            int offset = 0;
            int counter = 0;
            bool nl = false;
            bool cr = false;
            bool lf = false;
            lineInfo sl;

            foreach ( short ch in textSource ) {
                switch (ch) {
                    case 13:
                        if (cr||lf) {
                            nl = true;
                        } else {
                            cr = true;
                        }
                        break;
                    case 10:
                        if (lf) {
                            nl = true;
                        } else {
                            lf = true;
                        }
                        break;
                    default:
                        if (cr||lf) {
                            nl = true;
                        }
                        break;
                }
                if (nl) {
                    sl = new lineInfo();
                    sl.Offset = offset;
                    sl.Length = counter - offset;
                    lineInfoList.Add(sl);
                    offset = counter;
                    cr = false;
                    lf = false;
                    nl = false;
                }
                ++counter;
            }
            sl = new lineInfo();
            sl.Offset = offset;
            sl.Length = counter - offset;
            lineInfoList.Add(sl);
            lines = lineInfoList.ToArray();
        }

        /// <summary>Return text/source using SequencePoint line/col info
        /// </summary>
        /// <param name="sp"></param>
        /// <returns></returns>
        public string GetText(CodeCoverageSequencePoint sp) {
            return this.GetText(sp.Line, sp.Column, sp.EndLine, sp.EndColumn );
        }

        /// <summary>Return text at Line/Column/EndLine/EndColumn position
        /// <remarks>Line and Column counting starts at 1.</remarks>
        /// </summary>
        /// <param name="Line"></param>
        /// <param name="Column"></param>
        /// <param name="EndLine"></param>
        /// <param name="EndColumn"></param>
        /// <returns></returns>
        public string GetText(int Line, int Column, int EndLine, int EndColumn) {

            StringBuilder text = new StringBuilder();
            string line;
            bool argOutOfRange;

            if (Line==EndLine) {

                #region One line request
                line = GetLine(Line);

                Debug.Assert(!(Column < 1), "Column < 1");
                Debug.Assert(!(Column > EndColumn), "Column > EndColumn");
                Debug.Assert(!(EndColumn > line.Length), "EndColumn > line.Length");

                argOutOfRange = Column < 1
                    ||   Column > EndColumn
                    ||   EndColumn > line.Length;
                if (!argOutOfRange) {
                    text.Append(line.Substring(Column-1,EndColumn-Column));
                }
                #endregion

            } else if (Line<EndLine) {

                #region Multi-line request

                #region First line
                line = GetLine(Line);

                Debug.Assert(!(Column < 1), "Column < 1");
                Debug.Assert(!(Column > line.Length), "Column > line.Length");

                argOutOfRange = Column < 1
                    ||   Column > line.Length;

                if (!argOutOfRange) {
                    text.Append(line.Substring(Column-1));
                }
                #endregion

                #region More than two lines
                for ( int lineIndex = Line+1; lineIndex < EndLine; lineIndex++ ) {
                    text.Append ( GetLine ( lineIndex ) );
                }
                #endregion

                #region Last line
                line = GetLine(EndLine);

                Debug.Assert(!(EndColumn < 1), "EndColumn < 1");
                Debug.Assert(!(EndColumn > line.Length), "EndColumn > line.Length");

                argOutOfRange = EndColumn < 1
                    ||   EndColumn > line.Length;
                if (!argOutOfRange) {
                    text.Append(line.Substring(0,EndColumn));
                }
                #endregion

                #endregion

            } else {
                Debug.Fail("Line > EndLine");
            }
            return text.ToString();
        }

        /// <summary>Return SequencePoint enumerated line
        /// </summary>
        /// <param name="lineNr"></param>
        /// <returns></returns>
        public string GetLine ( int LineNo ) {

            string retString = String.Empty;

            if ( LineNo > 0 && LineNo <= lines.Length ) {
                lineInfo lineInfo = lines[LineNo-1];
                retString = textSource.Substring(lineInfo.Offset, lineInfo.Length);
            } else {
                Debug.Fail( "Line number out of range" );
            }

            return retString;
        }
        
        public static string IndentTabs ( string ToIndent, int TabSize ) {
            
            string retString = ToIndent;
            if ( ToIndent.Contains ( "\t" ) ) {
                int counter = 0;
                int remains = 0;
                int repeat = 0;
                char prevChar = char.MinValue;
                StringBuilder indented = new StringBuilder();
                foreach ( char currChar in ToIndent ) {
                    if ( currChar == '\t' ) {
                        remains = counter % TabSize;
                        repeat = remains == 0 ? TabSize : remains;
                        indented.Append( ' ', repeat );
                    } else {
                        indented.Append ( currChar, 1 );
                        if ( char.IsLowSurrogate(currChar) 
                            && char.IsHighSurrogate(prevChar)
                           ) { --counter; }
                    }
                    prevChar = currChar;
                    ++counter;
                }
                retString = indented.ToString();
            }
            return retString;
        }

    }
}
