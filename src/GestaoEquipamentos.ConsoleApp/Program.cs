using GestaoEquipamentos.ConsoleApp;
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
            while (sairDoSistema)
            {
                ExibirMenu();
                GerenciamentoEquipamento gerenciamento = new GerenciamentoEquipamento();
                GerenciamentoDeChamados gerenciamentoDeChamados = new GerenciamentoDeChamados();

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
                        listaChamados = gerenciamentoDeChamados.CadastrarChamados(listaChamados,numeroDosChamados,lista,numeroDoEstoque);
                        numeroDosChamados++;
                        break;
                    case 5:
                        if (numeroDosChamados == 0) { Console.WriteLine("Não exite nenhum chamado cadastrado!\nAperte ENTER para continuar:");Console.ReadLine(); }
                        else
                        {
                            for (int i = 0; i < numeroDosChamados; i++)
                                Console.WriteLine(listaChamados[i]);

                            Console.ReadLine();
                        }
                        break;
                    case 6:
                        listaChamados = gerenciamentoDeChamados.EditarChamados(listaChamados,lista,numeroDosChamados);
                        break;
                    case 7:
                        listaChamados = gerenciamentoDeChamados.RemoverChamado(listaChamados,numeroDosChamados);
                        break;
                    case 8:
                        sairDoSistema = false;
                        break;
                    default: Console.WriteLine("Essa opção não está disponivel!\nAperte ENTER para voltar ao MENU!");
                        Console.ReadLine();
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
            Console.Write("0- Registrar Equipamentos \n1- Visualizar Equipamentos do Inventário\n2-Editar Equipamento\n3-Excluir Equipamento Registrado\n4-Cadastrar Chamados");
            Console.WriteLine("\n5-Visualizar Chamados\n6-Editar Chamados\n7-Remover Chamados\n8-Sair");
        }
    }


}
public class GerenciamentoDeChamados()
{
    public string[] CadastrarChamados(string[] listaChamados, int numeroDosChamados, string[] lista,int numeroDoEstoque)
    {             
        Equipamento equipamento = new Equipamento();
        Chamados chamados = new Chamados();
       equipamento.numeroDoEstoque = numeroDoEstoque;
        if (equipamento.numeroDoEstoque == 0)
        {
            Console.WriteLine("Impossível Cadastrar Chamados!! Você não possui equipamentos cadastrados!");
            Console.WriteLine("Aperte ENTER para continuar:");
            Console.ReadLine ();
        }
        else
        {
            chamados.ListaDoChamado = listaChamados;
            chamados.numeroDoChamado = numeroDosChamados;
            equipamento.ListaDeEquipamento = lista;
            Console.WriteLine("CHAMADO " + chamados.numeroDoChamado);
            Console.WriteLine("Digite o Título do Chamado:");
            chamados.Titulo = Console.ReadLine();
            Console.WriteLine("Digite a Descrição do Chamado:");
            chamados.Descricao = Console.ReadLine();
            Console.WriteLine("Digite a Data do Chamado:");
            chamados.DataDoChamado = Console.ReadLine();
            Console.WriteLine("Digite o número do equipamento que o Chamado se refere:");
            chamados.Equipamento = Convert.ToInt32(Console.ReadLine());
            chamados.ListaDoChamado[numeroDosChamados] = "Chamado "+ numeroDosChamados+ "\nTítulo: " + chamados.Titulo + "\nDescrição:" + chamados.Descricao + "\nData Inicial do Chamado: " + chamados.DataDoChamado + "\nEquipamento: " + lista[chamados.Equipamento];
            Console.Clear();
            Console.WriteLine("Chamado Registrado!\nAperte ENTER para continuar:");
            Console.ReadLine();
        }
        return listaChamados;

    }
    public string[] EditarChamados(string[] listaChamados, string[] lista,int numeroChamados)
    {
        Chamados chamados = new Chamados();
        Equipamento equipamento = new Equipamento();       
        equipamento.ListaDeEquipamento = lista;
        chamados.ListaDoChamado=listaChamados;
        if (numeroChamados == 0) { Console.WriteLine("Não existe nenhum chamado!\nAperte ENTER para continuar:"); Console.ReadLine(); }
        else
        {
            Console.WriteLine("Digite o número do chamado a ser editado:");
            int numeroChamado = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o Título do Chamado:");
            chamados.Titulo = Console.ReadLine();
            Console.WriteLine("Digite a Descrição do Chamado:");
            chamados.Descricao = Console.ReadLine();
            Console.WriteLine("Digite o número do equipamento que o Chamado se refere:");
            chamados.Equipamento = Convert.ToInt32(Console.ReadLine());
            chamados.ListaDoChamado[numeroChamado] = "Chamado " + numeroChamado + "\nTítulo: " + chamados.Titulo + "\nDescrição:" + chamados.Descricao + "\nData Inicial do Chamado: " + chamados.DataDoChamado + "\nEquipamento: " + lista[chamados.Equipamento];
            Console.Clear();
            Console.WriteLine("Chamado Editado!\nAperte ENTER para continuar:");
            Console.ReadLine();
        }
        return chamados.ListaDoChamado;

    }
    public string[] RemoverChamado(string[] listaChamados,  int numeroChamados)
    {
        Chamados chamados = new Chamados();
        Equipamento equipamento = new Equipamento();   
        chamados.ListaDoChamado = listaChamados;
        if (numeroChamados == 0) { Console.WriteLine("Não existe nenhum chamado!"); Console.ReadLine(); }
        else
        {
            Console.WriteLine("Digite o número do chamado a ser removido");
            int numeroChamadoExclusao = Convert.ToInt32(Console.ReadLine());
            chamados.ListaDoChamado[numeroChamadoExclusao] = null;
            Console.WriteLine("Exclusão efetuada com sucesso!");
            Console.ReadLine();
        }
        return chamados.ListaDoChamado;
    }
}