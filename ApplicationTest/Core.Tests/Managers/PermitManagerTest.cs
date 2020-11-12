using Core.Interfaces;
using Core.Managers;
using Core.Models;
using Core.ViewModels;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Tests.Managers
{
    public sealed class PermitManagerTest
    {
        [Test]
        public async Task CreateWhenExceptionOcuredThenReturnOperationResultFailed()
        {
            PermitCreateOrEditViewModel permitCreateViewModel = new PermitCreateOrEditViewModel
            {
                EmployeeName = "sadasd",
                EmployeeLastName = "alalal",
                PermitType = 51,
                Date = DateTime.Now
            };

            IPermitRepositoy permitRepository = Substitute.For<IPermitRepositoy>();
            IPermitTypeRepository permitTypeRepository = Substitute.For<IPermitTypeRepository>();

            permitRepository.When(p => p.Create(Arg.Any<Permit>())).Do(call => { throw new ArgumentException(); });
            permitTypeRepository.FindAsync(Arg.Any<Expression<Func<PermitType, bool>>>()).ReturnsForAnyArgs(new PermitType());

            PermitManager permitManager = new PermitManager(permitRepository, permitTypeRepository);
            IOperationResult<bool> operationResult = await permitManager.Create(permitCreateViewModel);

            Assert.IsFalse(operationResult.Success);
            Assert.AreEqual("Ha ocurrido un error al registrar el permiso.", operationResult.Message);
        }

        [Test]
        public async Task CreateWhenEmployeeNameIsEmptyThenReturnOperationResultFailed()
        {
            PermitCreateOrEditViewModel permitCreateViewModel = new PermitCreateOrEditViewModel
            {
                EmployeeName = "",
                EmployeeLastName = "alalal",
                PermitType = 0,
                Date = DateTime.Now
            };

            IPermitRepositoy permitRepository = Substitute.For<IPermitRepositoy>();
            IPermitTypeRepository permitTypeRepository = Substitute.For<IPermitTypeRepository>();

            PermitManager permitManager = new PermitManager(permitRepository, permitTypeRepository);
            IOperationResult<bool> operationResult = await permitManager.Create(permitCreateViewModel);

            Assert.IsFalse(operationResult.Success);
            Assert.AreEqual("El nombre del empleado no puede estar vacio.", operationResult.Message);
        }

        [Test]
        public async Task CreateWhenEmployeeLastNameIsEmptyThenReturnOperationResultFailed()
        {
            PermitCreateOrEditViewModel permitCreateViewModel = new PermitCreateOrEditViewModel
            {
                EmployeeName = "sadsad",
                EmployeeLastName = "",
                PermitType = 0,
                Date = DateTime.Now
            };

            IPermitRepositoy permitRepository = Substitute.For<IPermitRepositoy>();
            IPermitTypeRepository permitTypeRepository = Substitute.For<IPermitTypeRepository>();

            PermitManager permitManager = new PermitManager(permitRepository, permitTypeRepository);
            IOperationResult<bool> operationResult = await permitManager.Create(permitCreateViewModel);

            Assert.IsFalse(operationResult.Success);
            Assert.AreEqual("El apellido del empleado no puede estar vacio.", operationResult.Message);
        }

        [Test]
        public async Task CreateWhenEmployeePermitTypeIs0ThenReturnOperationResultFailed()
        {
            PermitCreateOrEditViewModel permitCreateViewModel = new PermitCreateOrEditViewModel
            {
                EmployeeName = "sadsad",
                EmployeeLastName = "sadsad",
                PermitType = 0,
                Date = DateTime.Now
            };

            IPermitRepositoy permitRepository = Substitute.For<IPermitRepositoy>();
            IPermitTypeRepository permitTypeRepository = Substitute.For<IPermitTypeRepository>();

            PermitManager permitManager = new PermitManager(permitRepository, permitTypeRepository);
            IOperationResult<bool> operationResult = await permitManager.Create(permitCreateViewModel);

            Assert.IsFalse(operationResult.Success);
            Assert.AreEqual("El tipo de permiso no es valido.", operationResult.Message);
        }

        [Test]
        public async Task CreateWhenPermitTypeIsNullThenReturnOperationResultFailed()
        {
            PermitCreateOrEditViewModel permitCreateViewModel = new PermitCreateOrEditViewModel
            {
                EmployeeName = "sadsad",
                EmployeeLastName = "sadsad",
                PermitType = 1,
                Date = DateTime.Now
            };

            IPermitRepositoy permitRepository = Substitute.For<IPermitRepositoy>();
            IPermitTypeRepository permitTypeRepository = Substitute.For<IPermitTypeRepository>();
            permitTypeRepository.FindAsync(Arg.Any<Expression<Func<PermitType, bool>>>()).ReturnsForAnyArgs(default(PermitType));

            PermitManager permitManager = new PermitManager(permitRepository, permitTypeRepository);
            IOperationResult<bool> operationResult = await permitManager.Create(permitCreateViewModel);

            Assert.IsFalse(operationResult.Success);
            Assert.AreEqual("No se encontro el permiso en la base de datos.", operationResult.Message);
        }

        [Test]
        public async Task CreateWhenPermitIsCorrecThenReturnOperationResultSuccess()
        {
            PermitCreateOrEditViewModel permitCreateViewModel = new PermitCreateOrEditViewModel
            {
                EmployeeName = "sadsad",
                EmployeeLastName = "sadsad",
                PermitType = 1,
                Date = DateTime.Now
            };

            IPermitRepositoy permitRepository = Substitute.For<IPermitRepositoy>();
            IPermitTypeRepository permitTypeRepository = Substitute.For<IPermitTypeRepository>();
            permitTypeRepository.FindAsync(Arg.Any<Expression<Func<PermitType, bool>>>()).ReturnsForAnyArgs(new PermitType());

            PermitManager permitManager = new PermitManager(permitRepository, permitTypeRepository);
            IOperationResult<bool> operationResult = await permitManager.Create(permitCreateViewModel);

            Assert.IsTrue(operationResult.Success);
        }

        [Test]
        public async Task UpdateWhenExceptionOcuredThenReturnOperationResultFailed()
        {
            PermitCreateOrEditViewModel permitCreateViewModel = new PermitCreateOrEditViewModel
            {
                EmployeeName = "sadasd",
                EmployeeLastName = "alalal",
                PermitType = 51,
                Date = DateTime.Now
            };

            IPermitRepositoy permitRepository = Substitute.For<IPermitRepositoy>();
            IPermitTypeRepository permitTypeRepository = Substitute.For<IPermitTypeRepository>();

            permitRepository.When(p => p.FindAsync(Arg.Any<Expression<Func<Permit, bool>>>())).Do(call => { throw new ArgumentException(); });
            permitTypeRepository.FindAsync(Arg.Any<Expression<Func<PermitType, bool>>>()).ReturnsForAnyArgs(new PermitType());

            PermitManager permitManager = new PermitManager(permitRepository, permitTypeRepository);
            IOperationResult<bool> operationResult = await permitManager.Update(permitCreateViewModel);

            Assert.IsFalse(operationResult.Success);
            Assert.AreEqual("Ha ocurrido un error al actualizar el permiso.", operationResult.Message);
        }

        [Test]
        public async Task UpdateWhenEmployeeNameIsEmptyThenReturnOperationResultFailed()
        {
            PermitCreateOrEditViewModel permitCreateViewModel = new PermitCreateOrEditViewModel
            {
                EmployeeName = "",
                EmployeeLastName = "alalal",
                PermitType = 0,
                Date = DateTime.Now
            };

            IPermitRepositoy permitRepository = Substitute.For<IPermitRepositoy>();
            IPermitTypeRepository permitTypeRepository = Substitute.For<IPermitTypeRepository>();

            PermitManager permitManager = new PermitManager(permitRepository, permitTypeRepository);
            IOperationResult<bool> operationResult = await permitManager.Update(permitCreateViewModel);

            Assert.IsFalse(operationResult.Success);
            Assert.AreEqual("El nombre del empleado no puede estar vacio.", operationResult.Message);
        }

        [Test]
        public async Task UpdateWhenEmployeeLastNameIsEmptyThenReturnOperationResultFailed()
        {
            PermitCreateOrEditViewModel permitCreateViewModel = new PermitCreateOrEditViewModel
            {
                EmployeeName = "sadsad",
                EmployeeLastName = "",
                PermitType = 0,
                Date = DateTime.Now
            };

            IPermitRepositoy permitRepository = Substitute.For<IPermitRepositoy>();
            IPermitTypeRepository permitTypeRepository = Substitute.For<IPermitTypeRepository>();

            PermitManager permitManager = new PermitManager(permitRepository, permitTypeRepository);
            IOperationResult<bool> operationResult = await permitManager.Update(permitCreateViewModel);

            Assert.IsFalse(operationResult.Success);
            Assert.AreEqual("El apellido del empleado no puede estar vacio.", operationResult.Message);
        }

        [Test]
        public async Task UpdateWhenEmployeePermitTypeIs0ThenReturnOperationResultFailed()
        {
            PermitCreateOrEditViewModel permitCreateViewModel = new PermitCreateOrEditViewModel
            {
                EmployeeName = "sadsad",
                EmployeeLastName = "sadsad",
                PermitType = 0,
                Date = DateTime.Now
            };

            IPermitRepositoy permitRepository = Substitute.For<IPermitRepositoy>();
            IPermitTypeRepository permitTypeRepository = Substitute.For<IPermitTypeRepository>();

            PermitManager permitManager = new PermitManager(permitRepository, permitTypeRepository);
            IOperationResult<bool> operationResult = await permitManager.Update(permitCreateViewModel);

            Assert.IsFalse(operationResult.Success);
            Assert.AreEqual("El tipo de permiso no es valido.", operationResult.Message);
        }

        [Test]
        public async Task UpdateWhenPermitTypeIsNullThenReturnOperationResultFailed()
        {
            PermitCreateOrEditViewModel permitCreateViewModel = new PermitCreateOrEditViewModel
            {
                EmployeeName = "sadsad",
                EmployeeLastName = "sadsad",
                PermitType = 1,
                Date = DateTime.Now
            };

            IPermitRepositoy permitRepository = Substitute.For<IPermitRepositoy>();
            IPermitTypeRepository permitTypeRepository = Substitute.For<IPermitTypeRepository>();
            permitTypeRepository.FindAsync(Arg.Any<Expression<Func<PermitType, bool>>>()).ReturnsForAnyArgs(default(PermitType));

            PermitManager permitManager = new PermitManager(permitRepository, permitTypeRepository);
            IOperationResult<bool> operationResult = await permitManager.Update(permitCreateViewModel);

            Assert.IsFalse(operationResult.Success);
            Assert.AreEqual("No se encontro el permiso en la base de datos.", operationResult.Message);
        }

        [Test]
        public async Task UpdateWhenPermitIsCorrecThenReturnOperationResultSuccess()
        {
            PermitCreateOrEditViewModel permitCreateViewModel = new PermitCreateOrEditViewModel
            {
                EmployeeName = "sadsad",
                EmployeeLastName = "sadsad",
                PermitType = 1,
                Date = DateTime.Now
            };

            IPermitRepositoy permitRepository = Substitute.For<IPermitRepositoy>();
            IPermitTypeRepository permitTypeRepository = Substitute.For<IPermitTypeRepository>();
            permitTypeRepository.FindAsync(Arg.Any<Expression<Func<PermitType, bool>>>()).ReturnsForAnyArgs(new PermitType());
            permitRepository.FindAsync(Arg.Any<Expression<Func<Permit, bool>>>()).ReturnsForAnyArgs(new Permit());

            PermitManager permitManager = new PermitManager(permitRepository, permitTypeRepository);
            IOperationResult<bool> operationResult = await permitManager.Update(permitCreateViewModel);

            Assert.IsTrue(operationResult.Success);
        }
    }
}
