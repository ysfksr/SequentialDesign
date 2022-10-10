using SequentialDesign.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SequentialDesign.Models.Enums;

namespace SequentialDesign.Rules
{
    public class CheckTokenRule : BaseRule, IBaseRule
    {
        public CheckTokenRule()
        {
            NextRule = new CheckTokenExpireRule();
        }

        public Platform Platform { get; set; }

        public bool Run(RequestModel model)
        {
            switch (Platform)
            {
                case Platform.Gsm:
                    {
                        NextRule.Platform = Platform.Gsm;
                        return model.UserID == DummyData.UserID &&
                            (model.Token == DummyData.Token || model.RefreshToken == DummyData.RefreshToken);
                    }
                case Platform.Web:
                    {
                        NextRule.Platform = Platform.Web;
                        return model.UserID == DummyData.UserID && model.Token == DummyData.Token;
                    }
                default:
                    {
                        return false;
                    }
            }
        }
    }
}
