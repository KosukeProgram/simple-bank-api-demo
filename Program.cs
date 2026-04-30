using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Sample in-memory data
var accounts = new Dictionary<string, Account>
{
    { "A1001", new Account("A1001", 2500.75m, "USD") },
    { "A1002", new Account("A1002", 9800.00m, "USD") }
};

// API endpoint
app.MapPost("/api/account/balance", ([FromBody] AccountRequest request) =>
{
    // Validation
    if (request == null || string.IsNullOrWhiteSpace(request.AccountId))
    {
        return Results.BadRequest(new
        {
            status = "Error",
            message = "accountId is required"
        });
    }

    // Check data
    if (!accounts.TryGetValue(request.AccountId, out var account))
    {
        return Results.NotFound(new
        {
            status = "Error",
            message = "Account not found"
        });
    }

    // Success response
    return Results.Ok(new
    {
        status = "Success",
        accountId = account.AccountId,
        balance = account.Balance,
        currency = account.Currency
    });
});

app.Run();

// Models
record AccountRequest(string AccountId);

record Account(string AccountId, decimal Balance, string Currency);
