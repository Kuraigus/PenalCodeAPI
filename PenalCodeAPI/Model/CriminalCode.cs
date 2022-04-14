namespace PenalCodeAPI
{
    public class CriminalCode
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public decimal Penalty { get; set; }
        public int PrisonTime { get; set; }
        public String StatusId { get; set; } = String.Empty;
        public DateTime CreateDate{ get; set; }
        public DateTime UpdateDate { get; set; }
        public String CreateUserId { get; set; } = String.Empty;
        public String UpdateUserId { get; set; } = String.Empty;


    }
}
