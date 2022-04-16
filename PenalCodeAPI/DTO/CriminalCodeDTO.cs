namespace PenalCodeAPI.DTO
{
    public class CriminalCodeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public decimal Penalty { get; set; }
        public int PrisonTime { get; set; }
        public int StatusId { get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime UpdateDate { get; set; }
        public int CreateUserId { get; set; }
        public int UpdateUserId { get; set; }
    }
}
