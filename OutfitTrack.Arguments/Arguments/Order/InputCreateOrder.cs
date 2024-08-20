using System.ComponentModel.DataAnnotations;

namespace OutfitTrack.Arguments;

public class InputCreateOrder
{
    [Required] public long? ClientId { get; set; }
}