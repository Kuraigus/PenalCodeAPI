namespace PenalCodeAPI.Model
{
    public class CriminalCodeResponse
    {
        public List<CriminalCode> CriminalCodes { get; set; }
        public int Pages { get; set; }
        public int CurrentPage { get; set; }

    }
}
