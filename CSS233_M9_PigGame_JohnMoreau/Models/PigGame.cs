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

        public int CurrentPlayer { get; set; }

        public int CurrentTotal { get; set; }



        [JsonIgnore]
        private Random random = new Random();

        // Define a function to roll a D6
        public int RollD6()
        {
            return random.Next(1, 7);
        }

        public void ResetGame()
        {
            Player1Score = 0;
            Player2Score = 0;
            CurrentPlayer = 1;
            CurrentTotal = 0;
        }

    }
}
