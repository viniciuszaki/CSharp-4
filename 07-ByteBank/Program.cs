using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _07_ByteBank;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CarregarContas();
            }
            catch(Exception)
            {
                Console.WriteLine("Catch no metodo MAIN.");
            }

            Console.WriteLine("Execução finalizada. Tecle enter para sair.");
            Console.ReadLine();
        }
        private static void CarregarContas()
        {
            using (LeitorDeArquivos leitor = new LeitorDeArquivos("teste.txt"))
            {
                leitor.LerProximaLinha();
            }


            // ---------------------------------------------

            //LeitorDeArquivos leitor = null;
            //try
            //{
            //    leitor = new LeitorDeArquivos("contasl.txt");

            //    leitor.LerProximaLinha();
            //    leitor.LerProximaLinha();
            //    leitor.LerProximaLinha();
            //}
            //finally
            //{
            //    Console.WriteLine("Executando o finally.");
            //    if (leitor != null)
            //    {
            //        leitor.FecharArquivo();
            //    }
            //}

        }
        private static void TestaInnerException()
        {
            try
            {
                ContaCorrente conta1 = new ContaCorrente(124, 123435);
                ContaCorrente conta2 = new ContaCorrente(726, 628894);

                //conta1.Transferir(10000, conta2);
                conta1.Sacar(10000);
            }
            catch (OperacaoFinanceiraException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                /*Console.WriteLine("Informações da INNER EXCEPTION (exceção interna):");

                Console.WriteLine(e.InnerException.Message);
                Console.WriteLine(e.InnerException.StackTrace);*/

            }
        }

        private static void Metodo()
        {
            TestaDivisao(0);
        }

        private static void TestaDivisao(int divisor)
        {
            try
            {
                Dividir(10, divisor);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("Fui capturado pelo (NullReferenceException ex)");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("Fui capturado pelo (Exception ex)");
            }
        }

        private static int Dividir(int numero, int divisor)
        {
            try
            {
                return numero / divisor;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Exceção com numero = " + numero + " e divisor = " + divisor);
                throw;
            }
        }
    }
}
