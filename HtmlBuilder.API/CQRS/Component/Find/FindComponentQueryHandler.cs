using AutoMapper;
using HtmlBuilder.API.CQRS.Page.GetAll;
using HtmlBuilder.API.CQRS.User.GetAll;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HtmlBuilder.API.CQRS.Component.Find;

public class FindComponentQueryHandler : IRequestHandler<FindComponentQueryRequest, FindComponentQueryResponse>
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public FindComponentQueryHandler(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<FindComponentQueryResponse> Handle(FindComponentQueryRequest request, CancellationToken cancellationToken)
    {
        var result = await _dbContext.Components.FindAsync(request.Id);

        var data = _mapper.Map<FindComponentDto>(result);

        return new FindComponentQueryResponse { Data = data };
    }
}