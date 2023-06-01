namespace HtmlBuilder.API.Entities
{
    public class Page
    {
        public string Id { get; set; } // route
        public string Name { get; set; }
        public string Html { get; set; }
        public string Css { get; set; }

        public Page()
        {
            Id = "";
            Html = "";
            Css = "";
        }
    }
}
