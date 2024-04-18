using GestaoEquipamentos.ConsoleApp.ModuloEquipamentos;
using Microsoft.Win32.SafeHandles;
using System.Diagnostics;
using GestaoEquipamentos.ConsoleApp.Utilitarios;
using static GestaoEquipamentos.ConsoleApp.Program;

namespace GestaoEquipamentos.ConsoleApp
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            string[] lista = new string[100];
            string[] listaChamados = new string[100];
            int numeroDoEstoque = 0;
            int numeroDosChamados = 0;
            bool sairDoSistema = true;
            DateTime[] DataDoChamado = new DateTime[100];
            Menus menus = new Menus();
            SwitchPrincipal switchPrincipal = new SwitchPrincipal();
            
            while (sairDoSistema)
            {
                sairDoSistema = SwitchInicial(sairDoSistema, menus); if (sairDoSistema==false) { continue; }
                switchPrincipal.SwitchEquipamentosEchamados(ref lista, ref listaChamados, ref numeroDoEstoque, ref numeroDosChamados, DataDoChamado);
            }
        }

        private static bool SwitchInicial(bool sairDoSistema, Menus menus)
        {
            bool sairDoWhile = sairDoSistema;
            while (sairDoWhile)
            {
                menus.MenuInicial();
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 0: menus.ExibirMenuEquipamentos(); sairDoWhile = false; break;
                    case 1: menus.ExibirMenuChamados(); sairDoWhile =false; break;
                    case 2: sairDoSistema = false; sairDoWhile = false; break;
                    default: Console.WriteLine("Opção Indisponível!"); Console.ReadLine(); break;
                }
            }
            return sairDoSistema;
        }





    }


}
