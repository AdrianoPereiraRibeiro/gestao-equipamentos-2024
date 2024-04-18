using System.ComponentModel;

namespace GestaoEquipamentos.ConsoleApp.ModuloEquipamentos
{
    public class GerenciamentoEquipamento()
    {

        public string[] CadastrarEquipamento(string[] lista, int numeroDoEstoque)
        {
            Equipamento equipamento = new Equipamento();
            equipamento.ListaDeEquipamento = lista;
            equipamento.numeroDoEstoque = numeroDoEstoque;
            Console.WriteLine("Digite o nome do Equipamento:");
            equipamento.nome = Console.ReadLine();
            Console.WriteLine("Digite o Preço do Equipamento:");
            equipamento.preco = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Digite o Número de Série do Equipamento:");
            equipamento.numeroDeSerie = Console.ReadLine();
            Console.WriteLine("Digite a Data de Fabricação do Equipamento");
            equipamento.DataDeFabricacao = Console.ReadLine();
            Console.WriteLine("Digite o Fabricante do Equipamento:");
            equipamento.Fabricante = Console.ReadLine();
            while (equipamento.nome.Length < 6)
            {
                if (equipamento.nome.Length < 6)
                {
                    Console.WriteLine("O nome deve ter no mínimo 6 caracteres.\nDIGITE NOVAMENTE O NOME:");
                    equipamento.nome = Console.ReadLine();
                }
            }


            Console.WriteLine("Equipamento Registrado!\nAperte ENTER para continuar:");
            Console.ReadLine();


            equipamento.ListaDeEquipamento[numeroDoEstoque] = "Produto " + equipamento.numeroDoEstoque + "\nNome:" + equipamento.nome + "\nPreço:" + equipamento.preco + "\nNumero de série:" + equipamento.numeroDeSerie + "\nData de fabricação:" + equipamento.DataDeFabricacao + "\nFabricante:" + equipamento.Fabricante + "\n-------------------------------------------------------------------------------";


            Console.Clear();
            return equipamento.ListaDeEquipamento;
        }

        public string[] EditarEquipamentos(string[] lista)
        {
            Equipamento equipamento = new Equipamento();
            equipamento.ListaDeEquipamento = lista;
            Console.WriteLine("Digite o numero do produto a ser alterado:");
            int numeroProdutoEditado = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Edite o cadastro do Produto:\n");
            Console.WriteLine("Digite o nome do Equipamento:");
            equipamento.nome = Console.ReadLine();
            Console.WriteLine("Digite o Preço do Equipamento:");
            equipamento.preco = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Digite o Número de Série do Equipamento:");
            equipamento.numeroDeSerie = Console.ReadLine();
            Console.WriteLine("Digite a Data de Fabricação do Equipamento");
            equipamento.DataDeFabricacao = Console.ReadLine();
            Console.WriteLine("Digite o Fabricante do Equipamento:");
            equipamento.Fabricante = Console.ReadLine();
            while (equipamento.nome.Length < 6)
            {
                if (equipamento.nome.Length < 6)
                {
                    Console.WriteLine("O nome deve ter no mínimo 6 caracteres.\nDIGITE NOVAMENTE O NOME:");
                    equipamento.nome = Console.ReadLine();
                }
            }

            Console.WriteLine("Equipamento Editado!\nAperte ENTER para continuar:");
            Console.ReadLine();


            equipamento.ListaDeEquipamento[numeroProdutoEditado] = "Produto " + equipamento.numeroDoEstoque + "\nNome:" + equipamento.nome + "\nPreço:" + equipamento.preco + "\nNumero de série:" + equipamento.numeroDeSerie + "\nData de fabricação:" + equipamento.DataDeFabricacao + "\nFabricante:" + equipamento.Fabricante + "\n-------------------------------------------------------------------------------";
            return equipamento.ListaDeEquipamento;

        }
        public string[] ExcluirEquipamentos(string[] lista)
        {

            Equipamento equipamento = new Equipamento();
            Console.WriteLine("Digite o número do equipamento a ser EXCLUIDO:");
            int exclusao = Convert.ToInt32(Console.ReadLine());
            lista[exclusao] = null;
            Console.WriteLine("Equipamento Excluido!\nAperte ENTER para continuar:");
            Console.ReadLine();
            return lista;
        }




    }



}