using System.Runtime.InteropServices;

namespace CSS233_M9_PigGame_JohnMoreau.Models
{
    public class PigGameSession
    {
        private const string GameKey = "game";

        private ISession session { get; set; }

        public PigGameSession(ISession session) => this.session = session;


        public void SetGame(PigGame game)
        {
            session.SetObject(GameKey, game);
        }

        public PigGame GetGame() => session.GetObject<PigGame>(GameKey) ?? new PigGame();

        public void NewGame() => SetGame(new PigGame());

        public void Roll()
        {
            var game = GetGame();
            game.Roll();
            SetGame(game);

        }

        public void Hold()
        {
            var game = GetGame();
            game.Hold();
            SetGame(game);
        }

    }
}
