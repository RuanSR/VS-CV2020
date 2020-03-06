using System;
using Controller;
using Model.Classes;
using Model.Classes.ClienteModel;
using Model.Enum;
using Model.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        static ClienteController _cController = new ClienteController();
        static AtendenteController _aController = new AtendenteController();
        static void Main(string[] args)
        {
            try
            {
                LerEGravarClientes();
                GravaRegistroCliente();
                // LogarAtendente("Ruan", "");
                // NovoAtendente(new Atendente("Renan da Silva Rosa", "R", "0", NivelAcesso.ADMIN));
                // NovoCliente(new Cliente("Ruan da Silva Rosa", "", "Pass Virgem da Conceiçao", "000000000", "", 100.00));

                //var c = CarregaUmCliente();
                // c = Operacao.AdicionarValor(c, 10.00, "Ruan", "Emprestimo");
                // c.NotaConta.AtualizarNota(20000.00, c.NotaConta.TotalConta, c.NotaConta.DataConta);
                //c.AtualizarCliente("Ruan da Silva Rosa", c.Apelido, "Pass Virgem da Conceição n82", c.Telefone, c.Cpf);
                //for (int i = 0; i < 9999; i++)
                //{
                //    c = Operacao.AdicionarValor(c, .10, "Ruan", "Emprestimo");
                //}
                //AtualizaCliente(c);
                // c = Operacao.DebitarValor(c, 40.00, "Ruan", "Pagando uma parte do Emprestimo");
                // ListarClientes();
                //AtualizaCliente(c);
                //ListarCliente(c);
                // DeleteaCliente(c);
                //ListarClientes();


            }
            catch (ClienteException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Erro: " + e.Message);
            }
        }
        static void LerEGravarClientes()
        {
            try
            {
                var listaClientes = new List<Cliente>();
                var caminho = @"C:\CV2020-CSV\clientes.csv";
                var lines = File.ReadAllLines(caminho);
                foreach (var linha in lines)
                {
                    var c = linha.Split(";");
                    var novocliente = new Cliente(c[1], c[2], c[3], c[4], c[5], double.Parse(c[6]));
                    novocliente.NotaConta.AtualizarNota(double.Parse(c[6]), double.Parse(c[7]), c[10]);
                    listaClientes.Add(novocliente);
                    Console.WriteLine($"GRAVANDO CLIENTE {novocliente.Nome}");
                    NovoCliente(novocliente);
                }

                foreach (var item in listaClientes)
                {
                    Console.WriteLine(item.ToString());
                    Console.WriteLine(item.NotaConta.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERRO: " + e.Message);
            }
        }

        static void LerEGravarRegistro(Cliente c)
        {
            try
            {
                var listaRegistro = new List<RegistroNota>();
                var caminho = @"C:\CV2020-CSV\registros.csv";
                var lines = File.ReadAllLines(caminho);
                var numNotasGravadas = 0;
                foreach (var linha in lines)
                {
                    var r = linha.Split(";");
                    if (c.ClienteId.ToString() == r[6])
                    {
                        if (r[4] == "-")
                        {
                            var novoRegistro = new RegistroNota(DateTime.Parse(r[1] + " " + r[2]), r[3], 0.0, r[5]);
                            c.NotaConta.RegistroNotas.Add(novoRegistro);
                            //listaRegistro.Add(novoRegistro);
                        }
                        else
                        {
                            var novoRegistro = new RegistroNota(DateTime.Parse(r[1] + " " + r[2]), r[3], double.Parse(r[4]), r[5]);
                            c.NotaConta.RegistroNotas.Add(novoRegistro);
                            //listaRegistro.Add(novoRegistro);
                        }
                        numNotasGravadas++;
                    }
                }
                Console.WriteLine($"ATUALIZANDO CLIENTE {c.Nome}...");
                Console.WriteLine($"NUMERO DE REGISTROS: {numNotasGravadas}");
                AtualizaCliente(c);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERRO: " + e.Message);
            }
        }
        static IList<Cliente> CarregaClientes()
        {
            try
            {
                return _cController.ListaClientes();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        static void ListarCliente(Cliente c)
        {
            Console.WriteLine("===========CLIENTE=============");
            Console.WriteLine(c.ToString());
            Console.WriteLine(c.NotaConta.ToString());
            Console.WriteLine("===========REGISTRO=============");
            foreach (var nota in c.NotaConta.RegistroNotas)
            {
                Console.WriteLine(nota.ToString());
            }
        }
        static void ListarClientes()
        {
            foreach (var c in CarregaClientes())
            {
                var consoleColorDefault = Console.ForegroundColor;
                Console.WriteLine("===========CLIENTE=============");
                Console.WriteLine(c.ToString());
                Console.WriteLine(c.NotaConta.ToString());
                Console.WriteLine("===========REGISTRO=============");
                foreach (var nota in c.NotaConta.RegistroNotas)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(nota.ToString());
                    Console.ForegroundColor = consoleColorDefault;
                }
            }
        }
        static void GravaRegistroCliente()
        {
            foreach (var c in CarregaClientes())
            {
                LerEGravarRegistro(c);
            }
        }
        static Cliente CarregaUmCliente()
        {
            try
            {
                var c = CarregaClientes()
                    .FirstOrDefault();
                return c;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        static void NovoCliente(Cliente c)
        {
            try
            {
                _cController.NovoCliente(c);
            }
            catch (ClienteException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void AtualizaCliente(Cliente c)
        {
            try
            {
                _cController.AtualizarCliente(c);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        static void DeleteaCliente(Cliente c)
        {
            try
            {
                _cController.RemoverCliente(c);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        static void LogarAtendente(string usuario, string senha)
        {
            var at = GetAtendenteByUserName(usuario, senha);

            if(at != null)
            {
                ListarAtendente(at);
            }
            else
            {
                Console.WriteLine("INFO: Usuario ou Senha incoretos!");
            }
        }

        static IList<Atendente> CarregaAtendentes()
        {
            try
            {
                return _aController.ListaAtendentes();
            }
            catch (AtendenteException e)
            {
                Console.WriteLine($"INFO: {e.Message}");
                throw;
            }
        }
        static Atendente GetAtendenteByUserName(string nome, string senha)
        {
            try
            {
                return _aController
                    .ListaAtendentes()
                    .Where(atnte => atnte.Usuario == nome && atnte.Senha == senha)
                    .FirstOrDefault();
            }
            catch (AtendenteException e)
            {
                Console.WriteLine($"INFO: {e.Message}");
                throw;
            }
        }
        static void NovoAtendente(Atendente atendente)
        {
            try
            {
                var atendenteController = new AtendenteController();
                atendenteController.NovoAtendente(atendente);
            }
            catch (AtendenteException e)
            {
                Console.WriteLine($"INFO: {e.Message}");
            }
        }
        static void AtualizarAtendente(Atendente atendente)
        {
            try
            {
                _aController.NovoAtendente(atendente);
            }
            catch (AtendenteException e)
            {
                Console.WriteLine($"INFO: {e.Message}");
            }
        }
        static void RemoverAtendente(Atendente atendente)
        {
            try
            {
                _aController.RevomerAtendente(atendente);
            }
            catch (AtendenteException e)
            {
                Console.WriteLine($"INFO: {e.Message}");
            }
        }

        static void ListarAtendente(Atendente atendente)
        {
            Console.WriteLine("===========ATENDENTE=============");
            Console.WriteLine(atendente.ToString());
        }
    }
}
