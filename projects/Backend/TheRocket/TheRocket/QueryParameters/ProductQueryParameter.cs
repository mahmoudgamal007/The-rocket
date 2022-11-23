namespace TheRocket.QueryParameters
{
    public class ProductQueryParameter:QueryParameter
    {
         public double?  MinPrice { get; set; }
        public double?  MaxPrice { get; set; }

        public string Name { get; set; } = string.Empty;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        public string Desctiption{get;set;}=string.Empty;
        public string SearchTerm { get; set; } = string.Empty;
=======
        public string SearchTerm { get; set; } = string.Empty;

        public int? SellerId{get;set;}
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
=======
        public string SearchTerm { get; set; } = string.Empty;

        public int? SellerId{get;set;}
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
=======
        public string SearchTerm { get; set; } = string.Empty;

        public int? SellerId{get;set;}
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
=======
        public string SearchTerm { get; set; } = string.Empty;

        public int? SellerId{get;set;}
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
    }
}