/*
* John Moreau
* CSS233
* 11/29/2023
*/


using Newtonsoft.Json;

namespace CSS233_M9_PigGame_JohnMoreau.Models
{
    public class PigGame
    {
        
        public int Player1Score { get; set; }

        public int Player2Score { get; set; }

        public int CurrentPlayer { get; set; } = 1;

        public int CurrentTotal { get; set; }

        public int CurrentRoll { get; set; }

        public bool GameOver { get; set; } = false;

        public List<int> RollHistory = new List<int>();


        public string RollHistoryString()
        {
            return string.Join(", ", RollHistory);
        }


        [JsonIgnore]
        private Random random = new();

        // Define a function to roll a D6
        public void Roll()
        {
            CurrentRoll = random.Next(1, 7);

            RollHistory.Add(CurrentRoll);

            if (CurrentRoll == 1)
            {
                SwitchPlayer();
                return;
            }

            CurrentTotal += CurrentRoll;

            if (CurrentTotal + GetCurrentPlayerScore() >= 20)
            {
                GameOver = true;
                AddScore();
            }
        }

        public void Hold()
        {
            AddScore();
            SwitchPlayer();
        }


        // Helper Functions
        private void AddScore()
        {
            if (CurrentPlayer == 1)
            {
                Player1Score += CurrentTotal;
            }
            else
            {
                Player2Score += CurrentTotal;
            }
        }

        private void SwitchPlayer()
        {
            CurrentTotal = 0;

            if (CurrentPlayer == 1)
            {
                CurrentPlayer = 2;
            } 
            else
            {
                CurrentPlayer = 1;
            }
        }

        private int GetCurrentPlayerScore()
        {
            if (CurrentPlayer == 1)
            {
                return Player1Score;
            }
            else
            {
                return Player2Score;
            }
        }



    }
}
