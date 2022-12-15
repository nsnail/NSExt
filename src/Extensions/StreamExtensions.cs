namespace NSExt.Extensions;

/// <summary>
///     StreamExtensions
/// </summary>
public static class StreamExtensions
{
    /// <summary>
    ///     FirstByteIndex
    /// </summary>
    public static long FirstByteIndex(this Stream me, byte[] findBytes)
    {
        int data;
        while ((data = me.ReadByte()) != -1) {
            if (findBytes.Contains((byte)data)) {
                return me.Position;
            }
        }

        return -1;
    }

    /// <summary>
    ///     IsTextStream
    /// </summary>
    public static bool IsTextStream(this Stream me)
    {
        return me.FirstByteIndex(new byte[] { 0x00, 0xff }) < 0;
    }
}