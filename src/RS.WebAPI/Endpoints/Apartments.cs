namespace RS.WebAPI.Endpoints;

using MediatR;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;

using Application.Apartments.Get;
using Application.Apartaments.Create;
using Application.Apartments.Update;
using Application.Apartments.Delete;
using Domain;
using Domain.ValueObjects;
using Extensions;

public class Apartments : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("aprtments/{id:guid}", async (Guid id, ISender sender) =>
        {
            try
            {
                return Results.Ok(await sender.Send(new GetApartmentQuery(new ApartmentId(id))));
            }
            catch (ApartmentNotFoundException ex)
            {
                return Results.NotFound(ex.Message);
            }
        });

        app.MapPost("apartments", async (CreateApartmentCommand command, ISender sender) =>
        {
            await sender.Send(command);

            return Results.Ok();
        });

        app.MapPut("aprtments/{id:guid}", async (Guid id, [FromBody] UpdateApartmentRequest request, ISender sender) =>
        {
            UpdateApartmentCommand? command = new UpdateApartmentCommand(
                      new ApartmentId(id),
                      request.ApartmentStatus,
                      request.PropertyType,
                      request.PriceCurrency, request.PriceAmount,
                      request.PricePerSqMCurrency, request.PricePerSqMAmount,
                      request.Quadrature,
                      request.Floor,
                      request.ConstructionType,
                      request.YearOfConstruction,
                      request.Location,
                      request.BrokerCommission,
                      request.PermissionForUse,
                      request.Notes);

            await sender.Send(command);

            return Results.NoContent();
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
