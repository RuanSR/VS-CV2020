using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models.Classes;
using Models.Interface;

namespace DAL.Database
{
    public class ClienteRepository : IClienteRepository
    {
        private CVContext _clienteContext;

        public ClienteRepository()
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
        public async Task NovoClienteAsync(Cliente c)
        {
            try
            {
                _clienteContext.Clientes.Add(c);
                await _clienteContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao salvar cliente. {e.Message}");
            }
        }
        public async Task AtualizarClienteAsync(Cliente c)
        {
            try
            {
                _clienteContext.Clientes.Update(c);
                await _clienteContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao atulizar dados do cliente. {e.Message}");
            }
        }
        public async Task RemoverClienteAsync(Cliente c)
        {
            try
            {
                _clienteContext.Clientes.Remove(c);
                await _clienteContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao remover cliente. {e.Message}");
            }
        }
        public async Task DeletarRegistroAsync(Cliente c)
        {
            try
            {
                _clienteContext.RegistroNotas.RemoveRange(c.NotaConta.RegistroNotas);
                await _clienteContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao deletar registros do cliente. {e.Message}");
            }
        }
        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            var listClientes = await ListaClientesAsync();
            return listClientes
                .Where(c => c.ClienteId == id)
                .FirstOrDefault();
        }
        public async Task<Cliente> GetClienteByIdWithRegistrosAsync(int id)
        {
            var listClientes = await ListaClienteWithRegistrosAsync();
            return listClientes
                .Where(c => c.ClienteId == id)
                .FirstOrDefault();
        }
        public async Task<IList<Cliente>> ListaClientesAsync()
        {
            try
            {
                return await _clienteContext.Clientes
                    .Include(nt => nt.NotaConta)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao obter lista de clientes. {e.Message}");
            }
        }
        public async Task<IList<Cliente>> ListaClienteWithRegistrosAsync()
        {
            try
            {
                return await _clienteContext.Clientes
                    .Include(nt => nt.NotaConta)
                    .Include(nt => nt.NotaConta.RegistroNotas)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao obter cliente. {e.Message}");
            }
        }
    }
}