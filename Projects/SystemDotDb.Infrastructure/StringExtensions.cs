using System.Text;

namespace SystemDotDb.Infrastructure
{
    public static class StringExtensions
    {
        public static byte[] ToBytes(this string toConvert)
        {
            return Encoding.UTF8.GetBytes(toConvert);
        }
    }
}