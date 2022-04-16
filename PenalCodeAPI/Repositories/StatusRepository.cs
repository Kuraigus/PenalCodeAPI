﻿using PenalCodeAPI.Interfaces;

namespace PenalCodeAPI.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly DataContext _context;

        public StatusRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Status> GetAllStatus()
        {
            return _context.Status.ToList();
        }

        public Status GetStatus(int id)
        {
            return _context.Status.Find(id);
        }

        public string CreateStatus(Status status)
        {
            _context.Status.Add(status);
            _context.SaveChanges();

            return "Sucesso em criar status!";
        }

        public string DeleteStatus(Status status)
        {
            _context.Status.Remove(status);
            _context.SaveChanges();

            return "Sucesso em deletar status!";
        }


    }
}
