namespace TpDojo.Dal.Entities;

using System.ComponentModel.DataAnnotations;

public class Samourai : ADataObject
{
    [Required]
    public string Nom { get; set; }

    [Required]
    public int Force { get; set; }

    public int? ArmeId { get; set; }

    public Arme? Arme { get; set; }

    public List<ArtMartial> ArtMartiaux { get; set; } = new();
}
