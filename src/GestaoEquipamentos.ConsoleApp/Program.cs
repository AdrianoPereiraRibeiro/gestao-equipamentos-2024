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
            DateTime[] DataDoChamado = new DateTime[100];
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
                        Equipamento equipamento = new Equipamento();
                        Chamados chamados = new Chamados();
                        if (numeroDoEstoque == 0)
                        {
                            Console.WriteLine("Impossível Cadastrar Chamados!! Você não possui equipamentos cadastrados!");
                            Console.WriteLine("Aperte ENTER para continuar:");
                            Console.ReadLine();
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
                        listaChamados = gerenciamentoDeChamados.EditarChamados(listaChamados,lista,numeroDosChamados,DataDoChamado);
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
   
    public string[] EditarChamados(string[] listaChamados, string[] lista,int numeroChamados, DateTime[] DataDosChamados)
    {
        Chamados chamados = new Chamados();
        Equipamento equipamento = new Equipamento();       
        equipamento.ListaDeEquipamento = lista;
        chamados.ListaDoChamado=listaChamados;
        chamados.DataDoChamado = DataDosChamados;
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
            DateTime dataAtual = DateTime.Now;
            TimeSpan diferenca = dataAtual.Subtract(chamados.DataDoChamado[numeroChamado]);           
            chamados.ListaDoChamado[numeroChamado] = "Chamado " + numeroChamado + "\nTítulo: " + chamados.Titulo + "\nDescrição:" + chamados.Descricao + "\nData Inicial do Chamado: " + chamados.DataDoChamado[numeroChamado] +"\nTempo desde a abertura do chamado:"+diferenca.TotalDays+" dias."+ "\nEquipamento: " + lista[chamados.Equipamento];
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