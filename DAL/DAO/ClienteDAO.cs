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
            try
            {
                _clienteContext = new CVContext();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void NovoCliente(Cliente c)
        {
            try
            {
                _clienteContext.Clientes.Add(c);
                _clienteContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao salvar cliente. {e.Message}");
            }
        }
        public void AtualizarCliente(Cliente c)
        {
            try
            {
                _clienteContext.Clientes.Update(c);
                _clienteContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao atulizar dados do cliente. {e.Message}");
            }
        }
        public void RemoverCliente(Cliente c)
        {
            try
            {
                _clienteContext.Clientes.Remove(c);
                _clienteContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao remover cliente. {e.Message}");
            }
        }
        public void DeletarRegistro(Cliente c)
        {
            try
            {
                _clienteContext.RegistroNotas.RemoveRange(c.NotaConta.RegistroNotas);
                _clienteContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao deletar registros do cliente. {e.Message}");
            }
        }
        public IList<Cliente> ListaClientes()
        {
            try
            {
                return _clienteContext.Clientes
                    .Include(nt => nt.NotaConta)
                    .ToList();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao obter lista de clientes. {e.Message}");
            }
        }
        public IList<Cliente> ListaClienteWithRegistros()
        {
            try
            {
                return _clienteContext.Clientes
                    .Include(nt => nt.NotaConta)
                    .Include(nt => nt.NotaConta.RegistroNotas)
                    .ToList();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao obter cliente. {e.Message}");
            }
        }
        public void Dispose()
        {
            _clienteContext.Dispose();
        }
    }
}