namespace Project.Extension
{
    public static class StringExtension
    {
        public static string RemoveLast(this string value, int removeLenght = 1)
            => value.Remove(value.Length - removeLenght);

    }
}