using System;
using System.Collections.Generic;
using System.Text;

namespace Q1.Exeptions
{
    public class ContentNotFoundException : Exception
    {
        public ContentNotFoundException()
        {
            
        }

        public ContentNotFoundException(string htmlElementTag)
            : base(String.Format("Content for element with tag {0} was not found.", htmlElementTag))
        {
        }

        public ContentNotFoundException(string htmlElementTag, Exception inner)
            : base(String.Format("Content for element with tag {0} was not found.", htmlElementTag), inner)
        {
        }
    }
}
