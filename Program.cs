// This demo focuses on core API functionality:
// - JSON request/response handling
// - Input validation
// - API logic for processing requests and returning responses
// Note: Database interaction is simulated using in-memory data.

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Simulated in-memory data used as a mock database for demo purposes.
// In a real application, this data would be retrieved from a database such as SQL Server.
var accounts = new Dictionary<string, Account>
{
    { "A1001", new Account("A1001", 2500.75m, "USD") },
    { "A1002", new Account("A1002", 9800.00m, "USD") }
};

// API endpoint to retrieve account balance.
// Maps the JSON request body to the AccountRequest object.
app.MapPost("/api/account/balance", ([FromBody] AccountRequest request) =>
{
    // Validate that the required accountId field is provided.
    if (request == null || string.IsNullOrWhiteSpace(request.AccountId))
    {
        return Results.BadRequest(new
        {
            status = "Error",
            message = "accountId is required"
        });
    }

    // Simulate account lookup using the provided accountId.
    if (!accounts.TryGetValue(request.AccountId, out var account))
    {
        return Results.NotFound(new
        {
            status = "Error",
            message = "Account not found"
        });
    }
    
    // Return a successful JSON response with account data.
    return Results.Ok(new
    {
        status = "Success",
        accountId = account.AccountId,
        balance = account.Balance,
        currency = account.Currency
    });
});

// Start the web application and begin listening for incoming HTTP requests.
app.Run();

// Models

// Defines the structure of incoming JSON request data.
// Example: { "accountId": "A1001" }
record AccountRequest(string AccountId);

// Defines the structure of account data used within the application.
// In a real system, this data would be retrieved from a database using SQL
// and mapped into this object before being returned as a JSON response.
record Account(string AccountId, decimal Balance, string Currency);