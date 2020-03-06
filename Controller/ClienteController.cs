using System;
using System.Collections.Generic;
using Model.Classes.ClienteModel;
using Model.Interface;
using DAL.DAO;
using Model.Exceptions;

namespace Controller
{
    public class ClienteController : IClienteDAO
    {
        public void NovoCliente(Cliente c)
        {
            try
            {
                ValidaCliente(c);
                using (var cContext = new ClienteDAO())
                {
                    cContext.NovoCliente(c);
                }
            }
            catch (ClienteException e)
            {
                throw e;
            }
        }
        public void AtualizarCliente(Cliente c)
        {
            try
            {
                ValidaCliente(c);
                using (var cContext = new ClienteDAO())
                {
                    cContext.AtualizarCliente(c);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void RemoverCliente(Cliente c)
        {
            try
            {
                ValidaCliente(c);
                using (var cContext = new ClienteDAO())
                {
                    cContext.RemoverCliente(c);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public IList<Cliente> ListaClientes()
        {
            try
            {
                using (var cContext = new ClienteDAO())
                {
                    return cContext.ListaClientes();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public IList<Cliente> ListaClienteWithRegistros()
        {
            try
            {
                using (var cContext = new ClienteDAO())
                {
                    return cContext.ListaClienteWithRegistros();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private void ValidaCliente(Cliente c)
        {
            //APLICA REGRAS\\
            /*
             * Nome precisa ter no minimo 7 caracteres.
             * Apelido no minimo 3 caracteres
             * Endereço no minimo 10 caracteres
             * Telefone precisa ser preenchido
             */
            if(c.Nome.Length <= 7)
            {
                Console.WriteLine(c.Nome);
                throw new ClienteException("Preencha o nome completo do cliente.");
            }
            if (c.Apelido.Length <= 2)
            {
                throw new ClienteException("Apelido precisa no minimo 3 caracteres.");
            }
            if (c.Endereco.Length <= 9)
            {
                throw new ClienteException("Endereço precisa no mínimo 10 caracteres.");
            }
            if (c.Telefone.Length <= 8)
            {
                throw new ClienteException("Preencha seu número de telefone com um número válido.");
            }
        }
    }
}
