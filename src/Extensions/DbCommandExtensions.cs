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
        //var aa = pars.ToDictionary(it => it.ParameterName, it => it.Value);
        var sql = me.CommandText;

        //应逆向替换，否则由于 多个表的过滤器问题导致替换不完整  如 @TenantId1  @TenantId10
        for (var i = me.Parameters.Count - 1; i >= 0; i--) {
            sql = me.Parameters[i].DbType switch {
                      DbType.String or DbType.DateTime or DbType.Date or DbType.Time or DbType.DateTime2
                          or DbType.DateTimeOffset or DbType.Guid or DbType.VarNumeric or DbType.AnsiStringFixedLength
                          or DbType.AnsiString or DbType.StringFixedLength => sql.Replace( //
                              me.Parameters[i].ParameterName, "'" + me.Parameters[i].Value + "'")
                    , DbType.Boolean => sql.Replace( //
                          me.Parameters[i].ParameterName
                        , Convert.ToBoolean(me.Parameters[i].Value, CultureInfo.InvariantCulture) ? "1" : "0")
                    , DbType.Binary   => throw new NotImplementedException()
                    , DbType.Byte     => throw new NotImplementedException()
                    , DbType.Currency => throw new NotImplementedException()
                    , DbType.Decimal  => throw new NotImplementedException()
                    , DbType.Double   => throw new NotImplementedException()
                    , DbType.Int16    => throw new NotImplementedException()
                    , DbType.Int32    => throw new NotImplementedException()
                    , DbType.Int64    => throw new NotImplementedException()
                    , DbType.Object   => throw new NotImplementedException()
                    , DbType.SByte    => throw new NotImplementedException()
                    , DbType.Single   => throw new NotImplementedException()
                    , DbType.UInt16   => throw new NotImplementedException()
                    , DbType.UInt32   => throw new NotImplementedException()
                    , DbType.UInt64   => throw new NotImplementedException()
                    , DbType.Xml      => throw new NotImplementedException()
                    , _               => sql.Replace(me.Parameters[i].ParameterName, me.Parameters[i].Value?.ToString())
                  };
        }

        return sql;
    }
}