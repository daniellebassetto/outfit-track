using System.ComponentModel.DataAnnotations;

namespace OutfitTrack.Arguments;

public class InputCreateOrderItem
{
    [Required] public long? ProductId { get; set; }
    [MaxLength(30, ErrorMessage = "Quantidade de caracteres inválida")] public string? Color { get; set; }
    [Required][MaxLength(10, ErrorMessage = "Quantidade de caracteres inválida")] public string? Size { get; set; }
}