using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace SunxiPdfCleaner
{
    public class PdfContentStreamEditor : PdfContentStreamProcessor
    {
        public bool RemoveXObjects = false;
        public Regex Watermark;
        public int XObjectLevel = 0;
        public bool IsWatermark = false;
        public int WatermarkCount = 0;

        /**
         * The stream processor is used to parse the bytestream, operations are written after parsing
         * It will descend into XObject instances but only to check for a watermark, 
         * if present, the entire XObject instance "Do" operation is skipped
         */

        public void EditPage(PdfStamper pdfStamper, int pageNum)
        {
            var pdfReader = pdfStamper.Reader;
            var page = pdfReader.GetPageN(pageNum);
            var c2 = pdfReader.GetPageContent(pageNum);
            //var pageContentInput = ContentByteUtils.GetContentBytesForPage(pdfReader, pageNum);
            page.Remove(PdfName.CONTENTS);
            EditContent(c2, page.GetAsDict(PdfName.RESOURCES), pdfStamper.GetUnderContent(pageNum));
        }

        public virtual void EditContent(byte[] contentBytes, PdfDictionary resources, PdfContentByte canvas)
        {
            this.Canvas = canvas;
            ProcessContent(contentBytes, resources);
            this.Canvas = null;
        }

        /**
         * This method writes content stream operations to the target canvas. The default
         * implementation writes them as they come, so it essentially generates identical
         * copies of the original instructions the {@link ContentOperatorWrapper} instances
         * forward to it.
         *
         * Override this method to achieve some fancy editing effect.
         */

        protected virtual void Write(PdfContentStreamProcessor processor, PdfLiteral operatorLit, List<PdfObject> operands)
        {
            var index = 0;

            foreach (var pdfObject in operands)
            {
                pdfObject.ToPdf(null, Canvas.InternalBuffer);
                Canvas.InternalBuffer.Append(operands.Count > ++index ? (byte)' ' : (byte)'\n');
            }
        }


        //
        // constructor giving the parent a dummy listener to talk to 
        //
        public PdfContentStreamEditor() : base(new DummyRenderListener())
        {
        }

        //
        // constructor giving the parent a dummy listener to talk to 
        //
        public PdfContentStreamEditor(IRenderListener renderListener) : base(renderListener)
        {
        }

        //
        // Overrides of PdfContentStreamProcessor methods
        //

        public override IContentOperator RegisterContentOperator(string operatorString, IContentOperator newOperator)
        {
            var wrapper = new ContentOperatorWrapper() { OriginalOperator = newOperator };
            var formerOperator = base.RegisterContentOperator(operatorString, wrapper);
            return (formerOperator is ContentOperatorWrapper operatorWrapper ? operatorWrapper.OriginalOperator : formerOperator);
        }

        public override IXObjectDoHandler RegisterXObjectDoHandler(PdfName xobjectSubType, IXObjectDoHandler handler)
        {
            var wrapper = new XObjectDoHandlerWrapper { OriginalHandler = handler };
            var former = base.RegisterXObjectDoHandler(xobjectSubType, wrapper);
            return (former is XObjectDoHandlerWrapper formerWrapper ? formerWrapper.OriginalHandler : former);
        }

        public override void ProcessContent(byte[] contentBytes, PdfDictionary resources)
        {
            this.Resources = resources;
            base.ProcessContent(contentBytes, resources);
            this.Resources = null;
        }

        //
        // members holding the output canvas and the resources
        //
        protected PdfContentByte Canvas = null;
        protected PdfDictionary Resources = null;

        //
        // A content operator class to wrap all content operators to forward the invocation to the editor
        //
        class ContentOperatorWrapper : IContentOperator
        {
            public IContentOperator OriginalOperator;

            public void Invoke(PdfContentStreamProcessor processor, PdfLiteral oper, List<PdfObject> operands)
            {
                var proc = (PdfContentStreamEditor)processor;
                var isXObject = "Do" == oper.ToString();
                if (isXObject)
                {
                    if (proc.XObjectLevel == 0) proc.IsWatermark = false;
                    proc.XObjectLevel++;
                }
                if (!isXObject && operands.Count == 2 && proc.XObjectLevel > 0 && proc.RemoveXObjects)
                {
                    var op = operands[1].ToString();
                    if ((op == "Tj" || op == "TJ") && proc.Watermark.IsMatch(operands[0].ToString()))
                    {
                        proc.IsWatermark = true;
                        proc.WatermarkCount++;
                    }
                }

                OriginalOperator?.Invoke(processor, oper, operands);

                if (isXObject) proc.XObjectLevel--;
                if (isXObject && proc.IsWatermark && proc.RemoveXObjects) return;
                if (proc.XObjectLevel == 0)
                    ((PdfContentStreamEditor)processor).Write(processor, oper, operands);
            }
        }

        class XObjectDoHandlerWrapper : IXObjectDoHandler
        {
            public IXObjectDoHandler OriginalHandler;

            public void HandleXObject(PdfContentStreamProcessor processor, PdfStream stream, PdfIndirectReference refi)
            {
                OriginalHandler.HandleXObject(processor, stream, refi);
            }

            public void HandleXObject(PdfContentStreamProcessor processor, PdfStream stream, PdfIndirectReference refi, ICollection markedContentInfoStack)
            {
                OriginalHandler.HandleXObject(processor, stream, refi, markedContentInfoStack);
            }
        }

        //
        // A dummy render listener to give to the underlying content stream processor to feed events to
        //
        class DummyRenderListener : IRenderListener
        {
            public void BeginTextBlock() { }

            public void RenderText(TextRenderInfo renderInfo) { }

            public void EndTextBlock() { }

            public void RenderImage(ImageRenderInfo renderInfo) { }
        }
    }
}
