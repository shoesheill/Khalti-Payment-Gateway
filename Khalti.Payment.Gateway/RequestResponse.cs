using System;
using System.Collections.Generic;
using System.Text;

namespace Khalti.Payment.Gateway
{
    public class KhaltiResponse
    {
        public string pidx { get; set; }
        public string payment_url { get; set; }
        public int status_code { get; set; }
        public string detail { get; set; }
    }
}
