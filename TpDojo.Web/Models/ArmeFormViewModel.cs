namespace TpDojo.Web.Models;

using TpDojo.Business.Dto;

public class ArmeFormViewModel
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public int Degats { get; set; }


    internal static ArmeDto ToArmeViewModel(ArmeFormViewModel armeFormViewModel)
        => new() { Id = armeFormViewModel.Id, Nom = armeFormViewModel.Nom, Degats = armeFormViewModel.Degats };

}