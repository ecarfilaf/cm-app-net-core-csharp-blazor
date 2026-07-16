namespace frontend.Components.Widgets.DataTable.Models;

public record Employee(
    string Name,
    string Position,
    string Office,
    int Age,
    DateOnly StartDate,
    decimal Salary
);

public static class EmployeeSampleData
{
    public static readonly List<Employee> All = new()
    {
        new("Tiger Nixon", "System Architect", "Edinburgh", 61, new(2011, 4, 25), 320_800),
        new("Garrett Winters", "Accountant", "Tokyo", 63, new(2011, 7, 25), 170_750),
        new("Ashton Cox", "Junior Technical Author", "San Francisco", 66, new(2009, 1, 12), 86_000),
        new("Cedric Kelly", "Senior Javascript Developer", "Edinburgh", 22, new(2012, 3, 29), 433_060),
        new("Airi Satou", "Accountant", "Tokyo", 33, new(2008, 11, 28), 162_700),
        new("Brielle Williamson", "Integration Specialist", "New York", 61, new(2012, 12, 2), 372_000),
        new("Herrod Chandler", "Sales Assistant", "San Francisco", 59, new(2012, 8, 6), 137_500),
        new("Rhona Davidson", "Integration Specialist", "Tokyo", 55, new(2010, 10, 14), 327_900),
        new("Colleen Hurst", "Javascript Developer", "San Francisco", 39, new(2009, 9, 15), 205_500),
        new("Sonya Frost", "Software Engineer", "Edinburgh", 23, new(2008, 12, 13), 103_600),
    };
}
