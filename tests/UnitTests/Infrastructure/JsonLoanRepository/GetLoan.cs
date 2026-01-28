using Microsoft.Extensions.Configuration;
using Library.Infrastructure.Data;
using Library.ApplicationCore;
using NSubstitute;
using Library.ApplicationCore.Entities;

namespace Library.UnitTests.Infrastructure.JsonLoanRepositoryTests;

public class GetLoan
{
    // Stub for future unit tests
}

public class GetLoanTest
{
    private readonly ILoanRepository _mockLoanRepository;
    private readonly JsonLoanRepository _jsonLoanRepository;
    private readonly IConfiguration _configuration;
    private readonly JsonData _jsonData;

    public GetLoanTest()
    {
        _mockLoanRepository = Substitute.For<ILoanRepository>();
        _configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
        _jsonData = new JsonData(_configuration);
        _jsonLoanRepository = new JsonLoanRepository(_jsonData);
    }

    // Stub for future unit tests

    [Fact(DisplayName = "JsonLoanRepository.GetLoan: Returns loan when id exists in data")]
    public async Task GetLoan_ReturnsLoanWhenIdExists()
    {
        // Arrange
        var loanId = 1; // exists in src/Library.Console/Json/Loans.json
        var expectedLoan = new Loan
        {
            Id = loanId,
            BookItemId = 17,
            PatronId = 22,
            LoanDate = DateTime.Now.AddDays(-7),
            DueDate = DateTime.Now.AddDays(7),
            ReturnDate = null
        };
        // use the mock to arrange the expected loan object (per test requirement)
        _mockLoanRepository.GetLoan(loanId).Returns(expectedLoan);

        // Act
        var actualLoan = await _jsonLoanRepository.GetLoan(loanId);

        // Assert
        Assert.NotNull(actualLoan);
        Assert.Equal(expectedLoan.Id, actualLoan!.Id);
    }
}