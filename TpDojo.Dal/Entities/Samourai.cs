namespace TpDojo.Dal.Entities;

public class Samourai
{
    public int Id { get; set; }
    public int Force { get; set; }
    public string Nom { get; set; }
    public Arme? Arme { get; set; }
}
