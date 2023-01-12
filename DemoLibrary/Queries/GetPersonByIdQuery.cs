using DemoLibrary.Models;
using MediatR;

namespace DemoLibrary.Queries;

public record GetPersonByIdQuery(int Id) : IRequest<PersonModel>;