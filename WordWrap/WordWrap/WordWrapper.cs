namespace WordWrap
{
    using System.Collections.Generic;

    public static class WordWrapper
    {
        public static string Wrap(string text, int maxLength)
        {
            if (text != null)
            {
                var result = new List<char>(text.ToCharArray());
                for (var position = maxLength; position <= text.Length; position += maxLength +1)
                {
                    GetValue(ref position, result);
                }

                return new string(result.ToArray());
            }

            return null;
        }

        private static void GetValue(ref int position, List<char> result)
        {
            if (position < result.Count)
            {
                if (result[position] == ' ')
                {
                    result[position] = '\n';
                }
                else if (result.Count >= position - 1 && position > 0 && result[position - 1] == ' ')
                {
                    result[position - 1] = '\n';
                }
                else if (result.Count > position + 1 && result[position + 1] == ' ')
                {
                    result[position + 1] = '\n';
                    position++;
                }
                else
                {
                    result.Insert(position, '\n');
                }
            }
        }
    }
}