using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Sistema_de_cadastro_de_roupas
{
    class ConectaBanco
    {
        MySqlConnection banco = new MySqlConnection("server=localhost; user id = root; passsworld=; database=sistema de cadastro de roupas");
        public string mensagem;

        public bool inserirRoupa(Roupa roupa)
        {
            MySqlCommand command = new MySqlCommand("inserir", banco);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("nome", roupa.nome);
            command.Parameters.AddWithValue("categoria", roupa.categoria);
            command.Parameters.AddWithValue("tamanho", roupa.tamanho);
            command.Parameters.AddWithValue("cor", roupa.cor);
            command.Parameters.AddWithValue("preco", roupa.preco);
            command.Parameters.AddWithValue("quantidade", roupa.quantidade);
            try
            {
                banco.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException exception)
            {
                mensagem = "erro:" + exception.Message;
                return false;

            }
            finally
            {
                banco.Close();
            }

        }
        public DataTable busca()
        {
            MySqlCommand command = new MySqlCommand("selecao", banco);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                banco.Open();
                MySqlDataAdapter adaptador = new MySqlDataAdapter(command);
                DataTable tabela = new DataTable();
                adaptador.Fill(tabela);
                return tabela;
            }
            catch (MySqlException exception)
            {
                mensagem = "erro:" + exception.Message;
                return null;
            }
            finally
            {
                banco.Close();
            }
        }
        public DataTable buscaNome(string nome)
        {
            MySqlCommand command = new MySqlCommand("busca", banco);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("nome", nome);
            try
            {
                banco.Open();
                MySqlDataAdapter adaptador = new MySqlDataAdapter(command);
                DataTable tabela = new DataTable();
                adaptador.Fill(tabela);
                return tabela;
            }
            catch (MySqlException exception)
            {
                mensagem = "erro:" + exception.Message;
                return null;
            }
            finally
            {
                banco.Close();
            }

            }
        public bool atualiza(Roupa roupa)
        {
            MySqlCommand command = new MySqlCommand("alteracao", banco);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("codRoupas", roupa.codRoupas);
            command.Parameters.AddWithValue("nome", roupa.nome);
            command.Parameters.AddWithValue("categoria", roupa.categoria);
            command.Parameters.AddWithValue("tamanho", roupa.categoria);
            command.Parameters.AddWithValue("cor", roupa.cor);
            command.Parameters.AddWithValue("preco", roupa.preco);
            command.Parameters.AddWithValue("quantidade", roupa.quantidade);
            try
            {
                banco.Open();
                command.ExecuteNonQuery();
                return true;

            }
            catch(MySqlException exception)
            {
                mensagem = "erro: " + exception.Message;
                return false;

                
            }
            finally
            {
                banco.Close();
            }
        }

        }
    }

