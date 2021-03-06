using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Store;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class OfficesRepository : RepositoryBase<Offices>, IOfficesRepository
    {
        private RepositoryContext _repositoryContext;
        public OfficesRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<Offices> GetAllOffices()
        {
            return FindAll()
                .OrderBy(o => o.OfficeId)
                .Include(e => e.Employees)
                .ToList();
        }

        public async Task CreateOffices(Offices offices)
        {
            await Task.Run(() => Create(offices));
        }

        public void DeleteOffices(Offices offices)
        {
            Delete(offices);
        }

        public async Task<Offices> GetOfficesByOfficesCode(int OfficesID)
        {
            return await FindByCondition(officesCode => officesCode.OfficeId.Equals(OfficesID))
            .FirstOrDefaultAsync();
        }

        public async Task UpdateOffices(Offices offices)
        {

            await Task.Run(() => Update(offices));
        }

        public async Task<Offices> FindOfficeByIdAsync(int OfficesID)
        {
            return await FindByCondition(x => x.OfficeId.Equals(OfficesID)).Include(x => x.Employees).FirstOrDefaultAsync();

        }








    }
}

