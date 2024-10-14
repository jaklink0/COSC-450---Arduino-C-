namespace C__Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter your name");
            String name = Console.ReadLine();
            Console.WriteLine("Hello, " + name);


            Console.WriteLine("Please Enter your age");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("You are " + age + " years old!");
            Console.WriteLine(age.GetType());
        }
    }
}
