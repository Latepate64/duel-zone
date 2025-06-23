using Engine;
using Engine.GameEvents;
using Interfaces;
using Interfaces.ContinuousEffects;
using System.Linq;

namespace ContinuousEffects;

public sealed class PetrovaBuffEffect : ContinuousEffect, IPowerModifyingEffect, IExpirable
{
    private readonly Race _race;

    public PetrovaBuffEffect(Race _race)
    {
        this._race = _race;
    }

    public PetrovaBuffEffect(PetrovaBuffEffect effect) : base(effect)
    {
        _race = effect._race;
    }

    public override IContinuousEffect Copy()
    {
        return new PetrovaBuffEffect(this);
    }

    public void ModifyPower(IGame game)
    {
        game.BattleZone.GetCreatures(_race).ToList().ForEach(x => x.IncreasePower(4000));
    }

    public bool ShouldExpire(IGameEvent gameEvent, IGame game)
    {
        var sourceCard = Source;
        return gameEvent is CardMovedEvent e && e.CardInSourceZone == sourceCard.Id && e.Source == ZoneType.BattleZone;
    }

    public override string ToString()
    {
        return $"{_race}s get +4000 power.";
    }
}
