// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

Console.WriteLine("Hello, World!");

var areaCalculator = new AreaCalculator();
double area = areaCalculator.CalculateRectangleArea(5, 10);

Console.WriteLine(area);