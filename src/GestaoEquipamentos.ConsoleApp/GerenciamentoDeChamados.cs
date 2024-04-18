using GestaoEquipamentos.ConsoleApp;

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