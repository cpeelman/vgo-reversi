﻿using DataStructures;
using Model.Reversi;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ViewModel
{
    public class BoardViewModel
    {
        private readonly IList<BoardRowViewModel> rows;
        private readonly ReversiBoard reversiBoard;

        public IList<BoardRowViewModel> Rows { get { return rows; } }

        public BoardViewModel(ReversiBoard reversiBoard)
        {
            this.reversiBoard = reversiBoard;
            rows = Enumerable.Range(1, reversiBoard.Height).Select(_ => new BoardRowViewModel(reversiBoard.Width)).ToList().AsReadOnly();
            for (int i = 0; i < reversiBoard.Height; i++)
            {
                for (int j = 0; j < reversiBoard.Width; j++)
                {
                    var position = new Vector2D(i, j);
                    rows[i].Squares[j].Owner = reversiBoard[position];
                }
            }
        }
    }

    public class BoardRowViewModel
    {
        private readonly IList<BoardSquareViewModel> squares;

        public IList<BoardSquareViewModel> Squares { get { return squares; } }

        public BoardRowViewModel(int width)
        {
            squares = Enumerable.Range(1, width).Select(_ => new BoardSquareViewModel()).ToList().AsReadOnly();
        }
    }

    public class BoardSquareViewModel
    {
        public Player Owner { get; set; }
    }
}
