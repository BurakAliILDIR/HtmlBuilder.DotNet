namespace HtmlBuilder.API.Entities
{
    public class Page
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Route { get; set; }
        public string Html { get; set; }
        public string Css { get; set; }

        public Page()
        {
            Id = Guid.NewGuid().ToString();
            Route = "";
            Html = "";
            Css = "";
        }
    }
}
