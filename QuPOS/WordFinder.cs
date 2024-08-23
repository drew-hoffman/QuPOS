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
            Dictionary<string, int> result = [];

            var cleanedWordstream = wordstream.Select(x => x.Trim()).Where(x => string.IsNullOrEmpty(x) == false).Distinct();

            var _matrix = matrix.Select(item => item.ToArray()).ToArray();
            result = SearchMatrixForWords(cleanedWordstream, _matrix, result);

            _matrix = RotateMatrix90DegreesCounterclockwise(_matrix);
            result = SearchMatrixForWords(cleanedWordstream, _matrix, result);

            var sortedAndFilteredPairs = result.OrderByDescending(x => x.Value).Take(10);
            var keys = sortedAndFilteredPairs.Select( x => x.Key).ToList();
            return keys;
        }

        private static Dictionary<string, int> SearchMatrixForWords(IEnumerable<string> wordstream, char[][] matrix, Dictionary<string, int> result)
        {
            foreach (string word in wordstream)
            {
                foreach (char[] line in matrix)
                {
                    var charAsString = new string(line);
                    //if (charAsString == null) continue;
                    
                    if (charAsString.Contains(word, StringComparison.OrdinalIgnoreCase))
                    {
                        if (result.ContainsKey(word))
                        {
                            result[word] = result[word] + 1;
                        }
                        else
                        {
                            result.Add(word, 1);
                        }
                    }
                }
            }
            return result;
        }

        private static char[][] RotateMatrix90DegreesCounterclockwise(char[][] matrix)
        {
            int h = matrix.Length;
            int w = matrix[0].Length;
            char[][] rotated = new char[w][];

            for (int i = 0; i < w; i++)
            {
                rotated[i] = new char[h];
                for (int j = 0; j < h; j++)
                {
                    rotated[i][j] = matrix[j][w - 1 - i];
                }
            }

            return rotated;
        }
    }
}
