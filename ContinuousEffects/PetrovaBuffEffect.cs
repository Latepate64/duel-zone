using Interfaces;
using Interfaces.ContinuousEffects;

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
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return $"{_race}s get +4000 power.";
    }
}
