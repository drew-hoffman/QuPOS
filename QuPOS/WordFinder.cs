namespace QuPOS
{
    public class WordFinder
    {
        private readonly IEnumerable<string> matrix;
        public WordFinder(IEnumerable<string> matrix)
        {
            var size = matrix.First().Count();
            if (matrix.Where(x => x.Length != size).Count() > 0) {
                throw new NotSupportedException("Only uniform grids are supported.");
            }

            this.matrix = matrix;
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            Dictionary<string, KeyValuePair<string, int>> result = [];

            char[][] _matrix = matrix.Select(item => item.ToArray()).ToArray();
            result = SearchMatrixForWords(wordstream, _matrix, result);

            var _matrix2 = RotateMatrix90DegreesCounterclockwise(_matrix);
            result = SearchMatrixForWords(wordstream, _matrix2, result);

            var sortedAndFilteredPairs = result.Values.OrderByDescending(x => x.Value).Take(10);
            var keys = sortedAndFilteredPairs.Select( x => x.Key).ToList();
            return keys;
        }

        private static Dictionary<string, KeyValuePair<string, int>> SearchMatrixForWords(IEnumerable<string> words, char[][] matrix, Dictionary<string, KeyValuePair<string, int>> result)
        {
            foreach (string word in words)
            {
                if (string.IsNullOrWhiteSpace(word)) continue;

                foreach (char[] line in matrix)
                {
                    var charAsString = new string(line);
                    if (charAsString == null) continue;
                    
                    if (charAsString.Contains(word, StringComparison.OrdinalIgnoreCase))
                    {
                        if (result.ContainsKey(word))
                        {
                            var pair = result[word];
                            result[word] = new KeyValuePair<string, int>(word, pair.Value + 1);
                        }
                        else
                        {
                            result.Add(word, new KeyValuePair<string, int>(word, 1));
                        }
                    }
                }
            }
            return result;
        }

        private static char[][] RotateMatrix90DegreesCounterclockwise(char[][] matrix)
        {
            int n = matrix.Length;
            int m = matrix[0].Length;
            char[][] rotated = new char[m][];

            for (int i = 0; i < m; i++)
            {
                rotated[i] = new char[n];
                for (int j = 0; j < n; j++)
                {
                    rotated[i][j] = matrix[j][m - 1 - i];
                }
            }

            return rotated;
        }
    }
}
