// using Schola.Application.DTOs;
// using Schola.Infrastructure.EF.Models;

using Schola.Infrastructure.EF.Models;

namespace Schola.Infrastructure.EF.Queries;

internal static class Extensions
{
    public static UserEntityDto AsDto(this UserReadModel readModel)
        => new UserEntityDto(
            Id: readModel.ID,
            FullName: readModel.FullName,
            Email: readModel.Email,
            Mobile: readModel.Mobile
        );
            //     City: readModel.Destination?.City,
            //     Country: readModel.Destination?.Country
            // ),
            // Items: readModel.Items?.Select(pi => new SampleEntityItemDto
            // (
            //     Name: pi.Name,
            //     Quantity: pi.Quantity,
            //     IsTaken: pi.IsTaken
            // )

            
}
