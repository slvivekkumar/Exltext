using DbModel.Model;
using EXLtestApp.IRepository;
using System;
using System.Collections.Generic;


namespace EXLtestApp.Repository
{
    public interface IUserRepository: IGenericRepository<User>
    {
        IEnumerable<User> GetSearchUsers(string? criteria, DateTime? empstartdate, DateTime? empenddate);
    }
}
