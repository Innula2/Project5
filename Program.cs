using Microsoft.EntityFrameworkCore;
namespace Project5
{
    class Program
    {
        static void Main(string[] args)
        {
            using (sequritesContext db = new sequritesContext())
            {
                // получаем товары из БД и выводим на консоль
                var operation = db.Operations.ToList();
                Console.WriteLine("\nСписок операций:");
                foreach (var p in operation)
                {
                    Console.WriteLine($"{p.Id} {p.Dealid} {p.Subaccountid} {p.Number,-5} {p.Data,10} {p.Type} {p.Sum} {p.Saldoinput} {p.Saldooutput} ");
                }
                // получаем клиентов из БД и выводим на консоль
                
            }
            Console.ReadLine();
        }
    }
}