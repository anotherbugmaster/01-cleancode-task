namespace CleanCode
{
	public class Chess
	{
	    private enum playerState
	    {
	        check,
            mate,
            ok,
            stalemate
	    }
		private readonly Board board;

		public Chess(Board board)
		{
		    this.board = board;
		}

		public string getWhiteStatus() {
			bool bad = checkForWhite();
			bool ok = false;
			foreach (Location loc1 in board.GetFiguresLocation(Cell.White))
			{
				foreach (Location loc2 in board.Get(loc1).Figure.PossibleTurns(loc1, board)){
				Cell old_dest = board.PerformMove(loc1, loc2);
				if (!checkForWhite( ))
					ok = true;
				board.PerformUndoMove(loc1, loc2, old_dest);
				}
			}
			if (bad)
				if (ok)
					return "check";
				else return "mate";
				if (ok)	return "ok";
			return "stalemate";
		}

		private bool checkForWhite()
		{
			bool bFlag = false;
			foreach (Location location in board.GetFiguresLocation(Cell.Black))
			{
				var cell = board.Get(location);
				var possibleTurns = cell.Figure.PossibleTurns(location, board);
				foreach (Location to in possibleTurns)
				{
					if (board.Get(to).IsWhiteKing)
						bFlag = true;
				}
			}
		    return bFlag;
		}
	}
}