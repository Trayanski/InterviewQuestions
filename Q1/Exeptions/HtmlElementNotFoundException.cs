using System;
using System.Collections.Generic;
using System.Text;

namespace Q1.Exeptions
{
    public class HtmlElementNotFoundException : Exception
    {
        public HtmlElementNotFoundException()
        {
            
        }

        public HtmlElementNotFoundException(string htmlElementTag)
            : base(String.Format("Element with tag {0} was not found.", htmlElementTag))
        {
        }

        public HtmlElementNotFoundException(string htmlElementTag, Exception inner)
            : base(String.Format("Element with tag {0} was not found.", htmlElementTag), inner)
        {
        }
    }
}
