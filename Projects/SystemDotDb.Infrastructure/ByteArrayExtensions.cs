using System.Text;

namespace SystemDotDb.Infrastructure
{
    public static class ByteArrayExtensions
    {
        public static string GetStringFromUtf8(this byte[] toConvert)
        {
            return Encoding.UTF8.GetString(toConvert);
        }
    }
}