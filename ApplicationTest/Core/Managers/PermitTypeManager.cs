using Core.Interfaces;
using Core.Models;
using Core.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Core.Managers
{
    public sealed class PermitTypeManager
    {
        private readonly IPermitTypeRepository _permitTypeRepository;

        public PermitTypeManager(IPermitTypeRepository permitTypeRepository)
        {
            _permitTypeRepository = permitTypeRepository;
        }

        public IOperationResult<IEnumerable<PermitTypeViewModel>> GetAll()
        {
            try
            {
                IEnumerable<PermitType> permitTypes = _permitTypeRepository.Get();
                IEnumerable<PermitTypeViewModel> permitTypesResult = BuildPermitTypes(permitTypes);

                return OperationResult<IEnumerable<PermitTypeViewModel>>.Ok(permitTypesResult);
            }
            catch
            {
                return OperationResult<IEnumerable<PermitTypeViewModel>>.Fail("Ha ocurrido un error obteniendo los tipos de permiso");
            }
        }

        private IEnumerable<PermitTypeViewModel> BuildPermitTypes(IEnumerable<PermitType> permitTypes)
        {
            return permitTypes.Select(permitType => new PermitTypeViewModel
            {
                Id = permitType.Id,
                Description = permitType.Description
            });
        }
    }
}
