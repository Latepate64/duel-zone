using System;
using System.Collections.Generic;

namespace Engine.Zones
{
    public interface IBattleZone : IZone
    {
        IEnumerable<ICard> GetChoosableCreatures(IGame game, Guid owner);
    }
}