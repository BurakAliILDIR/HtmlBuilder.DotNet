using MediatR;

namespace HtmlBuilder.API.CQRS.Page.Update
{
    public class UpdatePageCommandRequest: IRequest<UpdatePageCommandResponse>
    {
        public string Id { get; set; }
        public string Html { get; set; }
        public string Css { get; set; }
    }
}
