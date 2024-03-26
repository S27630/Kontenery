
using ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {

        Plyny plyny = new Plyny(300, 300, 3000, 3000, 3000, 30000, true);
        Plyny plyny2 = new Plyny(30000, 32300, 3003210, 3213000, 3000, 30000, true);


        plyny.Load(2000);
        plyny2.Load(20);

    }
}