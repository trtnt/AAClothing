﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AAClothing.DAL
{
    public abstract class SQLBase
    {
        private readonly string _connectionString;
        
        //Connectionstring in constructor kan opgroepen worden in elke functie en in andere klasses
        public SQLBase()
        {
            _connectionString = "Server=DESKTOP-JA9OFG0\\SQLEXPRESS;Database=AAClothing;Trusted_Connection=True;";
        }


        public DataSet ExecuteSql(string sql, List<KeyValuePair<string, string>> parameters)
        {
            DataSet data = new DataSet();
            try
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = connection.CreateCommand();

                command.Parameters.AddRange(GetParameters(parameters));
                command.CommandText = sql;

                adapter.SelectCommand = command;

                connection.Open();
                adapter.Fill(data);
                connection.Close();

                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ExecuteInsert(string sql, List<KeyValuePair<string, string>> parameters)
        {
            try
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                SqlCommand command = connection.CreateCommand();

                command.Parameters.AddRange(GetParameters(parameters));
                command.CommandText = sql;

                connection.Open();
                int id = (int)command.ExecuteScalar();
                connection.Close();

                return id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //SQL parameter recycle functie
        private SqlParameter[] GetParameters(List<KeyValuePair<string, string>> parameters)
        {
            SqlParameter[] returnVal = new SqlParameter[parameters.Count];
            foreach (KeyValuePair<string, string> keyvp in parameters)
            {
                SqlParameter param = new SqlParameter
                {
                    ParameterName = keyvp.Key,
                    Value = keyvp.Value
                };
                returnVal[parameters.IndexOf(keyvp)] = param;
            }
            return returnVal;
        }

        
    }
}
