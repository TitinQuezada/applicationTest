using Core.Interfaces;
using Core.Models;

namespace Database.Repositories
{
    public sealed class PermitRepositoy : BaseRepository<Permit> , IPermitRepositoy
    {
        public PermitRepositoy(ApplicationContext context) : base(context)
        {
        }
    }
}
