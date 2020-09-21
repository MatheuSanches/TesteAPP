using System;
using System.IO;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using testeMOB.Android;
using SQLite;

namespace testeMOB
{
    public class AcessoDB : IDisposable
    {
        private SQLiteConnection conexaoSQLite;
        public AcessoDB()
        {
            var config = DependencyService.Get<IConfig>();
            //conexaoSQLite = new SQLiteConnection(Path.Combine(config.DiretorioSQLite, "Cadastro.db3"));
            var diretorioSQLite = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            conexaoSQLite = new SQLiteConnection(Path.Combine(diretorioSQLite, "Cadastro.db3"));
            conexaoSQLite.CreateTable<Cliente>();
            conexaoSQLite.CreateTable<Produto>();
        }
        //TESTEEEEEEEEEEEEEEEEEEEE



        public string AddUser(Cliente user)
        {
            var data = conexaoSQLite.Table<Cliente>();
            var d1 = data.Where(x => x.Nome == user.Nome && x.Usuario == user.Usuario).FirstOrDefault();
            if (d1 == null)
            {
                conexaoSQLite.Insert(user);
                return "Sucessfully Added";
            }
            else
            {
                return "Already Mail id Exist";
            }
        }


        public bool updateUserValidation(string userid)
        {
            var data = conexaoSQLite.Table<Cliente>();
            var d1 = (from values in data
                      where values.Nome == userid
                      select values).Single();
            if (d1 != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool updateUser(string username, string pwd)
        {
            var data = conexaoSQLite.Table<Cliente>();
            var d1 = (from values in data
                      where values.Senha == username
                      select values).Single();
            if (true)
            {
                d1.Senha = pwd;
                conexaoSQLite.Update(d1);
                return true;
            }
            else
            {
                
            }
        }

        public bool LoginValidate(string usuario, string senha)
        {
            var data = conexaoSQLite.Table<Cliente>();
            var d1 = data.Where(x => x.Usuario == usuario && x.Senha == senha).FirstOrDefault();
            if (d1 != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }





        //TESTEEEEEEEEEEEEEEEEEEEE
        public void InserirCliente(Cliente cliente)// Inclui um Cliente no banco de dados
        {
            conexaoSQLite.Insert(cliente);
        }
        public void AtualizarCliente(Cliente cliente)// Atualiza um Cliente
        {
            conexaoSQLite.Update(cliente);
        }
        public void DeletarCliente(Cliente cliente)// Exclui um Cliente do banco de dados
        {
            conexaoSQLite.Delete(cliente);
        }
        public Cliente GetCliente(int codigo)// Obtém um cliente pelo seu código
        {
            return conexaoSQLite.Table<Cliente>().FirstOrDefault(c => c.Id == codigo);
        }
        public List<Cliente> GetClientes()// Retorna todos os clientes ordenados pelo nome
        {
            return conexaoSQLite.Table<Cliente>().OrderBy(c => c.Nome).ToList();
        }

        public void InserirProduto(Produto prod)// Inclui um produto no banco de dados
        {
            conexaoSQLite.Insert(prod);
        }
        public void AtualizarProduto(Produto prod)// Atualiza um produto
        {
            conexaoSQLite.Update(prod);
        }
        public void DeletarProduto(Produto prod)// Exclui um produto do banco de dados
        {
            conexaoSQLite.Delete(prod);
        }
        public Produto GetProd(int codigo)// Obtém um produto pelo seu código
        {
            return conexaoSQLite.Table<Produto>().FirstOrDefault(c => c.Id == codigo);
        }
        public List<Produto> GetProd()// Retorna todos os produtos ordenados pelo nome
        {
            return conexaoSQLite.Table<Produto>().OrderBy(c => c.Nome).ToList();
        }

        public void Dispose()// Libera os recursos usados (Como se fechasse a conexão)
        {
            conexaoSQLite.Dispose();
        }
    }
}
