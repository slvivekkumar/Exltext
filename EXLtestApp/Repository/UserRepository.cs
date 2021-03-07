using DbModel.Model;
using System;
using System.Collections.Generic;
using EXLtestApp.IRepository;
using System.Data.Entity;
using System.Linq;

namespace EXLtestApp.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDBContext context) : base(context)
        { 
        
        }

        public AppDBContext AppDBContext
        {
            get { return Context as AppDBContext; }
        }

        public IEnumerable<User> GetSearchUsers(string? criteria, DateTime? empstartdate, DateTime? empenddate)
        {
            bool dateCheckStatus = false;
            if (!string.IsNullOrEmpty(Convert.ToString(empstartdate)) || !string.IsNullOrEmpty(Convert.ToString(empenddate)))
                dateCheckStatus = true;


            var data = AppDBContext.Users.Where(x =>
                                               (string.IsNullOrEmpty(criteria) || x.Name.Contains(criteria))
                                                && (!dateCheckStatus || (x.EmpStartDate >= empstartdate && (x.EmpEndDate ?? DateTime.Now.Date) >= empenddate)));
            return data;
        }
    }
}
