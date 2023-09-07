namespace NSExt.Extensions;

/// <summary>
///     DbCommandExtensions
/// </summary>
public static class DbCommandExtensions
{
    /// <summary>
    ///     格式化参数拼接成完整的SQL语句
    /// </summary>
    public static string ParameterFormat(this DbCommand me)
    {
        var sql = me.CommandText;

        // 应逆向替换，否则由于 多个表的过滤器问题导致替换不完整  如 @TenantId1  @TenantId10
        for (var i = me.Parameters.Count - 1; i >= 0; i--) {
            #pragma warning disable IDE0072
            sql = me.Parameters[i].DbType switch {
                      #pragma warning restore IDE0072
                      DbType.String or DbType.DateTime or DbType.Date or DbType.Time or DbType.DateTime2
                          or DbType.DateTimeOffset or DbType.Guid or DbType.VarNumeric or DbType.AnsiStringFixedLength
                          or DbType.AnsiString or DbType.StringFixedLength => sql.Replace( //
                              me.Parameters[i].ParameterName, "'" + me.Parameters[i].Value + "'")
                    , DbType.Boolean => sql.Replace( //
                          me.Parameters[i].ParameterName
                        , me.Parameters[i].Value != DBNull.Value &&
                          Convert.ToBoolean(me.Parameters[i].Value, CultureInfo.InvariantCulture)
                              ? "1"
                              : "0")
                    , _ => sql.Replace(me.Parameters[i].ParameterName, me.Parameters[i].Value?.ToString())
                  };
        }

        return sql;
    }
}