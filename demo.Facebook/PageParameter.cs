using System;
using System.Collections.Generic;
using System.Text;

namespace demo.Facebook
{

    public class FacebookPage 
    {
        public PageParameter cursors { get; set; }
    }
    public class PageParameter
    {
        public int pretty { get; set; } = 0;
        public int limit { get; set; } = 10;
        public string before { get; set; } = null;
        public string after { get; set; } = null;
    }
}
