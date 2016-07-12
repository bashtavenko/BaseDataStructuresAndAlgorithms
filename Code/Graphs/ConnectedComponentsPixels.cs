namespace Code.Graphs
{
    public class ConnectedComponentsPixels
    {
        private readonly int[] _dx = {1, 0, -1, 0};
        private readonly int[] _dy = { 0, 1, 0, -1 };
        private readonly int[,] _a;
        private readonly int _rowCount;
        private readonly int _colCount;
        private readonly int[,] _marked;

        public ConnectedComponentsPixels(int[,] a)
        {
            _a = a;
            _rowCount = _a.GetLength(1);
            _colCount = _a.GetLength(0);
            _marked = new int[_rowCount, _colCount];
        }

        public void FindComponents()
        {
            var component = 0;
            for (var x = 0; x < _rowCount; x++)
                for (var y = 0; y < _colCount; y++)
                    if (_marked[x, y] == 0 && _a[x, y] == 1)
                        Dfs(x, y, ++component);
        }

        public int[] GetComponents()
        {
            var result = new int[_rowCount * _colCount];
            for (var x = 0; x < _rowCount; x++)
                for (var y = 0; y < _colCount; y++)
                {
                    var value = _marked[x, y];
                    if (value > 0) result[value]++;
                }
            return result;
        }

        private void Dfs(int x, int y, int component)
        {
            if (x < 0 || x == _rowCount) return;
            if (y < 0 || y == _colCount) return;
            if (_marked[x, y] > 0 || (_a[x, y] == 0)) return;

            _marked[x, y] = component;

            for (var direction = 0; direction < 4; ++direction)
            {
                Dfs(x + _dx[direction], y + _dy[direction], component);
            }            
        }
    }
}
