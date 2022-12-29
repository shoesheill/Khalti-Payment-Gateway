using System;
using System.Collections.Generic;
using System.Text;

namespace Khalti.Payment.Gateway
{
    internal class KhaltiPaymentUrl
    {
        public const string Url = "https://khalti.com/api/";
        public const string SandBoxUrl = "https://a.khalti.com/api/";
        public const string Initialization = "/epayment/initiate/";
        public const string Verification = "/epayment/lookup/";
    }
    public class PaymentApi
    {
        public static string Version = "v2";
    }
    enum KhaltiPaymentUrlType
    {
        Initialization = 0,
        Verification
    }
}
