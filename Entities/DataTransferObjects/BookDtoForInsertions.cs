using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public record BookDtoForInsertions:BookDtoForManipulation
    {
        [Required(ErrorMessage="CategoryId is required.")]
        public int CategoryId { get; init; }
    }

}
 