namespace GestaoEquipamentos.ConsoleApp
{
    public partial class Program
    {
        public class Menus()
        {
            public  void MenuInicial()
            {
                ParteSuperiorMenu();
                Console.WriteLine("0- Acessar Menu Equipamentos \n1-Acessar Menu Chamados  \n2-Sair");
            }
            public  void ParteSuperiorMenu()
            {
                Console.Clear();
                Console.WriteLine("Gestão de Equipamentos - 2024");
                Console.WriteLine("----------------------------------------------------------------------------");
                Console.WriteLine("Digite qual opção deseja seguir:");
            }
            public  void ExibirMenuEquipamentos()
            {
                ParteSuperiorMenu();
                Console.WriteLine("0- Registrar Equipamentos \n1- Visualizar Equipamentos do Inventário\n2-Editar Equipamento\n3-Excluir Equipamento Registrado");
            }
            public  void ExibirMenuChamados()
            {
                ParteSuperiorMenu();
                Console.WriteLine("4- Cadastrar Chamado \n5- Visualizar Chamados \n6-Editar Chamados\n7-Excluir Chamado Registrado");
            }
        }

       
    }


}
