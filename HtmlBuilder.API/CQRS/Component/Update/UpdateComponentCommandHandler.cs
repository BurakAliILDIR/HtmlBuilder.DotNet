using AutoMapper;
using HtmlBuilder.API.CQRS.Page.GetAll;
using HtmlBuilder.API.CQRS.User.GetAll;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HtmlBuilder.API.CQRS.Component.Update
{
    public class UpdateComponentCommandHandler : IRequestHandler<UpdateComponentCommandRequest, UpdateComponentCommandResponse>
    {
        private readonly AppDbContext _dbContext;

        public UpdateComponentCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UpdateComponentCommandResponse> Handle(UpdateComponentCommandRequest request, CancellationToken cancellationToken)
        {
            var page = await _dbContext.Pages.FindAsync(request.Id);

            page.Html = request.Html;
            page.Css = request.Css;

            _dbContext.Pages.Update(page);

            await _dbContext.SaveChangesAsync();

            return new UpdateComponentCommandResponse { };
        }
    }
}
