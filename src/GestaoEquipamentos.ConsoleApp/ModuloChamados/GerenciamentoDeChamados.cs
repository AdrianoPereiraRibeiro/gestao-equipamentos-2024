namespace GestaoEquipamentos.ConsoleApp.ModuloChamados;
using GestaoEquipamentos.ConsoleApp.ModuloEquipamentos;

public partial class GerenciamentoDeChamados()
{
   
    public string[] EditarChamados(string[] listaChamados, string[] lista,int numeroChamados, DateTime[] DataDosChamados)
    {   RepositorioChamados repositorio = new RepositorioChamados();
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
            repositorio.EditarChamado(lista, chamados, numeroChamado);
            Console.Clear();
            Console.WriteLine("Chamado Editado!\nAperte ENTER para continuar:");
            Console.ReadLine();

        }
        return chamados.ListaDoChamado;

    }

    

    public string[] RemoverChamado(string[] listaChamados,  int numeroChamados)
    {   RepositorioChamados repositorio = new RepositorioChamados();
        Chamados chamados = new Chamados();
        Equipamento equipamento = new Equipamento();   
        chamados.ListaDoChamado = listaChamados;
        if (numeroChamados == 0) { Console.WriteLine("Não existe nenhum chamado!"); Console.ReadLine(); }
        else
        {
            Console.WriteLine("Digite o número do chamado a ser removido");
            int numeroChamadoExclusao = Convert.ToInt32(Console.ReadLine());
            repositorio.ExcluirChamado(chamados, numeroChamadoExclusao);
            Console.WriteLine("Exclusão efetuada com sucesso!");
            Console.ReadLine();
        }
        return chamados.ListaDoChamado;
    }

   

    public  void MostrarChamados(string[] listaChamados, int numeroDosChamados)
    {
        if (numeroDosChamados == 0) { Console.WriteLine("Não exite nenhum chamado cadastrado!\nAperte ENTER para continuar:"); Console.ReadLine(); }
        else
        {
            for (int i = 0; i < numeroDosChamados; i++)
                Console.WriteLine(listaChamados[i]);

            Console.ReadLine();
        }
    }

    public  void IfCadastrarChamado(string[] lista, string[] listaChamados, int numeroDoEstoque, int numeroDosChamados, DateTime[] DataDoChamado)
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

    public  void OpcaoIndisponivel()
    {
        Console.WriteLine("Essa opção não está disponivel!\nAperte ENTER para voltar ao MENU!");
        Console.ReadLine();
    }

    public  void ErroEmCadastrarChamado()
    {
        Console.WriteLine("Impossível Cadastrar Chamados!! Você não possui equipamentos cadastrados!");
        Console.WriteLine("Aperte ENTER para continuar:");
        Console.ReadLine();
    }

    public  void CadastrarNovoChamado(string[] lista, string[] listaChamados, int numeroDosChamados, DateTime[] DataDoChamado, Equipamento equipamento, Chamados chamados)
    {
        chamados.ListaDoChamado = listaChamados;
        chamados.numeroDoChamado = numeroDosChamados;
        RepositorioChamados repositorio = new RepositorioChamados();
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
        repositorio.CadastrarNovoChamado(lista, numeroDosChamados, DataDoChamado, chamados);
        Console.Clear();
        Console.WriteLine("Chamado Registrado!\nAperte ENTER para continuar:");
        Console.ReadLine();
    }
}