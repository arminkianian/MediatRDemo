using DemoLibrary.Models;
using DemoLibrary.Queries;
using MediatR;

namespace DemoLibrary.Handlers;

public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, PersonModel>
{
    private readonly IMediator _mediator;

    public GetPersonByIdQueryHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<PersonModel> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        var results = await _mediator.Send(new GetPersonListQuery());

        var output = results.FirstOrDefault(x => x.Id == request.Id);

        return output;
    }
}