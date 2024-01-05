using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SistemaEstacionamento
{
    public class Estacionamento
    {
        public double precoInicial { get; set; }
        public double precoHora { get; set; }
        public List<string> placasVeiculos { get; set; }

        public Estacionamento()
        {
            placasVeiculos = new List<string>();
        }

        public void AdicionarVeiculo(List<string> placasVeiculos)
        {
            string padraoPlaca = @"^[A-Za-z]{3}-\d{4}$";

            foreach (var placa in placasVeiculos)
            {
                var validaPlaca = Regex.IsMatch(placa, padraoPlaca);

                if (validaPlaca)
                {
                    this.placasVeiculos.Add(placa);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Placa Inválida! Digite 'Sair' para voltar.");
                    
                }
            }
        }

        public void ListarVeiculos()
        {
            foreach (var veiculo in placasVeiculos)
            {
                Console.WriteLine(" - " + veiculo);
            }
        }

        public void RemoverVeiculo(string placaVeiculo, int quantidadeHoras)
        {
            double valorTotal = precoInicial + (precoHora * quantidadeHoras);

            if (placasVeiculos.Contains(placaVeiculo))
            {
                placasVeiculos.Remove(placaVeiculo);
                Console.Clear();
                Console.WriteLine("O valor a ser pago é de R$" + valorTotal);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Veículo com placa " + placaVeiculo + " não encontrado.");
            }

            Console.WriteLine("\nPressione qualquer tecla para sair");
            Console.Read();
        }

    }
}
