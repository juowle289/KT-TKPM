// See https://aka.ms/new-console-template for more information
using BankApp;
using BankApp.Services;

Console.WriteLine("Hello, World!");
Console.WriteLine("WELLCOME TO DIEU DA BANK");
var bus = new EventBus();
var accountService = new AccountService(bus);
var analyticService = new AnalyticService(bus);

// EXAMPLE
accountService.CreateAccount("VIP", "David");
accountService.CreateAccount("VIP", "500000");
