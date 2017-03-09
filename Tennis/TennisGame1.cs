using System.Data.SqlClient;

namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                m_score1 += 1;
            else
                m_score2 += 1;
        }

        public string GetScore()
        {
            string score = "";
            var tempScore = 0;
            string score1;
            score1 = EvenScore();
            if (score1 != null)
            {
                return score1;
            }

            string s1;
            if (ScoreBiggerThan4(out s1)) return s1;

            return NormalScore(score);
        }

        private string NormalScore(string score)
        {
            int tempScore;
            {
                for (var i = 1; i < 3; i++)
                {
                    if (i == 1) tempScore = m_score1;
                    else
                    {
                        score += "-";
                        tempScore = m_score2;
                    }
                    switch (tempScore)
                    {
                        case 0:
                            score += "Love";
                            break;
                        case 1:
                            score += "Fifteen";
                            break;
                        case 2:
                            score += "Thirty";
                            break;
                        case 3:
                            score += "Forty";
                            break;
                    }
                }
            }
            return score;
        }

        private bool ScoreBiggerThan4(out string s1)
        {
            string score;
            if (m_score1 >= 4 || m_score2 >= 4)
            {
                var minusResult = m_score1 - m_score2;
                if (minusResult == 1) score = "Advantage player1";
                else if (minusResult == -1) score = "Advantage player2";
                else if (minusResult >= 2) score = "Win for player1";
                else score = "Win for player2";

                {
                    s1 = score;
                    return true;
                }
            }
            s1 = null;
            return false;
        }

        private string EvenScore()
        {
            string score;
            if (m_score1 == m_score2)
            {
                switch (m_score1)
                {
                    case 0:
                        score = "Love-All";
                        break;
                    case 1:
                        score = "Fifteen-All";
                        break;
                    case 2:
                        score = "Thirty-All";
                        break;
                    default:
                        score = "Deuce";
                        break;
                }

                return score;
            }
            return null;
        }
    }
}

