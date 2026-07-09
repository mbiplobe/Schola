// using Schola.Application.DTOs;
// using Schola.Infrastructure.EF.Models;

using Schola.Infrastructure.EF.Models;

namespace Schola.Infrastructure.EF.Queries;

internal static class Extensions
{
    public static UserEntityDto AsDto(this UserReadModel readModel)
        => new UserEntityDto(
            Id: readModel.ID,
            FullName: readModel.FirstName + " " + readModel.MiddleName + " " + readModel.LastName,
            Email: readModel.Email,
            Mobile: readModel.Mobile
        );

    public static ClassEntityDto AsDto(this ClassReadModel readModel)
        => new ClassEntityDto(
            Id: readModel.Id,
            Name: readModel.Name,
            Description: readModel.Description
        );


    public static SectionEntityDto AsDto(this SectionReadModel readModel)
        => new SectionEntityDto(
            Id: readModel.Id,
            Name: readModel.Name,
            Description: readModel.Description
        );
}

