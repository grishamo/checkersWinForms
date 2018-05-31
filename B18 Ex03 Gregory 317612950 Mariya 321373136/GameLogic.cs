using System;
using System.Collections.Generic;

namespace B18_Ex05_Gregory_317612950_Mariya_321373136
{
    class GameLogic
    {
        private BoardPiece[,] m_GameBoard;
        private int m_GameBoardSize;
        private List<BoardPiece> m_MustToAttackList;
        private Player m_FirstPlayer;
        private Player m_SecondPlayer;
        private Player m_CurrentPlayer = null;
        private Player m_EnemyPlayer = null;
        private bool m_IsVsComp;
        private bool m_GameOver = false;

        public GameLogic(Player i_FirstPlayer, Player i_SecondPlayer, BoardPiece[,] i_GameBoard, bool i_IsVsComp)
        {
            m_FirstPlayer = i_FirstPlayer;
            m_SecondPlayer = i_SecondPlayer;
            m_IsVsComp = i_IsVsComp;
            m_CurrentPlayer = m_FirstPlayer;
            m_EnemyPlayer = m_SecondPlayer;

            m_GameBoard = i_GameBoard;
            m_GameBoardSize = (int)Math.Sqrt(i_GameBoard.Length);
        }

        public Player CurrentPlayer
        {
            get { return m_CurrentPlayer;  }
        }

        private List<BoardPiece> setMustToAttackList()
        {
            return setMustToAttackList(CurrentPlayer);
        }
        private List<BoardPiece> setMustToAttackList(Player i_chosenPlayer)
        {
            //m_MustToAttackList = new List<BoardPiece>();
            List<BoardPiece> mustToAttackList = new List<BoardPiece>();
            bool topLeftIsEnemy = true;
            bool topTopLeftIsEmpty = true;
            bool topRightIsEnemy = true;
            bool topTopRightIsEmpty = true;
            bool bottomLeftIsEnemy = true;
            bool bottomBottomLeftIsEmpty = true;
            bool bottomRightIsEnemy = true;
            bool bottomBottompRightIsEmpty = true;

            foreach (BoardPiece obj in m_GameBoard)
            {
                topLeftIsEnemy = isEnemyPiece(obj.Position.X - 1, obj.Position.Y - 1);
                topTopLeftIsEmpty = isPieceValue(obj.Position.X - 2, obj.Position.Y - 2, "");
                topRightIsEnemy = isEnemyPiece(obj.Position.X - 1, obj.Position.Y + 1);
                topTopRightIsEmpty = isPieceValue(obj.Position.X - 2, obj.Position.Y + 2, "");
                bottomLeftIsEnemy = isEnemyPiece(obj.Position.X + 1, obj.Position.Y - 1);
                bottomBottomLeftIsEmpty = isPieceValue(obj.Position.X + 2, obj.Position.Y - 2, "");
                bottomRightIsEnemy = isEnemyPiece(obj.Position.X + 1, obj.Position.Y + 1);
                bottomBottompRightIsEmpty = isPieceValue(obj.Position.X + 2, obj.Position.Y + 2, "");

                // check if piece value belongs to current player
                if (i_chosenPlayer.IsPlayerPiece(obj))
                {
                    bool isQueen = obj.Value.Equals(m_CurrentPlayer.QueenPieceValue);

                    // check if current player is a bottom player 
                    if (m_CurrentPlayer.Equals(m_FirstPlayer))
                    {

                        if (topLeftIsEnemy && topTopLeftIsEmpty)
                        {
                            mustToAttackList.Add(obj);
                        }
                        else if (topRightIsEnemy && topTopRightIsEmpty)
                        {
                            mustToAttackList.Add(obj);
                        }
                        else if (isQueen)
                        {
                            if (bottomLeftIsEnemy && bottomBottomLeftIsEmpty)
                            {
                                mustToAttackList.Add(obj);
                            }
                            else if (bottomRightIsEnemy && bottomBottompRightIsEmpty)
                            {
                                mustToAttackList.Add(obj);
                            }
                        }
                    }
                    // current player is top player
                    else
                    {

                        if (bottomLeftIsEnemy && bottomBottomLeftIsEmpty)
                        {
                            mustToAttackList.Add(obj);
                        }
                        else if (bottomRightIsEnemy && bottomBottompRightIsEmpty)
                        {
                            mustToAttackList.Add(obj);
                        }
                        else if (isQueen)
                        {

                            if (topLeftIsEnemy && topTopLeftIsEmpty)
                            {
                                mustToAttackList.Add(obj);
                            }
                            else if (topRightIsEnemy && topTopRightIsEmpty)
                            {
                                mustToAttackList.Add(obj);
                            }

                        }

                    }
                }
            }

            return mustToAttackList;
        }

        private bool isEnemyPiece(int i_Row, int i_Col)
        {
            bool returnValue = true;

            if (i_Row >= 0 && i_Col >= 0 && i_Row < m_GameBoardSize && i_Col < m_GameBoardSize)
            {
                returnValue = m_EnemyPlayer.IsPlayerPiece(m_GameBoard[i_Row, i_Col]);
            }
            else
            {
                returnValue = false;
            }

            return returnValue;
        }

        private bool isPieceValue(int i_Row, int i_Col, string i_PieceValue)
        {
            bool returnValue = false;

            if (i_Row >= 0 && i_Col >= 0 && i_Row < m_GameBoardSize && i_Col < m_GameBoardSize)
            {
                if (m_GameBoard[i_Row, i_Col].Value.Equals(i_PieceValue))
                {
                    returnValue = true;
                }
            }

            return returnValue;
        }

        private BoardPiece getUnderAttackPiece(BoardPiece i_FromPiece, BoardPiece i_ToPiece)
        {
            BoardPiece returnPiece;

            if (i_ToPiece.Position.Y > i_FromPiece.Position.Y)
            {
                if (i_ToPiece.Position.X > i_FromPiece.Position.X)
                {
                    returnPiece = m_GameBoard[i_FromPiece.Position.X + 1, i_FromPiece.Position.Y + 1];
                }
                else
                {
                    returnPiece = m_GameBoard[i_FromPiece.Position.X - 1, i_FromPiece.Position.Y + 1];
                }

            }
            else
            {
                if (i_ToPiece.Position.X > i_FromPiece.Position.X)
                {
                    returnPiece = m_GameBoard[i_FromPiece.Position.X + 1, i_FromPiece.Position.Y - 1];
                }
                else
                {
                    returnPiece = m_GameBoard[i_FromPiece.Position.X - 1, i_FromPiece.Position.Y - 1];
                }
            }

            return returnPiece;
        }

        private bool isValidJumpByStep(BoardPiece i_To, BoardPiece i_From, int steps)
        {
            bool returnValue = true;
            bool isColValid = i_To.Position.Y == i_From.Position.Y + steps || i_To.Position.Y == i_From.Position.Y - steps;
            bool isQueen = m_CurrentPlayer.QueenPieceValue.Equals(i_From.Value);

            if (isColValid)
            {
                if (isQueen)
                {
                    returnValue = i_To.Position.X == i_From.Position.X - steps || i_To.Position.X == i_From.Position.X + steps;
                }
                ////bottom player
                else if (m_CurrentPlayer.Equals(m_FirstPlayer))
                {
                    returnValue = i_To.Position.X == i_From.Position.X - steps;
                }
                ////top player
                else if (m_CurrentPlayer.Equals(m_SecondPlayer))
                {
                    returnValue = i_To.Position.X == i_From.Position.X + steps;
                }

            }
            else
            {
                returnValue = !returnValue;
            }
            return returnValue;
        }

        private bool isValidMove(BoardPiece i_From, BoardPiece i_To)
        {
            bool returnValue = true;
            bool isCurrentPlayerPiece = m_CurrentPlayer.IsPlayerPiece(i_From);
            bool isAttack = m_MustToAttackList.Contains(i_From);
            bool isToCoordinateEmpty = i_To.Value.Equals("");

            if (isCurrentPlayerPiece && isToCoordinateEmpty)
            {
                if (m_MustToAttackList.Count > 0)
                {
                    if (isAttack)
                    {
                        BoardPiece underAttack = getUnderAttackPiece(i_From, i_To);
                        returnValue = isValidJumpByStep(i_To, i_From, 2) && m_EnemyPlayer.IsPlayerPiece(underAttack);
                    }
                    else
                    {
                        returnValue = !returnValue;
                    };
                }
                else
                {
                    returnValue = isValidJumpByStep(i_To, i_From, 1);
                }

            }
            else
            {
                returnValue = !returnValue;
            }

            return returnValue;
        }

        public bool isGameOver()
        {
            bool v_IsGameOver = true;
            foreach (BoardPiece obj in m_GameBoard)
            {
                if (m_EnemyPlayer.IsPlayerPiece(obj) && hasValidMove(obj))
                {
                    v_IsGameOver = false;
                    break;
                }
            }

            if (v_IsGameOver)
            {
                m_GameOver = v_IsGameOver;
            }
            return v_IsGameOver;
        }

        private bool hasValidMove(BoardPiece i_EnemyBoardPiece)
        {
            bool topLeftIsEmpty = isPieceValue(i_EnemyBoardPiece.Position.X - 1, i_EnemyBoardPiece.Position.Y - 1, "");
            bool topRightIsEmpty= isPieceValue(i_EnemyBoardPiece.Position.X - 1, i_EnemyBoardPiece.Position.Y + 1, "");
            bool bottomLeftIsEmpty = isPieceValue(i_EnemyBoardPiece.Position.X + 1, i_EnemyBoardPiece.Position.Y - 1, "");
            bool bottomRightIsEmpty = isPieceValue(i_EnemyBoardPiece.Position.X + 1, i_EnemyBoardPiece.Position.Y + 1, "");
            bool hasAMove = false;
            List<BoardPiece> enemyMustToAttak = setMustToAttackList(m_EnemyPlayer);
              
            if(enemyMustToAttak.Contains(i_EnemyBoardPiece))
            {
                hasAMove = true;
            }
            else if(m_EnemyPlayer == m_SecondPlayer)
            {
                if (bottomLeftIsEmpty || bottomRightIsEmpty)
                {
                    hasAMove = true;
                }
                if( i_EnemyBoardPiece.isQueneValue() && (topLeftIsEmpty || topRightIsEmpty))
                {
                    hasAMove = true;
                }
            }
            else
            {
                if (topLeftIsEmpty || topRightIsEmpty)
                {
                    hasAMove = true;
                }
                if (i_EnemyBoardPiece.isQueneValue() && (bottomLeftIsEmpty || bottomRightIsEmpty))
                {
                    hasAMove = true;
                }
            }

            return hasAMove;
        }

        public void SwitchPlayer()
        {
            Player tempPlayer = m_CurrentPlayer;
            m_CurrentPlayer = m_EnemyPlayer;
            m_EnemyPlayer = tempPlayer;

            if(m_IsVsComp && m_CurrentPlayer.Equals(m_SecondPlayer))
            {
                AutomaticMove();
            }
        }

        private void AutomaticMove()
        {
            BoardPiece fromPiece = null;
            BoardPiece toPiece = null;

            m_MustToAttackList = setMustToAttackList();

            if (m_MustToAttackList.Count > 0)
            {
                fromPiece = m_MustToAttackList[0];
            }
            else
            {
                fromPiece = getMoveFromPiece();
            }

            if (fromPiece != null)
            {
                toPiece = getToPiece(fromPiece);
                Move(fromPiece, toPiece);
            }
        }

        private BoardPiece getToPiece(BoardPiece i_From)
        {
            BoardPiece returnPiece = null;
            bool isAttack = m_MustToAttackList.Contains(i_From);
            bool isQueen = i_From.Value.Equals(m_CurrentPlayer.QueenPieceValue);

            bool topLeftIsEnemy = isEnemyPiece(i_From.Position.X - 1, i_From.Position.Y - 1);
            bool topTopLeftIsEmpty = isPieceValue(i_From.Position.X - 2, i_From.Position.Y - 2, "");
            bool topRightIsEnemy = isEnemyPiece(i_From.Position.X - 1, i_From.Position.Y + 1);
            bool topTopRightIsEmpty = isPieceValue(i_From.Position.X - 2, i_From.Position.Y + 2, "");
            bool bottomLeftIsEnemy = isEnemyPiece(i_From.Position.X + 1, i_From.Position.Y - 1);
            bool bottomBottomLeftIsEmpty = isPieceValue(i_From.Position.X + 2, i_From.Position.Y - 2, "");
            bool bottomRightIsEnemy = isEnemyPiece(i_From.Position.X + 1, i_From.Position.Y + 1);
            bool bottomBottompRightIsEmpty = isPieceValue(i_From.Position.X + 2, i_From.Position.Y + 2, "");


            if (m_CurrentPlayer.Equals(m_SecondPlayer))
            {
                if (isAttack)
                {
                    if (bottomLeftIsEnemy && bottomBottomLeftIsEmpty)
                    {
                        returnPiece = m_GameBoard[i_From.Position.X + 2, i_From.Position.Y - 2];
                    }
                    else if (bottomRightIsEnemy && bottomBottompRightIsEmpty)
                    {
                        returnPiece = m_GameBoard[i_From.Position.X + 2, i_From.Position.Y + 2];
                    }
                    else if (isQueen)
                    {
                        if (topLeftIsEnemy && topTopLeftIsEmpty)
                        {
                            returnPiece = m_GameBoard[i_From.Position.X - 2, i_From.Position.Y - 2];
                        }
                        else if (topRightIsEnemy && topTopRightIsEmpty)
                        {
                            returnPiece = m_GameBoard[i_From.Position.X - 2, i_From.Position.Y + 2];
                        }
                    }
                }
                else
                {
                    if (isPieceValue(i_From.Position.X + 1, i_From.Position.Y + 1, ""))
                    {
                        returnPiece = m_GameBoard[i_From.Position.X + 1, i_From.Position.Y + 1];
                    }
                    else if (isPieceValue(i_From.Position.X + 1, i_From.Position.Y - 1, ""))
                    {
                        returnPiece = m_GameBoard[i_From.Position.X + 1, i_From.Position.Y - 1];
                    }
                    else if (isQueen)
                    {
                        if (isPieceValue(i_From.Position.X - 1, i_From.Position.Y - 1, ""))
                        {
                            returnPiece = m_GameBoard[i_From.Position.X - 1, i_From.Position.Y - 1];
                        }
                        else if (isPieceValue(i_From.Position.X - 1, i_From.Position.Y + 1, ""))
                        {
                            returnPiece = m_GameBoard[i_From.Position.X - 1, i_From.Position.Y + 1];
                        }
                    }
                }
            }
            return returnPiece;
        }

        private BoardPiece getMoveFromPiece()
        {
            BoardPiece returnPiece = null;

            foreach (BoardPiece obj in m_GameBoard)
            {
                if (m_CurrentPlayer.IsPlayerPiece(obj))
                {
                   
                        if (isPieceValue(obj.Position.X + 1, obj.Position.Y + 1, "") || isPieceValue(obj.Position.X + 1, obj.Position.Y - 1, ""))
                        {
                            returnPiece = obj;
                        }
                        else if (m_CurrentPlayer.QueenPieceValue.Equals(obj.Value))
                        {
                            if (isPieceValue(obj.Position.X - 1, obj.Position.Y - 1, "") || isPieceValue(obj.Position.X - 1, obj.Position.Y + 1, ""))
                            {
                                returnPiece = obj;
                            }
                        }
                    
                }
            }

            return returnPiece;
        }

        public void Move(BoardPiece i_From, BoardPiece i_To)
        {
            bool attacked = false;
            string errorMsg = null;

            m_MustToAttackList = setMustToAttackList();

            if (isValidMove(i_From, i_To))
            {
                int fromRow = i_From.Position.X;
                int fromCol = i_From.Position.Y;
                int toRow = i_To.Position.X;
                int toCol = i_To.Position.Y;


                if (m_MustToAttackList.Count > 0)
                {
                    BoardPiece pieceUnderAttack = getUnderAttackPiece(i_From, i_To);
                    m_GameBoard[pieceUnderAttack.Position.X, pieceUnderAttack.Position.Y].Value = "";
                    attacked = true;
                }

                //Queens
                if (toRow == m_GameBoardSize - 1 && i_From.Value.Equals("O"))
                {
                    m_GameBoard[toRow, toCol].Value = "Q";
                }
                else if (toRow == 0 && i_From.Value.Equals("X"))
                {
                    m_GameBoard[toRow, toCol].Value = "K";
                }
                else
                {
                    m_GameBoard[toRow, toCol].Value = i_From.Value;
                }

                m_GameBoard[fromRow, fromCol].Value = "";

                m_MustToAttackList = setMustToAttackList();

                if (!isGameOver())
                {
                    if (attacked)
                    {
                        if (m_MustToAttackList.Count == 0)
                        {
                            SwitchPlayer();
                        }
                        else if(m_IsVsComp && m_CurrentPlayer == m_SecondPlayer)
                        {
                            AutomaticMove();
                        }
                    }
                    else
                    {
                        SwitchPlayer();
                    }
                }

            }
            else
            {
                errorMsg = "Invalid Move!";
            }

            if (errorMsg != null)
            {
                throw new Exception(errorMsg);
            }
        }

    }
}
