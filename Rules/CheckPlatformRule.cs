using SequentialDesign.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SequentialDesign.Models.Enums;

namespace SequentialDesign.Rules
{
    public class CheckPlatformRule : BaseRule, IBaseRule
    {
        public CheckPlatformRule()
        {
            NextRule = new CheckTokenRule();
        }

        public Platform Platform { get; set; }
 
        public bool Run(RequestModel model)
        {
            if(string.IsNullOrEmpty(model.IMEI))
            {
                NextRule.Platform = Platform.Web;
                return !string.IsNullOrEmpty(model.Token);
            }
            else if(!string.IsNullOrEmpty(model.IMEI))
            {
                NextRule.Platform = Platform.Gsm;
                return !string.IsNullOrEmpty(model.Token) || !string.IsNullOrEmpty(model.RefreshToken);
            }

            return false;
        }
    }
}
