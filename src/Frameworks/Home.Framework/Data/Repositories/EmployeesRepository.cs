using Home.Framework.Data.Entities;
using Home.Framework.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Home.Framework.Data.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly HomeDBContext _dbContext;
        private readonly DbSet<EmployeeEntity> _employeesEntity;

        public EmployeesRepository(HomeDBContext dbContext)
        {
            _dbContext = dbContext;
            _employeesEntity = _dbContext.Set<EmployeeEntity>();
        }

    }
}
