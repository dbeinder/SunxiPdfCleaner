using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace SunxiPdfCleaner
{
    public class TextReplaceStreamEditor : PdfContentStreamEditor
    {
        public TextReplaceStreamEditor(string MatchPattern, string ReplacePattern)
        {
            _replacePattern = ReplacePattern;
            _matcher = new Regex(MatchPattern, RegexOptions.Compiled);
        }

        private Regex _matcher;
        private string _replacePattern;

        protected override void Write(PdfContentStreamProcessor processor, PdfLiteral oper, List<PdfObject> operands)
        {
            var operatorString = oper.ToString();
            if ("Tj".Equals(operatorString) || "TJ".Equals(operatorString))
            {
                for(var i = 0; i < operands.Count; i++)
                {
                    if(!operands[i].IsString())
                        continue;

                    //remove zero bytes (used in allwinner watermarks)
                    var text = operands[i].ToString().Replace("\0", "");
                    if(_matcher.IsMatch(text))
                    {
                        operands[i] = new PdfString(_matcher.Replace(text, _replacePattern));
                    }
                }
            }

            base.Write(processor, oper, operands);
        }
    }
}
