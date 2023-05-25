using AutoMapper;
using HtmlBuilder.API.CQRS.Page.GetAll;
using HtmlBuilder.API.CQRS.User.GetAll;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HtmlBuilder.API.CQRS.Page.Update
{
    public class UpdatePageCommandHandler : IRequestHandler<UpdatePageCommandRequest, UpdatePageCommandResponse>
    {
        private readonly AppDbContext _dbContext;

        public UpdatePageCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UpdatePageCommandResponse> Handle(UpdatePageCommandRequest request, CancellationToken cancellationToken)
        {
            var page = await _dbContext.Pages.FindAsync(request.Id);

            page.Html = request.Html;
            page.Css = request.Css;

            _dbContext.Pages.Update(page);

            await _dbContext.SaveChangesAsync();

            return new UpdatePageCommandResponse { };
        }
    }
}
