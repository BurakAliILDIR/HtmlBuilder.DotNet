namespace HtmlBuilder.API.Entities
{
    public class Component
    {
        public string Id { get; set; }
        public string LayoutId { get; set; }
        public string Label{ get; set; }
        public string Category{ get; set; }
        public string Content { get; set; }

        public Component() {
            Id = Label.ToLower().Replace(' ', '-');
        }
    }
}
