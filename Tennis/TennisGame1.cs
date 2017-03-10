namespace Tennis
{
    internal class TennisGame1 : ITennisGame
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
            if (m_score1 == m_score2)
            {
                return HandleEvenScores();
            }
            else if ((m_score1 >= 4) || (m_score2 >= 4))
            {
                return HandleAdScores();
            }
            else
            {
                return HandlePreAdScores();
            }
        }

        private string HandlePreAdScores()
        {
            var score = GetPlayerScore(m_score1);
            score += "-";
            score += GetPlayerScore(m_score2);
            return score;
        }

        private string GetPlayerScore(int score)
        {
            switch (score)
            {
                case 0:
                    return "Love";
                case 1:
                    return "Fifteen";
                case 2:
                    return "Thirty";
                case 3:
                    return  "Forty";
            }
            return "";
        }

        private string HandleAdScores()
        {
            var minusResult = m_score1 - m_score2;
            if (minusResult == 1) return "Advantage player1";
            if (minusResult == -1) return "Advantage player2";
            if (minusResult >= 2) return "Win for player1";
            return "Win for player2";
        }

        private string HandleEvenScores()
        {
            switch (m_score1)
            {
                case 0:
                    return "Love-All";
                case 1:
                    return "Fifteen-All";
                case 2:
                    return "Thirty-All";
                default:
                    return "Deuce";
            }
        }
    }
}