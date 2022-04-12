﻿namespace PenalCodeAPI
{
    public class CriminalCode
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public decimal Penalty { get; set; }
        public int Prisontime { get; set; }
        public string StatusId { get; set; } = String.Empty;
        public DateTime CreateDate{ get; set; }
        public DateTime UpdateDate { get; set; }
        public string CreateUserId { get; set; } = String.Empty;
        public string UpdateUserId { get; set; } = String.Empty;


    }
}