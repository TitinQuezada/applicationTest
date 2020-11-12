using Core.Interfaces;
using Core.Models;
using Core.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Managers
{
    public sealed class PermitManager
    {
        private readonly IPermitRepositoy _permitRepositoy;
        private readonly IPermitTypeRepository _permitTypeRepositoy;

        public PermitManager(IPermitRepositoy permitRepositoy, IPermitTypeRepository permitTypeRepository)
        {
            _permitRepositoy = permitRepositoy;
            _permitTypeRepositoy = permitTypeRepository;
        }

        public async Task<IOperationResult<bool>> Create(PermitCreateOrEditViewModel permit)
        {
            try
            {
                IOperationResult<string> validationResult = ValidatePermit(permit);

                if (!validationResult.Success)
                {
                    return OperationResult<bool>.Fail(validationResult.Message);
                }

                IOperationResult<Permit> permitToCreateResult = await BuildPermit(permit);

                if (!permitToCreateResult.Success)
                {
                    return OperationResult<bool>.Fail(permitToCreateResult.Message);
                }

                _permitRepositoy.Create(permitToCreateResult.Entity);

                await _permitRepositoy.SaveAsync();

                return OperationResult<bool>.Ok(true);
            }
            catch
            {
                return OperationResult<bool>.Fail("Ha ocurrido un error al registrar el permiso.");
            }
        }

        private IOperationResult<string> ValidatePermit(PermitCreateOrEditViewModel permit)
        {
            if (string.IsNullOrWhiteSpace(permit.EmployeeName))
            {
                return OperationResult<string>.Fail("El nombre del empleado no puede estar vacio.");
            }

            if (string.IsNullOrWhiteSpace(permit.EmployeeLastName))
            {
                return OperationResult<string>.Fail("El apellido del empleado no puede estar vacio.");
            }

            if (permit.PermitType == default(int))
            {
                return OperationResult<string>.Fail("El tipo de permiso no es valido.");
            }

            return OperationResult<string>.Ok();
        }

        private async Task<IOperationResult<Permit>> BuildPermit(PermitCreateOrEditViewModel permitToCreate)
        {
            PermitType permitType = await _permitTypeRepositoy.FindAsync(permitType => permitType.Id == permitToCreate.PermitType);

            if (permitType == null)
            {
                return OperationResult<Permit>.Fail("No se encontro el permiso en la base de datos.");
            }

            var permit = new Permit
            {
                Id = 0,
                EmployeeName = permitToCreate.EmployeeName,
                EmployeeLastName = permitToCreate.EmployeeLastName,
                PermitType = permitType,
                Date = permitToCreate.Date
            };

            return OperationResult<Permit>.Ok(permit);
        }

        public async Task<IOperationResult<bool>> Update(PermitCreateOrEditViewModel permitToUpdate)
        {
            try
            {
                IOperationResult<string> validationResult = ValidatePermit(permitToUpdate);

                if (!validationResult.Success)
                {
                    return OperationResult<bool>.Fail(validationResult.Message);
                }

                Permit permit = await _permitRepositoy.FindAsync(permit => permit.Id == permitToUpdate.Id);

                PermitType permitType = await _permitTypeRepositoy.FindAsync(permitType => permitType.Id == permitToUpdate.PermitType);

                if (permitType == null)
                {
                    return OperationResult<bool>.Fail("No se encontro el permiso en la base de datos.");
                }

                permit.EmployeeName = permitToUpdate.EmployeeName;
                permit.EmployeeLastName = permitToUpdate.EmployeeLastName;
                permit.PermitType = permitType;
                permit.Date = permitToUpdate.Date;

                await _permitRepositoy.SaveAsync();

                return OperationResult<bool>.Ok(true);
            }
            catch
            {
                return OperationResult<bool>.Fail("Ha ocurrido un error al actualizar el permiso.");
            }
        }

        public IOperationResult<IEnumerable<PermitViewModel>> GetAll()
        {
            try
            {
                IEnumerable<Permit> permits = _permitRepositoy.Get();

                IEnumerable<PermitViewModel> permitsResult = BuildPermits(permits);

                return OperationResult<IEnumerable<PermitViewModel>>.Ok(permitsResult);
            }
            catch
            {
                return OperationResult<IEnumerable<PermitViewModel>>.Fail("Ha ocurrido un error al cargar los permiso.");
            }
        }

        private IEnumerable<PermitViewModel> BuildPermits(IEnumerable<Permit> permits)
        {
            return permits.Select(permit => new PermitViewModel
            {
                Id = permit.Id,
                EmployeeName = permit.EmployeeName,
                EmployeeLastName = permit.EmployeeLastName,
                PermitType = _permitTypeRepositoy.Find(permitType => permitType.Id == 1).Description,
                Date = permit.Date
            });
        }

        public async Task<IOperationResult<bool>> Delete(int permitId)
        {
            try
            {
                _permitRepositoy.Delete(permitId);

                await _permitRepositoy.SaveAsync();

                return OperationResult<bool>.Ok();
            }
            catch
            {
                return OperationResult<bool>.Fail("Ha ocurrido un error al eliminar el permiso.");
            }
        }
    }
}
