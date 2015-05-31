using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web;
using System.Security.Principal;
using System.Diagnostics;

namespace IP_nome
{
    class Program
    {        
        static void Main(string[] args)
        {
            Console.Title = "Ip CTG Aplicação Powered By: Marcus Vinicius - ConnectDev";
            string _nomeMaquina = "";
            WindowsIdentity usu_Windows = WindowsIdentity.GetCurrent();
            
            _nomeMaquina = Dns.GetHostName();         
            Console.WriteLine("Nome da maquina: "+_nomeMaquina);
            Console.WriteLine("Nome do usuário utilizando esta maquina: "+usu_Windows.Name);
            Console.WriteLine("O usuário é System? " + usu_Windows.IsSystem);
            Console.WriteLine("O usuário é Convidado? " + usu_Windows.IsGuest);
            Console.WriteLine("O usuário é Anonimo? " + usu_Windows.IsAnonymous);            
            Console.WriteLine("Qual e o nivel do usuário? " + usu_Windows.ImpersonationLevel);
            Console.WriteLine("Tipo de autencicação: " + usu_Windows.AuthenticationType);
            Console.WriteLine("Token: " + usu_Windows.Token);
            Console.WriteLine("----------------------------------------------------------");
            try
            {
                System.Net.WebClient t = new System.Net.WebClient();
                string meuip = t.DownloadString("http://meuip.datahouse.com.br");
                Console.Write("Ip externo: ");
                Console.WriteLine(meuip.Substring(meuip.IndexOf("o Meu IP? ") + "o Meu IP? ".Length, meuip.IndexOf("</title>") - meuip.IndexOf("o Meu IP? ") - "o Meu IP? ".Length));
            }
            catch(Exception ex)
            {
                Console.WriteLine("IP externo: Não foi possivel indentificar o IP Externo pelo sequinte motivo:"+ex.Message);
            }
            try
            {
                IPHostEntry ipEntry = Dns.GetHostByName(_nomeMaquina);
                IPAddress[] addr = ipEntry.AddressList;

                String strIP = String.Empty;
                for (int i = 0; i < addr.Length; i++)
                {
                    strIP = strIP + addr[i].ToString() + "\n";
                }
                Console.WriteLine("IPs usados pela maquina:\n" + strIP);
            }
            catch(Exception ex1)
            {
                Console.WriteLine("Não foi possivel indentificar os IPs usados pela máquina peno sequinte motivo:"+ex1);
            }

            Console.WriteLine("Aplicação Powered By: Marcus Vinicius - ConnectDev");
            Console.WriteLine("\n\nVisite nosso site: www.conectdev.com.br");
            Console.Write("\nIr para o site (Digite 'S' para sim ou 'N' para sair): ");

            if (Console.ReadLine().ToUpper() == "S")
            {
                ProcessStartInfo sInfo = new ProcessStartInfo("www.conectdev.com.br");
                Process.Start(sInfo);
            }
            else
            {
                Console.WriteLine("Ok, te vejo em breve!");
                Console.ReadKey();
            }
        }
    }
}
