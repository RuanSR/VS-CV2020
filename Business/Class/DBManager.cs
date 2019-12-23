﻿using System;
using System.Data;
using DAL.Class;

namespace Business.Class
{
    public sealed class DBManager : IDB
    {

        private DB DB { get; set; }
        public DBManager()
        {
            DB = new DB();
        }
        public DataTable GetData()
        {
            try
            {
                return DB.GetData();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable GetAdmin(string usuario, string senha)
        {
            try
            {
                return DB.GetAdmin(usuario, senha);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void NovoCliente(string nome, string apelido, string endereco, string telefone, string cpf, double limiteConta, double totalConta, double totalPago, int numNotas, string dataConta, bool status)
        {
            try
            {
                DB.NovoCliente(nome, apelido, endereco, telefone, cpf, limiteConta, totalConta, totalPago, numNotas, dataConta, status);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AtualizaCliente(int id, string nome, string apelido, string endereco, string telefone, string cpf, double limiteConta, double totalConta, double totalPago, int numNotas, string dataConta, bool status)
        {
            try
            {
                DB.AtualizaCliente(id, nome, apelido, endereco, telefone, cpf, limiteConta, totalConta, totalPago, numNotas, dataConta, status);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetRegistro(int id)
        {
            return null;
        }
    }
}
