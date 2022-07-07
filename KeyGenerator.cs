using System.Collections.Generic;
using System.Text;

namespace Celones.MicrosoftKeyTool
{
    class KeyGenerator
    {
        private const string m_characters = "2346789BCDFGHJKMPQRTVWXY";
        private readonly StringBuilder m_builder;
        private readonly List<int> m_unknowns;
        private readonly int m_maxIndex;
        private int m_index = 0;

        public int PossibilitiesCount { get => m_maxIndex; }

        public KeyGenerator(string pattern)
        {
            m_builder = new(pattern);
            m_unknowns = GetAllIndexesOf(pattern, '?');
            m_maxIndex = Pow(m_characters.Length, (uint)m_unknowns.Count);
        }

        public string GetNext()
        {
            if (m_index >= m_maxIndex)
            {
                return string.Empty;
            }

            int index = m_index;
            for (int i = 0; i < m_unknowns.Count; i++)
            {
                m_builder[m_unknowns[i]] = m_characters[index % m_characters.Length];
                index /= m_characters.Length;
            }

            m_index++;
            return m_builder.ToString();
        }

        private static List<int> GetAllIndexesOf(string s, char c)
        {
            var foundIndexes = new List<int>();

            for (int i = s.IndexOf(c); i > -1; i = s.IndexOf(c, i + 1))
            {
                foundIndexes.Add(i);
            }

            return foundIndexes;
        }

        private static int Pow(int x, uint pow)
        {
            int ret = 1;
            while (pow != 0)
            {
                if ((pow & 1) == 1)
                    ret *= x;
                x *= x;
                pow >>= 1;
            }
            return ret;
        }
    }
}
