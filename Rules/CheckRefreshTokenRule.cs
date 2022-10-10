using SequentialDesign.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SequentialDesign.Models.Enums;

namespace SequentialDesign.Rules
{
    public class CheckRefreshToken : BaseRule, IBaseRule
    {
        public Platform Platform { get; set; }
        public CheckRefreshToken()
        {
            NextRule = null;
        }
        public bool Run(RequestModel model)
        {
            switch (Platform)
            {
                case Platform.Gsm:
                    {
                        if ((DummyData.TokenExpireDate.AddHours(2) - model.TokenExpireDate).TotalMinutes < 45)
                        {
                            if (DummyData.RefreshToken == model.RefreshToken)
                            {
                                DummyData.Token = "167948364512";
                                DummyData.RefreshToken = "73468317973648";
                                DummyData.TokenExpireDate = new DateTime(2022, 10, 10, 17, 50, 0);
                            }
                        }
                        break;
                    }
                case Platform.Web:
                    {
                        if ((DummyData.TokenExpireDate - model.TokenExpireDate).TotalMinutes < 45)
                        {
                            if (DummyData.RefreshToken == model.RefreshToken)
                            {
                                DummyData.Token = "12345678912";
                                DummyData.RefreshToken = "98765432219842";
                                DummyData.TokenExpireDate = new DateTime(2022, 10, 10, 17, 50, 0);
                            }
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return true;
        }
    }
}
