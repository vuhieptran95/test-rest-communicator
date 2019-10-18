using System;

namespace TestSite.RestMessages
{
    public class ProductDetails
    {
        public string Pnc { get; set; }
        public string MachineSrNo { get; set; }
        public string AlienModel { get; set; }
        public string PurchaseDate { get; set; }
        public string FgItemCode { get; set; }
        public string Elc { get; set; }
        public DateTimeOffset ProdRegistrationDateTime { get; set; }
        public string ModelVariantNo { get; set; }
    }




}