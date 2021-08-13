
using demo.Common;
using Microsoft.Extensions.Logging;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo_v2.App_Start
{
    public class SqlsugarSetup
    {
        private static string ConnectionString = Appsettings.app(new string[] { "MySql", "ConnectionString" });
        public static SqlSugarClient InitDB(ILogger<SqlsugarSetup> _logger)
        {
            var db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = ConnectionString,
                DbType = DbType.MySql,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.SystemTable,
                
            });
            //db.Aop.OnLogExecuted = (sql, p) => //SQL执行完
            //{
            //    _logger.LogInformation("【SQL语句】：{0} \n {1} 【time:】{2} \n", sql, GetParas(p), db.Ado.SqlExecutionTime.ToString());
            //};
            db.Aop.OnError = (exp) =>//SQL报错
            {
                _logger.LogError(exp, "sql error! sql:{0} ,DateTime:{1}", exp.Sql, DateTime.Now.ToString());
            };
            return db;
        }

        private static string GetParas(SugarParameter[] pars)
        {
            string key = "【SQL参数】：";
            foreach (var param in pars)
            {
                key += $"{param.ParameterName}:{param.Value}\n";
            }

            return key;
        }
    }

 
}
