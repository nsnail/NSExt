namespace NSExt.Attributes;

/// <summary>
///     指定本地化资源类型
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Field)]
public sealed class LocalizationAttribute : Attribute
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="LocalizationAttribute" /> class.
    /// </summary>
    #pragma warning disable IDE0290
    public LocalizationAttribute(Type resourceClass)
        #pragma warning restore IDE0290
    {
        ResourceClass = resourceClass;
    }

    /// <summary>
    ///     Gets or sets 资源类型
    /// </summary>
    /// <value>
    ///     资源类型
    /// </value>
    public Type ResourceClass { get; set; }
}