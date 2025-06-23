using Engine.GameEvents;
using Interfaces;

namespace GameEvents;

public sealed class PetrovaEvent : CardMovedEvent
{
    readonly Race _race;

    public PetrovaEvent(PetrovaEvent e) : base(e)
    {
        _race = e._race;
    }

    public PetrovaEvent(CardMovedEvent move, Race race) : base(move)
    {
        _race = race;
    }

    public override void Happen(IGame game)
    {
        base.Happen(game);
        throw new NotImplementedException();
        // game.AddContinuousEffects(null, new PetrovaBuffEffect(_race));
    }

    public override string ToString()
    {
        return $"As you put this creature into the battle zone, {_race}s get +4000 power.";
    }
}
