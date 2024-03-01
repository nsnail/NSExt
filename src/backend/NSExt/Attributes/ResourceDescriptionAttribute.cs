namespace NSExt.Attributes;

/// <summary>
///     本地化资源描述特性
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Field)]
public sealed class ResourceDescriptionAttribute<T> : Attribute
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ResourceDescriptionAttribute{T}" /> class.
    /// </summary>
    #pragma warning disable IDE0290
    public ResourceDescriptionAttribute(string resourceName)
        #pragma warning restore IDE0290
    {
        ResourceName = resourceName;
    }

    /// <summary>
    ///     资源名称
    /// </summary>
    public string ResourceName { get; }

    /// <summary>
    ///     资源对象
    /// </summary>
    public T ResourceObject { get; set; }
}