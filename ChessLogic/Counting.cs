namespace ChessLogic
{
    public class Counting
    {
        private readonly Dictionary<PieceType, int> whiteCount = new();
        private readonly Dictionary<PieceType, int> blacCount = new();

        public int TotalCount { get; private set; }
        public Counting() 
        {
            foreach(PieceType type in Enum.GetValues(typeof(PieceType)))
            {
                whiteCount[type]=0;
                blacCount[type]=0;
            }
        }
        public void Increment(Player color, PieceType type)
        {
            if (color == Player.White)
            {
                whiteCount[type]++;
            }
            else if(color==Player.Black)
            {
                blacCount[type]++;
            }
            TotalCount++;
        }
        public int White(PieceType type)
        {
            return whiteCount[type];
        }
        public int Blac(PieceType type) 
        { 
            return blacCount[type];
        }

    }
    
}
