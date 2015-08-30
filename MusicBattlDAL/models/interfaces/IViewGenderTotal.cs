namespace MusicBattlDAL.models.interfaces
{
    public interface IViewGenderTotal
    {
        int Total { get; set; }

        int TotalFemale { get; set; }

        int TotalMale { get; set; }
    }
}