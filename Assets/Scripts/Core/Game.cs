using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Resource;

namespace Assets.Scripts.Core
{
    class Game
    {
        private static Game game;
        public State state;

        private Game()
        {
            state = State.Started;
        }

        public static Game getGame()
        {
            if (game == null)
                game = new Game();

            return game;
        }

        public State getState()
        {
            return state;
        }

        public void setState(State state)
        {
            this.state = state;
        }
    }
}
