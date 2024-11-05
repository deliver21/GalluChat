﻿using GalluChat.Data;
using GalluChat.Models;
using GalluChat.Repository.IRepository;

namespace GalluChat.Repository
{
    public class ApplicationUserRepository:Repository<ApplicationUser>,IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;
        public ApplicationUserRepository(ApplicationDbContext db):base(db)
        { 
            _db= db;    
        }
        //public void Update(ApplicationUser obj)
        //{
        //    _db.ApplicationUsers.Update(obj);
        //}
    }
}
