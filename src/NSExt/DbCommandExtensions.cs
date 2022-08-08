// @program: NSExt
// @file: DbCommandExtensions.cs
// @author: tao ke
// @mailto: taokeu@gmail.com
// @created: 08/06/2022 19:48

using System.Data;
using System.Data.Common;

namespace NSExt;

public static class DbCommandExtensions
{
    /// <summary>
    ///     格式化参数拼接成完整的SQL语句
    /// </summary>
    /// <returns></returns>
    public static string ParameterFormat(this DbCommand me)
    {
        //var aa = pars.ToDictionary(it => it.ParameterName, it => it.Value);
        var sql = me.CommandText;

        //应逆向替换，否则由于 多个表的过滤器问题导致替换不完整  如 @TenantId1  @TenantId10
        for (var i = me.Parameters.Count - 1; i >= 0; i--)
            sql = me.Parameters[i].DbType switch {
                      DbType.String or DbType.DateTime or DbType.Date or DbType.Time or DbType.DateTime2
                          or DbType.DateTimeOffset or DbType.Guid or DbType.VarNumeric or DbType.AnsiStringFixedLength
                          or DbType.AnsiString
                          or DbType.StringFixedLength => sql.Replace(me.Parameters[i].ParameterName,
                                                                     "'" + me.Parameters[i].Value + "'"),
                      DbType.Boolean => sql.Replace(me.Parameters[i].ParameterName,
                                                    Convert.ToBoolean(me.Parameters[i].Value) ? "1" : "0"),
                      _ => sql.Replace(me.Parameters[i].ParameterName, me.Parameters[i].Value?.ToString())
                  };

        return sql;
    }
}
