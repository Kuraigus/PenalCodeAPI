namespace PenalCodeAPI.Model
{
    public class PageableResponse <T>
    {
        public List<T> Result { get; set; }
        public int Pages { get; set; }
        public int CurrentPage { get; set; }

    }
}
