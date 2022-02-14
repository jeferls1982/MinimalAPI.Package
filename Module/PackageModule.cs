using Dapper;
using System.Data.SqlClient;

namespace MinimalAPI.Package.Module
{
    public class PackageModule : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/package", async (SqlConnection db) =>
                await db.QueryAsync("select * from package"));

            app.MapGet("/package/{code}", async (SqlConnection db, string code) =>
               await db.QueryAsync("select * from package where Code = @code", new { code }));

            app.MapPost("/packages", async(SqlConnection db, RegisterPackageDto dto) =>
            {
                var newPackage = await db.QueryFirstOrDefaultAsync<RegisterPackageDto>
                (
                    @"insert into package(Code,Country,Description)
                      output inserted.*
                      values(@code, @country, @description)", dto
                );

                return Results.Created($"/package/{newPackage.PackageId}", newPackage);
            });

        }
    }
}
 