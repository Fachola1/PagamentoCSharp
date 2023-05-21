using System;
using System.Threading.Tasks;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        var cliente = new ContaBancaria();
        MenuPrograma(cliente);

        Console.ReadLine();
    }

    static void MenuPrograma(ContaBancaria cliente)
    {
        Console.WriteLine("Digite o valor que deseja iniciar: ");
        cliente.Saldo = double.Parse(Console.ReadLine());
        Console.WriteLine();

        Console.WriteLine("Digite seu nome completo: ");
        cliente.Titular = Console.ReadLine();
        Console.WriteLine();

        Console.WriteLine("Digite o número da sua agência de 1 a 200: ");
        cliente.Numero = int.Parse(Console.ReadLine());
        Console.WriteLine();

        Console.Write("Saldo atual: ");
        cliente.ExibirSaldo();

        Console.WriteLine("======================================================");

        Console.Write("Seja bem-vindo, ");
        Console.WriteLine(cliente.Titular);

        Console.WriteLine("======================================================");

        Console.Write("O número da sua agência é: ");
        Console.WriteLine(cliente.Numero);
        Console.WriteLine("\n");
        Console.WriteLine("\n");

        Console.WriteLine("Deseja depositar algum valor em sua conta? Se sim, digite 'sim'. Caso contrário, digite 'nao'");
        string confirmarDeposito = Console.ReadLine();

        if (confirmarDeposito.ToLower() == "sim")
        {
            Console.WriteLine("Digite o valor que deseja depositar em sua conta: ");
            cliente.Depositar(double.Parse(Console.ReadLine()));
        }

        Console.WriteLine("Gostaria de fazer um saque? Se sim, digite 'sim'. Caso contrário, digite 'nao'.");
        string confirmarSaque = Console.ReadLine().ToLower();


        if (confirmarSaque == "sim")
        {
            Console.WriteLine("Digite o valor que deseja sacar de sua conta: ");
            cliente.Sacar(double.Parse(Console.ReadLine()));
        }
        else if (confirmarSaque == "nao")
        {
            Console.WriteLine("Encerrando aplicação...");
            Thread.Sleep(2000);
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine($"O valor {confirmarSaque} não está no padrão de resposta, tente novamente!");
            MenuPrograma(cliente);
        }

        Console.Write($"O seu saldo atual é: ");
        cliente.ExibirSaldo();
    }

    public class ContaBancaria
    {
        public double Saldo { get; set; }
        public string Titular { get; set; }
        public int Numero { get; set; }

        public void Depositar(double valor)
        {
            Saldo += valor;
        }

        public void Sacar(double valor)
        {
            string confirmarVerSaldo;
            if (valor > Saldo)
            {
                Console.WriteLine("Não é possível sacar, saldo insuficiente!");
                Console.WriteLine("Deseja exibir o valor do seu saldo disponível? Se sim, digite 'sim'. Caso contrário, digite 'nao'");
                confirmarVerSaldo = Console.ReadLine();
                if (confirmarVerSaldo == "sim")
                {
                    Console.WriteLine(Saldo);
                }
            }
            else
            {
                Saldo -= valor;
            }
        }

        public void ExibirSaldo()
        {
            Console.WriteLine(Saldo);
        }
    }
}
