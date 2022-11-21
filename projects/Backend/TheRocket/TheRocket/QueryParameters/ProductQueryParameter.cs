namespace TheRocket.QueryParameters
{
    public class ProductQueryParameter:QueryParameter
    {
         public double?  MinPrice { get; set; }
        public double?  MaxPrice { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Desctiption{get;set;}=string.Empty;
        public string SearchTerm { get; set; } = string.Empty;
    }
}