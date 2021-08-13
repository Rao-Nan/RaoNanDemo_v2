using System;
using System.Collections.Generic;
using System.Text;

namespace demo.Facebook
{
    public class FacebookListResult<T>
    {
        public IEnumerable<T> data { get; set; }

        public FacebookPage paging { get; set; }
    }

  

}
