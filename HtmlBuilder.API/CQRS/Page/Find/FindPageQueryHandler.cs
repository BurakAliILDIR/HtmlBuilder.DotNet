using AutoMapper;
using HtmlBuilder.API.CQRS.Page.GetAll;
using HtmlBuilder.API.CQRS.User.GetAll;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HtmlBuilder.API.CQRS.Page.Find;

public class FindPageQueryHandler : IRequestHandler<FindPageQueryRequest, FindPageQueryResponse>
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public FindPageQueryHandler(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<FindPageQueryResponse> Handle(FindPageQueryRequest request, CancellationToken cancellationToken)
    {
        var result = await _dbContext.Pages.FindAsync(request.Id);

        var data = _mapper.Map<FindPageDto>(result);

        return new FindPageQueryResponse { Data = data };
    }
}