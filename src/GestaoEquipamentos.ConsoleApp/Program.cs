using Microsoft.Win32.SafeHandles;

namespace GestaoEquipamentos.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] lista = new string[100];
            string[] listaChamados = new string[100];
            int numeroDoEstoque = 0;
            int numeroDosChamados = 0;
            bool sairDoSistema = true;
            DateTime[] DataDoChamado = new DateTime[100];
            while (sairDoSistema)
            {
                MenuInicial();
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 0: ExibirMenuEquipamentos(); break;
                    case 1: ExibirMenuChamados(); break;
                    case 2: sairDoSistema = false; continue;
                    default: Console.WriteLine("Opção Indisponível!"); Console.ReadLine(); continue;

                }
                GerenciamentoEquipamento gerenciamento = new GerenciamentoEquipamento();
                GerenciamentoDeChamados gerenciamentoDeChamados = new GerenciamentoDeChamados();
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 0: lista = gerenciamento.CadastrarEquipamento(lista, numeroDoEstoque); numeroDoEstoque++; break;
                    case 1: for (int i = 0; i < numeroDoEstoque; i++) Console.WriteLine(lista[i]); Console.ReadLine(); break;
                    case 2: lista = gerenciamento.EditarEquipamentos(lista); break;
                    case 3: lista = gerenciamento.ExcluirEquipamentos(lista); break;
                    case 4: IfCadastrarChamado(lista, listaChamados, numeroDoEstoque, numeroDosChamados, DataDoChamado); numeroDosChamados++; break;
                    case 5: MostrarChamados(listaChamados, numeroDosChamados); break;
                    case 6: listaChamados = gerenciamentoDeChamados.EditarChamados(listaChamados, lista, numeroDosChamados, DataDoChamado); break;
                    case 7: listaChamados = gerenciamentoDeChamados.RemoverChamado(listaChamados, numeroDosChamados); break;
                    default: OpcaoIndisponivel(); break;
                }
            }
        }

        private static void MenuInicial()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Equipamentos - 2024");
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine("Digite qual opção deseja seguir:");
            Console.WriteLine("0- Acessar Menu Equipamentos \n1-Acessar Menu Chamados  \n2-Sair");
        }

        private static void MostrarChamados(string[] listaChamados, int numeroDosChamados)
        {
            if (numeroDosChamados == 0) { Console.WriteLine("Não exite nenhum chamado cadastrado!\nAperte ENTER para continuar:"); Console.ReadLine(); }
            else
            {
                for (int i = 0; i < numeroDosChamados; i++)
                    Console.WriteLine(listaChamados[i]);

                Console.ReadLine();
            }
        }

        private static void IfCadastrarChamado(string[] lista, string[] listaChamados, int numeroDoEstoque, int numeroDosChamados, DateTime[] DataDoChamado)
        {
            Equipamento equipamento = new Equipamento();
            Chamados chamados = new Chamados();
            if (numeroDoEstoque == 0)
            {
                ErroEmCadastrarChamado();
            }
            else
            {
                CadastrarNovoChamado(lista, listaChamados, numeroDosChamados, DataDoChamado, equipamento, chamados);
            }
        }

        private static void OpcaoIndisponivel()
        {
            Console.WriteLine("Essa opção não está disponivel!\nAperte ENTER para voltar ao MENU!");
            Console.ReadLine();
        }

        private static void ErroEmCadastrarChamado()
        {
            Console.WriteLine("Impossível Cadastrar Chamados!! Você não possui equipamentos cadastrados!");
            Console.WriteLine("Aperte ENTER para continuar:");
            Console.ReadLine();
        }

        private static void CadastrarNovoChamado(string[] lista, string[] listaChamados, int numeroDosChamados, DateTime[] DataDoChamado, Equipamento equipamento, Chamados chamados)
        {
            chamados.ListaDoChamado = listaChamados;
            chamados.numeroDoChamado = numeroDosChamados;

            equipamento.ListaDeEquipamento = lista;
            Console.WriteLine("CHAMADO " + chamados.numeroDoChamado);
            Console.WriteLine("Digite o Título do Chamado:");
            chamados.Titulo = Console.ReadLine();
            Console.WriteLine("Digite a Descrição do Chamado:");
            chamados.Descricao = Console.ReadLine();
            Console.WriteLine("Digite a Data do Chamado EX:(Dia/Mês/Ano Hora:Minuto):");
            DataDoChamado[numeroDosChamados] = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Digite o número do equipamento que o Chamado se refere:");
            chamados.Equipamento = Convert.ToInt32(Console.ReadLine());
            DateTime dataAtual = DateTime.Now;
            TimeSpan diferenca = dataAtual.Subtract(DataDoChamado[numeroDosChamados]);
            chamados.ListaDoChamado[numeroDosChamados] = "Chamado " + numeroDosChamados + "\nTítulo: " + chamados.Titulo + "\nDescrição:" + chamados.Descricao + "\nData Inicial do Chamado: " + DataDoChamado[numeroDosChamados] + "\nTempo desde a abertura do chamado:" + diferenca.TotalDays + " dias." + "\nEquipamento: " + lista[chamados.Equipamento];
            Console.Clear();
            Console.WriteLine("Chamado Registrado!\nAperte ENTER para continuar:");
            Console.ReadLine();
        }

        private static void ExibirMenuEquipamentos()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Equipamentos - 2024");
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine("Digite qual opção deseja seguir:");
            Console.WriteLine("0- Registrar Equipamentos \n1- Visualizar Equipamentos do Inventário\n2-Editar Equipamento\n3-Excluir Equipamento Registrado");
            
        }
        private static void ExibirMenuChamados()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Equipamentos - 2024");
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine("Digite qual opção deseja seguir:");
            Console.WriteLine("4- Cadastrar Chamado \n5- Visualizar Chamados \n6-Editar Chamados\n7-Excluir Chamado Registrado");

        }
    }


}
