using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace xCodeGenerator
{
    [Serializable]
    public class SqlDataObject
    {
        protected virtual string GetConnectionString()
        {
            return string.Empty;
        }

        protected SqlDatabase DB
        {
            get
            {
                return new SqlDatabase(this.GetConnectionString());
            }
        }

        protected Result Execute(string procName, params object[] parameters)
        {
            Microsoft.Practices.EnterpriseLibrary.Data.Database.ClearParameterCache();

            DbCommand command = this.DB.GetStoredProcCommand(procName, parameters);

            int result = this.DB.ExecuteNonQuery(command);

            int return_val = -1000;
            foreach (DbParameter item in command.Parameters)
            {
                if (item.Direction == ParameterDirection.ReturnValue)
                    return_val = (int)item.Value;
            }

            if (return_val == 0)
            {
                return new Result()
                {
                    Type = ResultType.Success,
                    Code = return_val
                };
            }
            else
            {
                return new Result()
                {
                    Type = ResultType.Failed,
                    Code = return_val
                };
            }
        }

        protected Result<T> ExecuteScalar<T>(string procName, params object[] parameters)
        {
            try
            {
                Microsoft.Practices.EnterpriseLibrary.Data.Database.ClearParameterCache();

                DbCommand command = this.DB.GetStoredProcCommand(procName, parameters);

                T result = (T)this.DB.ExecuteScalar(command);

                int return_val = -1000;
                foreach (DbParameter item in command.Parameters)
                {
                    if (item.Direction == ParameterDirection.ReturnValue)
                        return_val = (int)item.Value;
                }

                if (return_val == 0)
                {
                    return new Result<T>()
                    {
                        Type = ResultType.Success,
                        Code = return_val,
                        Message = "Successfully completed",
                        ResultObj = result
                    };
                }
                else
                {
                    return new Result<T>()
                    {
                        Type = ResultType.Failed,
                        Code = return_val,
                        Message = string.Empty
                    };
                }
            }
            catch (Exception ex)
            {
                return new Result<T>()
                {
                    Type = ResultType.Failed,
                    Message = string.Format("Exception->{0}", ex)
                };
            }
        }

        protected List<T> SelectList<T>(string spName, params object[] parameters)
            where T : new()
        {
            try
            {
                var result = this.DB.ExecuteSprocAccessor<T>(spName, parameters);
                return result.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        protected T SelectSingle<T>(string spName, params object[] parameters)
            where T : new()
        {
            try
            {
                var result = this.DB.ExecuteSprocAccessor<T>(spName, parameters);
                return (T)result.First<T>();
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        protected Result<T> SelectWithType<T>(string spName, params object[] parameters)
            where T : new()
        {
            try
            {
                var result = this.DB.ExecuteSprocAccessor<T>(spName, parameters);

                return new Result<T>()
                {
                    Type = ResultType.Success,
                    ResultObj = (T)result
                };
            }
            catch (Exception ex)
            {
                return new Result<T>()
                {
                    Type = ResultType.Failed,
                    Message = ex.Message
                };
            }
        }

        protected DataSet ExecuteScript(string sqlScript)
        {
            try
            {
                Microsoft.Practices.EnterpriseLibrary.Data.Database.ClearParameterCache();

                DbCommand command = this.DB.GetSqlStringCommand(sqlScript);

                return this.DB.ExecuteDataSet(command);

                
            }
            catch (Exception ex)
            {
                return null; 
            }
        }
    }

}
