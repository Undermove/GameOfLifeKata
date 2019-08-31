namespace GameOfLifeTests
{
    public class Cell
    {
        private readonly IFieldRepository _fieldRepository;
        private readonly Point _position;
        
        public Cell(IFieldRepository fieldRepository, bool isAlive, Point position)
        {
            _fieldRepository = fieldRepository;
            IsAlive = isAlive;
            _position = position;
        }

        public bool IsAlive { get; private set; }
        
        public void GenerateNewState()
        {
            int aliveCellsCount = _fieldRepository.GetAliveCellsCountForPosition(_position);

            if (aliveCellsCount == 2)
            {
                if (IsAlive)
                {
                    IsAlive = true;
                    return;
                }
            }

            if (aliveCellsCount == 3)
            {
                IsAlive = true;
                return;
            }

            IsAlive = false;
        }
    }
}