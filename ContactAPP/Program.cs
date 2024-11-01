using ContactAPP.Presentation;

namespace ContactAPP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContactAppMenu contactAppMenu = new ContactAppMenu();

            Console.WriteLine("============== Welcome To Contact App =============\n");

            contactAppMenu.ShowMenu();
        }
    }
}
