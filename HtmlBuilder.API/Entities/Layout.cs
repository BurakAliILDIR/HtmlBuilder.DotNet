namespace HtmlBuilder.API.Entities
{
    public class Layout
    {
        public string Id { get; set; }
        public string Styles { get; set; }
        public string Scripts { get; set; }

        public Layout()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
