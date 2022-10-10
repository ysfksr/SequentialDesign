using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequentialDesign
{
    public class BaseRule
    {
        public IBaseRule NextRule { get; set; }
    }
}
