using Engine.Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class MykeesPliersEffect : AbilityAddingEffect
{
    public MykeesPliersEffect() : base(new StaticAbility(new ThisCreatureHasSpeedAttackerEffect()))
    {
    }

    public override IContinuousEffect Copy()
    {
        return new MykeesPliersEffect();
    }

    public override string ToString()
    {
        return "Each of your darkness creatures and nature creatures in the battle zone has \"speed attacker.\"";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game)
    {
        return game.BattleZone.GetCreatures(Controller.Id, Civilization.Water, Civilization.Nature);
    }
}
