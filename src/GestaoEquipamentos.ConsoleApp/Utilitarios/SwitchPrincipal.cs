using GestaoEquipamentos.ConsoleApp.ModuloEquipamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoEquipamentos.ConsoleApp.ModuloChamados;
using static GestaoEquipamentos.ConsoleApp.Program;

namespace GestaoEquipamentos.ConsoleApp.Utilitarios
{
    internal class SwitchPrincipal
    {
        public  void SwitchEquipamentosEchamados(ref string[] lista, ref string[] listaChamados, ref int numeroDoEstoque, ref int numeroDosChamados, DateTime[] DataDoChamado)
        {
            GerenciamentoEquipamento gerenciamento = new GerenciamentoEquipamento();
            GerenciamentoDeChamados gerenciamentoDeChamados = new GerenciamentoDeChamados();
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 0: lista = gerenciamento.CadastrarEquipamento(lista, numeroDoEstoque); numeroDoEstoque++; break;
                case 1: for (int i = 0; i < numeroDoEstoque; i++) Console.WriteLine(lista[i]); Console.ReadLine(); break;
                case 2: lista = gerenciamento.EditarEquipamentos(lista); break;
                case 3: lista = gerenciamento.ExcluirEquipamentos(lista); break;
                case 4: gerenciamentoDeChamados.IfCadastrarChamado(lista, listaChamados, numeroDoEstoque, numeroDosChamados, DataDoChamado); numeroDosChamados++; break;
                case 5: gerenciamentoDeChamados.MostrarChamados(listaChamados, numeroDosChamados); break;
                case 6: listaChamados = gerenciamentoDeChamados.EditarChamados(listaChamados, lista, numeroDosChamados, DataDoChamado); break;
                case 7: listaChamados = gerenciamentoDeChamados.RemoverChamado(listaChamados, numeroDosChamados); break;
                default: gerenciamentoDeChamados.OpcaoIndisponivel(); break;
            }
           
            }
        public bool SwitchInicial(bool sairDoSistema, Menus menus)
        {
            bool sairDoWhile = sairDoSistema;
            while (sairDoWhile)
            {
                menus.MenuInicial();
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 0: menus.ExibirMenuEquipamentos(); sairDoWhile = false; break;
                    case 1: menus.ExibirMenuChamados(); sairDoWhile = false; break;
                    case 2: sairDoSistema = false; sairDoWhile = false; break;
                    default: Console.WriteLine("Opção Indisponível!"); Console.ReadLine(); break;
                }
            }
            return sairDoSistema;
        }
   
    }
}
