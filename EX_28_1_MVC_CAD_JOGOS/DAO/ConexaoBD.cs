﻿using Microsoft.Data.SqlClient;

namespace EX_28_1_MVC_CAD_JOGOS.DAO
{
    internal static class ConexaoBD
    {
        internal static SqlConnection GetConexao()
        {
            string strConexao = "Data Source=LOCALHOST;Initial Catalog=AULADB;user id=sa; password=123456;TrustServerCertificate=True";
            SqlConnection conexao = new SqlConnection(strConexao);
            conexao.Open();
            return conexao;
        }
    }
}
