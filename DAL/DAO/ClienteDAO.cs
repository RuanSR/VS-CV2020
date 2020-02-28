using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Model.Classes.ClienteModel;
using Model.Interface;

namespace DAL.DAO
{
    public class ClienteDAO : IClienteDAO, IDisposable
    {
        private CVContext _clienteContext;

        public ClienteDAO()
        {
            _clienteContext = new CVContext();
        }
        public void NovoCliente(Cliente c)
        {
            _clienteContext.Clientes.Add(c);
            _clienteContext.SaveChanges();
        }
        public void AtualizarCliente(Cliente c)
        {
            _clienteContext.Clientes.Update(c);
            _clienteContext.SaveChanges();
        }
        public void RemoverCliente(Cliente c)
        {
            _clienteContext.Clientes.Remove(c);
            _clienteContext.SaveChanges();
        }
        public IList<Cliente> ListaClientes()
        {
            return _clienteContext.Clientes
            .Include(nt => nt.NotaConta)
            .Include(nt => nt.NotaConta.RegistroNotas)
            .ToList();
        }
        public void Dispose()
        {
            _clienteContext.Dispose();
        }
    }
}