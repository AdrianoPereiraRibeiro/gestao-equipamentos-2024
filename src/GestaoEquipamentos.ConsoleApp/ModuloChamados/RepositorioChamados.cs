namespace GestaoEquipamentos.ConsoleApp.ModuloChamados;
public partial class GerenciamentoDeChamados
{
    public class RepositorioChamados
    {
        public void ExcluirChamado(Chamados chamados, int numeroChamadoExclusao)
        {
            chamados.ListaDoChamado[numeroChamadoExclusao] = null;
        }
        public void CadastrarNovoChamado(string[] lista, int numeroDosChamados, DateTime[] DataDoChamado, Chamados chamados)
        {
            DateTime dataAtual = DateTime.Now;
            TimeSpan diferenca = dataAtual.Subtract(DataDoChamado[numeroDosChamados]);
            chamados.ListaDoChamado[numeroDosChamados] = "Chamado " + numeroDosChamados + "\nTítulo: " + chamados.Titulo + "\nDescrição:" + chamados.Descricao + "\nData Inicial do Chamado: " + DataDoChamado[numeroDosChamados] + "\nTempo desde a abertura do chamado:" + diferenca.TotalDays + " dias." + "\nEquipamento: " + lista[chamados.Equipamento];
        }
        public void EditarChamado(string[] lista, Chamados chamados, int numeroChamado)
        {
            DateTime dataAtual = DateTime.Now;
            TimeSpan diferenca = dataAtual.Subtract(chamados.DataDoChamado[numeroChamado]);
            chamados.ListaDoChamado[numeroChamado] = "Chamado " + numeroChamado + "\nTítulo: " + chamados.Titulo + "\nDescrição:" + chamados.Descricao + "\nData Inicial do Chamado: " + chamados.DataDoChamado[numeroChamado] + "\nTempo desde a abertura do chamado:" + diferenca.TotalDays + " dias." + "\nEquipamento: " + lista[chamados.Equipamento];
        }
    }
}