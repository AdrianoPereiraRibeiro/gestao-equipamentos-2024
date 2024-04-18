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
            SwitchPrincipal SwitchsDoSistema = new SwitchPrincipal();          
            while (sairDoSistema)
            {
                sairDoSistema = SwitchsDoSistema.SwitchInicial(sairDoSistema, menus); if (sairDoSistema==false) { continue; }
                SwitchsDoSistema.SwitchEquipamentosEchamados(ref lista, ref listaChamados, ref numeroDoEstoque, ref numeroDosChamados, DataDoChamado);
            }
        }     
    }
}
