using Petfolio.Communication.Response;

namespace Petfolio.Application.UseCases.Pets.GetById;

public class GetPetByIdUseCase
{
    public ResponsePetJson Execute(int id)
    {
        return new ResponsePetJson
        {
            Id = id, 
            Name = "Pipoca", 
            Type = Communication.Enums.PetType.Cat,
            Birthday = new DateTime( year: 2011, month: 3, day: 14),
        };
    }
}