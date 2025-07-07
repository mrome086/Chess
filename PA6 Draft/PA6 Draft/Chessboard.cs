using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PA6_Draft
{
    public partial class Chessboard : Form
    {
        private Brush LightColor;
        private Brush DarkColor;
        private Brush Highlighted;
        private ChessGame Game;
        private Square Picked;
        private Square Dropped;
        private Point PickedLocation;
        private Point ShowPromotionChoices;
        private bool Freezed = false;
        private Move PromotionMove;
        private Dictionary<Piece,Bitmap> PieceImages;//BlackPawn,WhitePawn,BlackRook,WhiteRook,BlackKnight,WhiteKnight,BlackBishop,WhiteBishop
                                                     //,BlackKing, WhiteKing, BlackQueen, WhiteQueen;
        private SoundPlayer moved = new SoundPlayer(@"noise.wav");
        private SoundPlayer checkmate = new SoundPlayer(@"checkmate.wav");
       
        private SoundPlayer captured = new SoundPlayer(@"captured.wav");       // ***************updated***************
        private SoundPlayer castled = new SoundPlayer(@"castled.wav");        // ***************updated***************
        private SoundPlayer promoted = new SoundPlayer(@"promoted.wav");     // ***************updated***************
        private SoundPlayer stalemate = new SoundPlayer(@"stalemate.wav");  // ***************updated***************
        private SoundPlayer seconds = new SoundPlayer(@"seconds.wav");     // ***************updated***************
        /*change 1: add more SoundPlayer for captured, castled, promoted and stalemate events!
        ...
         */
        private BindingSource MoveList = new BindingSource();
       
        

        internal Chessboard(Color Light, Color Dark, ChessGame Game)
        {
            InitializeComponent();

            PieceImages = new Dictionary<Piece, Bitmap>();
            PieceImages.Add(Piece.BPAWN, new Bitmap(new Bitmap(@"bp.png"), new Size(64, 64)));
            PieceImages.Add(Piece.WPAWN, new Bitmap(new Bitmap(@"wp.png"), new Size(64, 64)));
            PieceImages.Add(Piece.BROOK, new Bitmap(new Bitmap(@"br.png"), new Size(64, 64)));
            PieceImages.Add(Piece.WROOK, new Bitmap(new Bitmap(@"wr.png"), new Size(64, 64)));
            PieceImages.Add(Piece.BKNIGHT, new Bitmap(new Bitmap(@"bkn.png"), new Size(64, 64)));
            PieceImages.Add(Piece.WKNIGHT, new Bitmap(new Bitmap(@"wkn.png"), new Size(64, 64)));
            PieceImages.Add(Piece.BBISHOP, new Bitmap(new Bitmap(@"bb.png"), new Size(64, 64)));
            PieceImages.Add(Piece.WBISHOP, new Bitmap(new Bitmap(@"wb.png"), new Size(64, 64)));
            PieceImages.Add(Piece.BKING, new Bitmap(new Bitmap(@"bk.png"), new Size(64, 64)));
            PieceImages.Add(Piece.WKING, new Bitmap(new Bitmap(@"wk.png"), new Size(64, 64)));
            PieceImages.Add(Piece.BQUEEN, new Bitmap(new Bitmap(@"bq.png"), new Size(64, 64)));
            PieceImages.Add(Piece.WQUEEN, new Bitmap(new Bitmap(@"wq.png"), new Size(64, 64)));
            LightColor = new SolidBrush(Light);
            DarkColor = new SolidBrush(Dark);
            Highlighted = new SolidBrush(Color.FromArgb(100, Color.FromName("yellow")));
            this.Game = Game;

            Player1Time.DataBindings.Add("Text", Game, "WhiteTimeLimit");  // ****************************updated************************
            Player2Time.DataBindings.Add("Text", Game, "BlackTimeLimit");  // ****************************updated************************

            /*change 2: bind Game.WhiteTimeLimit to Player1Time.Text 
             *change 3: bind Game.BlackTimeLimit to Player2Time.Text 
            ...
            */

            Player1.Text = Game.Player1Name;
            Player2.Text = Game.Player2Name;
            Game.Promote += Game_Promote;
            Game.Moved += Game_Moved;
            Game.Checkmate += Game_Checkmate;
            Game.Stalemate += Game_Stalemate;
            Game.Castled += Game_Castled;
            MoveList.DataSource = Game.Moves;
             
            listBox1.DataSource = MoveList;  // ****************************updated************************
            
            /*change 4: assign MoveList to listBox1.DataSource 
            ...
            */
            Picked = new Square(0,'z');
            Dropped = new Square(0, 'z');
            ShowPromotionChoices = new Point(-1, -1);
            PromotionMove = new Move(0,0,0,0);
            Board.Image = new Bitmap(512,512);
            Board_Paint(null,null);
        }
        private object Game_Moved(Move move)
        {
            
            MainTimer.Enabled = true; //************************************updated***************************
            //change 5: make two different noises for move and capture
           
            if (move.CapturedPiece == Piece.NONE) // working
            {
                moved.Play();
            }
            else
            {
                captured.Play();
            }
            
            
            return null;
        }
        private object Game_Castled(Move move) // ***************************updated***********************
        {
          
                castled.Play();
            
      
            
                    /*change 6: make a special noise for castling...
            ...
            */
            return null;
        }
        private object Game_Checkmate(Move move)
        {
            checkmate.Play();
            MainTimer.Stop();
            MessageBox.Show((((int)move.MovedPiece % 2 == 0)?
                                    Game.Player2Name:Game.Player1Name) + 
                                    " won by checkmate!");
            return null;
        }
        private object Game_Stalemate(Move move) // **********************updated*****************************
        {
           
            stalemate.Play();
            
            /*change 7: handle stalemate properly
            ...
            */
            return null;
        }
        private object Game_Promote(Move move) // *************************update******************************
        {
           promoted.Play();
            
            /*change 8: handle promote properly
            ...
            */
            return null;
        }
        
        private void Board_MouseDown(object sender, MouseEventArgs e)
        {
            int sizeUnit = (int)Math.Round(Board.Image.Width / 16.0);
            int X = e.X / (2*sizeUnit);
            int Y = e.Y / (2 * sizeUnit);
            if (Freezed)
            {
                if (ShowPromotionChoices.Y == 0)
                    switch (Y)
                    {
                        case 0:
                            PromotionMove.Promoted = Promotion.WQUEEN;
                            break;
                        case 1:
                            PromotionMove.Promoted = Promotion.WROOK;
                            break;
                        case 2:
                            PromotionMove.Promoted = Promotion.WBISHOP;
                            break;
                        case 3:
                            PromotionMove.Promoted = Promotion.WKNIGHT;
                            break;
                    }
                else
                    switch (Y)
                    {
                        case 7:
                            PromotionMove.Promoted = Promotion.BQUEEN;
                            break;
                        case 6:
                            PromotionMove.Promoted = Promotion.BROOK;
                            break;
                        case 5:
                            PromotionMove.Promoted = Promotion.BBISHOP;
                            break;
                        case 4:
                            PromotionMove.Promoted = Promotion.BKNIGHT;
                            break;
                    }
                return;
            }
            if (Game.Board[X][Y].Occupant == Piece.NONE)
                return;
            Picked = new Square(Game.Board[X][Y].Rank,
                                Game.Board[X][Y].File,
                                Game.Board[X][Y].Occupant);
            PickedLocation = new Point(e.Location.X - sizeUnit, e.Location.Y - sizeUnit);
            Board.Refresh();
        }
        private void Board_MouseUp(object sender, MouseEventArgs e)
        {
            int sizeUnit = (int)Math.Round(Board.Image.Width / 16.0);
            int X = e.X / (2 * sizeUnit);
            int Y = e.Y / (2 * sizeUnit);
            if (Freezed)
            {
                if (PromotionMove.Promoted != Promotion.NONE)
                {
                    Game.CompletePromotionMove(PromotionMove);
                    Dropped = new Square(Game.Board[PromotionMove.X2][PromotionMove.Y2].Rank,
                                    Game.Board[PromotionMove.X2][PromotionMove.Y2].File,
                                    Game.Board[PromotionMove.X2][PromotionMove.Y2].Occupant);
                    Freezed = false;
                    ShowPromotionChoices = new Point(-1, -1);
                    Board.Invalidate();
                }
                return;
            }
            if (Picked.Occupant == Piece.NONE)
                return;
            if (e.X >= Board.Width || e.Y >= Board.Height || e.X < 0 || e.Y < 0)
            {
                Picked = new Square(0, 'z');
                Board.Invalidate();
                return;
            }
            Move move = new Move(Picked.File - 'a', 8 - Picked.Rank, X, Y);
            bool Success = Game.Move(move);
            //Game.Board[Picked.File - 'a'][8 - Picked.Rank].Occupant = Piece.NONE;
            //Game.Board[X][Y].Occupant = Picked.Occupant;
            if(Success)
                if (Game.AutoPromote || move.Promoted == Promotion.NONE)
                    Dropped = new Square(Game.Board[X][Y].Rank,
                                    Game.Board[X][Y].File,
                                    Game.Board[X][Y].Occupant);
                else
                {
                    ShowPromotionChoices = new Point(X * 2 * sizeUnit, (Y != 0 ? 4 : 0) * 2 * sizeUnit);
                    PromotionMove = move;
                }
                    
            Picked.Occupant = Piece.NONE ;
            Board.Invalidate();
        }

        private void Board_MouseMove(object sender, MouseEventArgs e)
        {
            if (Freezed)
            {
                PromotionMove.Promoted = Promotion.NONE;
                Board.Invalidate();
                return;
            }
            int sizeUnit = (int)Math.Round(Board.Image.Width / 16.0);
            if (Picked.Occupant != Piece.NONE)
            {
                PickedLocation = new Point(e.Location.X - sizeUnit, e.Location.Y - sizeUnit);
                if (e.X >= Board.Width)
                    PickedLocation.X = Board.Width - sizeUnit;
                if (e.X < 0)
                    PickedLocation.X = -sizeUnit;
                if (e.Y >= Board.Height)
                    PickedLocation.Y = Board.Height - sizeUnit;
                if (e.Y < 0)
                    PickedLocation.Y = -sizeUnit;
            }
            Board.Invalidate();

        }
        private void Board_Paint(object sender, PaintEventArgs e)
        {
            int squareWidth = (int)Math.Round(Board.Image.Width / 8.0);
            using (Graphics g = Graphics.FromImage(Board.Image))
            {
                for (int i = 0; i < 8; i++)
                    for (int j = 0; j < 8; j++)
                        if ((i + j) % 2 == 0)
                            g.FillRectangle(LightColor, new Rectangle(squareWidth * i, squareWidth * j, squareWidth, squareWidth));
                        else
                            g.FillRectangle(DarkColor, new Rectangle(squareWidth * i, squareWidth * j, squareWidth, squareWidth));
                for (int i = 0; i < 8; i++)
                {
                    g.DrawString("" + (8 - i), new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold),
                        (i % 2 == 0) ? DarkColor : LightColor, new Point(0, 3 * squareWidth / 64 + squareWidth * i));
                    g.DrawString("" + (char)('a' + i), new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold),
                        (i % 2 == 1) ? DarkColor : LightColor, new Point(54 * squareWidth/64 + squareWidth * i, 498));
                }
                if(Dropped.Occupant != Piece.NONE)
                    g.FillRectangle(Highlighted, new Rectangle(squareWidth * (Dropped.File - 'a'), squareWidth * (8 - Dropped.Rank), squareWidth, squareWidth));
                for (int i = 0; i < 8; i++)
                    for (int j = 0; j < 8; j++)
                    {
                        if (Game.Board[i][j].Occupant == Piece.NONE)//empty square
                            continue;
                        if (Picked.Occupant != Piece.NONE)
                            if (Game.Board[i][j].Rank == Picked.Rank && Game.Board[i][j].File == Picked.File)
                                continue;
                        g.DrawImage(PieceImages[Game.Board[i][j].Occupant], new Point(squareWidth * i, squareWidth * j));
                    }
                if (Picked.Occupant != Piece.NONE)
                {
                    g.FillRectangle(Highlighted,
                    new Rectangle(squareWidth * (Picked.File - 'a'), squareWidth * (8 - Picked.Rank), squareWidth, squareWidth));
                    g.DrawImage(PieceImages[Picked.Occupant], PickedLocation);
                }
                if (ShowPromotionChoices.Y == 0)
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(200, Color.FromName("White")))
                        ,new Rectangle(ShowPromotionChoices,new Size(squareWidth,4*squareWidth)));
                    g.DrawImage(PieceImages[Piece.WQUEEN], new Point(ShowPromotionChoices.X,ShowPromotionChoices.Y));
                    g.DrawImage(PieceImages[Piece.WROOK], new Point(ShowPromotionChoices.X, ShowPromotionChoices.Y + squareWidth));
                    g.DrawImage(PieceImages[Piece.WBISHOP], new Point(ShowPromotionChoices.X, ShowPromotionChoices.Y + squareWidth*2));
                    g.DrawImage(PieceImages[Piece.WKNIGHT], new Point(ShowPromotionChoices.X, ShowPromotionChoices.Y + squareWidth*3));
                    Freezed = true;
                }
                else if(ShowPromotionChoices.Y > 0)
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(200, Color.FromName("White")))
                        , new Rectangle(ShowPromotionChoices, new Size(squareWidth, 4 * squareWidth)));
                    g.DrawImage(PieceImages[Piece.BQUEEN], new Point(ShowPromotionChoices.X, ShowPromotionChoices.Y+squareWidth * 3));
                    g.DrawImage(PieceImages[Piece.BROOK], new Point(ShowPromotionChoices.X, ShowPromotionChoices.Y +2* squareWidth));
                    g.DrawImage(PieceImages[Piece.BBISHOP], new Point(ShowPromotionChoices.X, ShowPromotionChoices.Y + squareWidth ));
                    g.DrawImage(PieceImages[Piece.BKNIGHT], new Point(ShowPromotionChoices.X, ShowPromotionChoices.Y ));
                    Freezed = true;
                }
            }
        }

        private void ChessBoard_MouseMove(object sender, MouseEventArgs e)
        {
            Board.Invalidate();
        }

        private void Board_MouseLeave(object sender, EventArgs e)
        {
            Board.Invalidate();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            if (Game.WhiteTurn)
            {
                if (Game.WLimit <= MainTimer.Interval)
                {

                    Game.WhiteTimeLimit = "0.00";
                    Game.WLimit = 0;
                    MainTimer.Stop();
                    MessageBox.Show(Game.Player1Name + " lost by timeout");
                }
                else
                    Game.WhiteTimeLimit = Game.TimeToString(Game.WLimit -= MainTimer.Interval);
            }
            else
            {
                if (Game.BLimit <= MainTimer.Interval)
                {
                    Game.BlackTimeLimit = "0.00";
                    Game.BLimit = 0;
                    MainTimer.Stop();
                    MessageBox.Show(Game.Player2Name + " lost by timeout");
                }
                else
                    Game.BlackTimeLimit = Game.TimeToString(Game.BLimit -= MainTimer.Interval);
            }
        
           // ************************updated**************************
          
            
            
                if (Game.WhiteTimeLimit == "0:10")
                {
                seconds.Play();
                }


                if (Game.BlackTimeLimit == "0:10")
                {
                    seconds.Play();
                }
   
        
        
        }


        private void Chessboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainTimer.Stop();
        }

        private void Board_Click(object sender, EventArgs e)
        {

        }
    }
}
