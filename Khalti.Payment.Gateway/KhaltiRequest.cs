using System;
using System.Collections.Generic;
using System.Text;

namespace Khalti.Payment.Gateway
{
    public class KhaltiRequest
    {
        public string return_url { get; set; }
        public string website_url { get; set; }
        public int amount { get; set; }
        public string purchase_order_id { get; set; }
        public string purchase_order_name { get; set; }
        public Customer_Info customer_info { get; set; }
        public List<Amount_Breakdown> amount_breakdown { get; set; }
        public List<Product_Detail> product_details { get; set; }
    }
    public class Amount_Breakdown
    {
        public string label { get; set; }
        public int amount { get; set; }
    }

    public class Customer_Info
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }

    public class Product_Detail
    {
        public string identity { get; set; }
        public string name { get; set; }
        public int total_price { get; set; }
        public int quantity { get; set; }
        public int unit_price { get; set; }
    }

}
