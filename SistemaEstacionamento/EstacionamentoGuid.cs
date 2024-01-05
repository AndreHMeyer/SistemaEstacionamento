using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstacionamento
{
    public class EstacionamentoGuid
    {
        private Estacionamento estacionamento = new Estacionamento();

        public void Menu()
        {
            int escolha;

            SolicitaValores();

            do
            {
                ExibirMenu();

                Console.Write("Escolha uma opção (1-4): ");

                if (!int.TryParse(Console.ReadLine(), out escolha))
                {
                    Console.WriteLine("Opção inválida. Por favor, insira um número válido.");
                    continue;
                }

                switch (escolha)
                {
                    case 1:
                        AdicionarVeiculos();
                        break;
                    case 2:
                        ListarVeiculos();
                        break;
                    case 3:
                        RemoverVeiculo();
                        break;
                    case 4:
                        Encerrar();
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                        break;
                }

            } while (escolha != 4);
        }

        private void SolicitaValores()
        {
            Console.Write("Informe o valor inicial do estacionamento: ");
            double precoInicial;

            while (!double.TryParse(Console.ReadLine(), out precoInicial) || precoInicial < 0)
            {
                Console.WriteLine("Valor inválido. Por favor, insira um número não negativo.");
            }

            Console.Write("\nInforme o valor hora do estacionamento: ");
            double precoHora;

            while (!double.TryParse(Console.ReadLine(), out precoHora) || precoHora < 0)
            {
                Console.WriteLine("Valor inválido. Por favor, insira um número não negativo.");
            }

            estacionamento.precoInicial = precoInicial;
            estacionamento.precoHora = precoHora;

        }

        private void ExibirMenu()
        {
            Console.Clear();

            Console.WriteLine("--- MENU ---");
            Console.WriteLine("\n1. Cadastrar Veículo");
            Console.WriteLine("2. Listar Veículos");
            Console.WriteLine("3. Remover Veículo");
            Console.WriteLine("4. Encerrar");
        }

        private void AdicionarVeiculos()
        {
            Console.Clear();

            Console.WriteLine("Digite as placas dos veículos que você deseja adicionar. (Digite 'Sair' para encerrar):");

            while (true)
            {
                string placa = Console.ReadLine();

                if (placa.ToUpper() == "SAIR")
                {
                    break;
                }

                estacionamento.AdicionarVeiculo(new System.Collections.Generic.List<string> { placa });
            }

            Console.WriteLine("\nVeículos cadastrados com sucesso.");

            Console.WriteLine("\nPressione qualquer tecla para sair");
            Console.ReadKey(true);

            ExibirMenu();
        }

        private void ListarVeiculos()
        {
            Console.Clear();

            try
            {
                Console.WriteLine("--- VEÍCULOS CADASTRADOS ---\n");
                estacionamento.ListarVeiculos();
                Console.WriteLine("\nPressione qualquer tecla para sair");
                Console.Read();

                ExibirMenu();
            }
            catch (Exception error)
            {
                Console.WriteLine($"Erro ao listar veículos: {error.Message}");

                Console.WriteLine("\nPressione qualquer tecla para sair");
                Console.Read();
            }
        }

        private void RemoverVeiculo()
        {
            Console.Clear();

            estacionamento.ListarVeiculos();

            Console.Write("\nDigite a placa do veículo que você deseja remover: ");
            string placaVeiculo = Console.ReadLine();

            Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
            int quantidadeHoras;
            while (!int.TryParse(Console.ReadLine(), out quantidadeHoras) || quantidadeHoras < 0)
            {
                Console.WriteLine("Quantidade de horas inválida. Por favor, insira um valor inteiro não negativo.");
            }

            try
            {
                estacionamento.RemoverVeiculo(placaVeiculo, quantidadeHoras);

                Console.WriteLine("Veículo removido com sucesso.");

                Console.WriteLine("\nPressione qualquer tecla para sair");
                Console.Read();

                ExibirMenu();
            }
            catch (Exception error)
            {
                Console.WriteLine($"Erro ao remover veículo: {error.Message}");

                Console.WriteLine("\nPressione qualquer tecla para sair");
                Console.Read();
            }
        }

        private void Encerrar()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Sistema Encerrado");
            Console.ResetColor();
        }
    }
}
