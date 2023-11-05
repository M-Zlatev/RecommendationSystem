namespace RS.WebAPI.Endpoints;

using MediatR;
using Microsoft.AspNetCore.Routing;

using Application.Apartaments.Create;
using Application.Apartments.Delete;
using Extensions;
using Domain.ValueObjects;
using RS.Domain;

public class Apartments : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("apartments", async (CreateApartmentCommand command, ISender sender) =>
        {
            await sender.Send(command);

            return Results.Ok();
        });

        app.MapDelete("aprtments/{id:guid}", async (Guid id, ISender sender) =>
        {
            try
            {
                await sender.Send(new DeleteApartmentCommand(new ApartmentId(id)));

                return Results.NoContent();
            }
            catch (ApartmentNotFoundException ex)
            {
                return Results.NotFound(ex.Message);
            }
        });
    }
}
