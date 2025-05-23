using System.Threading.Tasks;
using HospitalManagment_V2.DataAccess.Entities;
using HospitalManagment_V2.Dtos;
using HospitalManagment_V2.Mediator.Patients.CreatePatient;
using HospitalManagment_V2.Repository;
using Moq;
using Moq.AutoMock;

namespace PatiebtTests
{
    public class UnitTest1
    {

        private readonly AutoMocker _mocker = new();

        [Fact]
        public async Task CreatePatientCommand_ValidInput_ShouldSuccess()
        {
            // Arrange 
            var dto = new PatientDto
            {
                FirstName = "Ubaydullo",
                LastName = "Nasriddinov",
                DateOfBirth = DateOnly.FromDateTime(DateTime.Now),
                IsActive = true,
                RegisteredDate = DateTime.Now,
                PatientBlankId = 1
            };
            var command = new CreatePatientCommand(dto);

            var handler = _mocker.CreateInstance<CreatePatientCommandHandler>();

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert 
            Assert.NotNull(result);

            _mocker.GetMock<IPatientRepository>()
            .Verify((r) => r.AddAsync(It.IsAny<Patient>()), Times.Once);
        }
    }
}