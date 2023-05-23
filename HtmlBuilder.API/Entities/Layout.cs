namespace HtmlBuilder.API.Entities
{
    public class Layout
    {
        public string Id { get; set; }
        public List<string> Styles { get; set; }
        public List<string> Scripts { get; set; }

        public Layout()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
