using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace SunxiPdfCleaner
{
    public class TextReplaceStreamEditor : PdfContentStreamEditor
    {
        public TextReplaceStreamEditor(string MatchPattern, string ReplacePattern, bool doRegex)
        {
            _replacePattern = ReplacePattern;
            if (doRegex)
                _matcher = new Regex(MatchPattern, RegexOptions.Compiled);
            else
                _containsMatch = MatchPattern;
        }

        private Regex _matcher;
        private string _replacePattern;
        private string _containsMatch = null;

        protected override void Write(PdfContentStreamProcessor processor, PdfLiteral oper, List<PdfObject> operands)
        {
            var operatorString = oper.ToString();
            if ("Tj".Equals(operatorString) || "TJ".Equals(operatorString))
            {
                for (var i = 0; i < operands.Count; i++)
                {
                    if (!operands[i].IsString())
                        continue;

                    //remove zero bytes (used in allwinner watermarks)
                    var text = Encoding.UTF8.GetString(operands[i].GetBytes().Where(b => b != 0).ToArray());
                    if (_containsMatch != null && !string.IsNullOrWhiteSpace(text) && text.Contains(_containsMatch))
                    {
                        operands[i] = new PdfString(_replacePattern);
                    }
                    else if (_matcher?.IsMatch(text) ?? false)
                    {
                        operands[i] = new PdfString(_matcher.Replace(text, _replacePattern));
                    }
                }
            }

            base.Write(processor, oper, operands);
        }
    }
}
