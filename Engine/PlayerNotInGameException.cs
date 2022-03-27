using System;

namespace Engine
{
    class PlayerNotInGameException : Exception
    {
        public PlayerNotInGameException(Guid id) : base($"Player with id {id} not in game.")
        {
        }
    }
}
