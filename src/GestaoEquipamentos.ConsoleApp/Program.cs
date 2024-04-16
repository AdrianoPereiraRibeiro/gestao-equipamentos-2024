namespace GestaoEquipamentos.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] lista = new string[100];
            int numeroDoEstoque = 0;
            bool sairDoSistema = true;
            while (sairDoSistema)
            {
                ExibirMenu();
                GerenciamentoEquipamento gerenciamento = new GerenciamentoEquipamento();
                Equipamento equipamento = new Equipamento();
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 0:
                        lista = gerenciamento.CadastrarEquipamento(lista, numeroDoEstoque);
                        numeroDoEstoque++;
                        break;
                    case 1:
                        for (int i = 0; i < numeroDoEstoque; i++)
                            Console.WriteLine(lista[i]);
                        Console.ReadLine();
                        break;
                    case 2:
                        lista = gerenciamento.EditarEquipamentos(lista);
                        break;
                    case 3:
                        lista = gerenciamento.ExcluirEquipamentos(lista);
                        break;
                    case 4:
                        sairDoSistema = false;
                        break;
                }



            }
        }

        private static void ExibirMenu()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Equipamentos - 2024");
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine("Digite qual opção deseja seguir:");
            Console.WriteLine("0- Registrar Equipamentos \n1- Visualizar Equipamentos do Inventário\n2-Editar Equipamento\n3-Excluir Equipamento Registrado\n4-Sair do Sistema");
        }
    }



}

