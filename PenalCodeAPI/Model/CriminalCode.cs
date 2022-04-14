﻿using PenalCodeAPI.DTO;

namespace PenalCodeAPI
{
    public class CriminalCode
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public decimal Penalty { get; set; }
        public int PrisonTime { get; set; }
        public Status Status { get; set; } = new Status();
        public DateTime CreateDate{ get; set; }
        public DateTime UpdateDate { get; set; }
        public User CreateUser { get; set; } = new User();
        public User UpdateUser { get; set; } = new User();

    }
}
