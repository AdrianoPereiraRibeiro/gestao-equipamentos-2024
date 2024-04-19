using GestaoEquipamentos.ConsoleApp.ModuloEquipamentos;

public class RepositorioEquipamento
    { 
        public void CadastrarEquipamento(int numeroDoEstoque, Equipamento equipamento)
        {
          


            equipamento.ListaDeEquipamento[numeroDoEstoque] = "Produto " + equipamento.numeroDoEstoque + "\nNome:" + equipamento.nome + "\nPreço:" + equipamento.preco + "\nNumero de série:" + equipamento.numeroDeSerie + "\nData de fabricação:" + equipamento.DataDeFabricacao + "\nFabricante:" + equipamento.Fabricante + "\n-------------------------------------------------------------------------------";


            Console.Clear();
        }

        public void EditarEquipamento(Equipamento equipamento, int numeroProdutoEditado)
        {
            

            equipamento.ListaDeEquipamento[numeroProdutoEditado] = "Produto " + equipamento.numeroDoEstoque + "\nNome:" + equipamento.nome + "\nPreço:" + equipamento.preco + "\nNumero de série:" + equipamento.numeroDeSerie + "\nData de fabricação:" + equipamento.DataDeFabricacao + "\nFabricante:" + equipamento.Fabricante + "\n-------------------------------------------------------------------------------";
        }
    public void ExcluirEquipamento(string[] lista, int exclusao)
    {
        lista[exclusao] = null;      
    }


}