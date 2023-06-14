// See https://aka.ms/new-console-template for more information

using ServiceReference1;

Service1Client client = new Service1Client();

try
{
    int result = client.SquareAsync(5).Result;
    Console.WriteLine("Результат: " + result);
}
catch (Exception ex)
{
    Console.WriteLine("Помилка: " + ex.Message);
}
finally
{
    client.Close();
}

Console.ReadLine();

