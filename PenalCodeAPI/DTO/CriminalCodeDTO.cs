namespace PenalCodeAPI.DTO
{
    public class CriminalCodeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public decimal Penalty { get; set; }
        public int PrisonTime { get; set; }
        public StatusDTO Status { get; set; } = new StatusDTO();
        public DateTime CreateDate{ get; set; }
        public DateTime UpdateDate { get; set; }
        public UserDTO CreateUser { get; set; } = new UserDTO();
        public UserDTO UpdateUser { get; set; } = new UserDTO(); 

    }
}
