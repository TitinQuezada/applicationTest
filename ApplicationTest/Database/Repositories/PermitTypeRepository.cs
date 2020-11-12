using Core.Interfaces;
using Core.Models;

namespace Database.Repositories
{
    public sealed class PermitTypeRepository : BaseRepository<PermitType>, IPermitTypeRepository
    {
        public PermitTypeRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
