﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStation.Libs
{
    class Estado
    {
        public int codigo, codigo_pais;
        public string uf, nome;

        public override string ToString()
        {
            return nome;
        }

        public static int getIdByName(string nome, SqlConnection conn)
        {
            string sql = "SELECT codigo FROM tb_estados WHERE nome = @nome";
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@nome", nome);

            try {
                int codigo = Convert.ToInt32(command.ExecuteScalar());

                return codigo;
            } catch {
                return -1;
            }
        }

        public static string getNameById(int codigo, SqlConnection conn)
        {
            string sql = "SELECT nome FROM tb_estados WHERE codigo = @codigo";
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@codigo", codigo);

            try {
                string descricao = command.ExecuteScalar().ToString();

                return descricao;
            } catch {
                return String.Empty;
            }
        }
    }
}
