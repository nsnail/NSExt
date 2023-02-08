namespace NSExt.Attributes;

/// <summary>
///     指定本地化资源类型
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Field)]
public class LocalizationAttribute : Attribute
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="LocalizationAttribute" /> class.
    /// </summary>
    public LocalizationAttribute(Type resourceClass)
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