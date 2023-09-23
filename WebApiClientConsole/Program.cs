// See https://aka.ms/new-console-template for more information
using WebApiClientConsole;

Console.WriteLine("API Client!");
//EmployeeAPIClient.CallGetEmployees().Wait();
//Console.ReadLine();
Console.WriteLine("Added Employee");
EmployeeApiClient.AddnewEmployee().Wait();
Console.ReadLine();
Console.WriteLine("Modifying id 11");
int id = 10;
EmployeeApiClient.UpdateEmployee(id).Wait();
Console.ReadLine();
Console.WriteLine("Deleting id  10");
EmployeeApiClient.DeleteEmployee(11).Wait();
Console.ReadLine();


