using SequentialDesign.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SequentialDesign.Models.Enums;

namespace SequentialDesign
{
    public interface IBaseRule
    {
        public bool Run(RequestModel model);
        public Platform Platform { get; set; }
        public IBaseRule NextRule { get; set; }

    }
}
