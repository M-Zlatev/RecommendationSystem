namespace RS.WebAPI.Endpoints;

using MediatR;
using Microsoft.AspNetCore.Routing;

using Application.Apartaments.Create;
using Extensions;

public class Apartments : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("apartments", async (CreateApartmentCommand command, ISender sender) =>
        {
            await sender.Send(command);

            return Results.Ok();
        });
    }
}
