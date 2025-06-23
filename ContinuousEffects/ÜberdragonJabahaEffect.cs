using Engine.Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class ÜberdragonJabahaEffect : AbilityAddingEffect
{
    public ÜberdragonJabahaEffect() : base(new StaticAbility(new PowerAttackerEffect(2000))) { }

    public override IContinuousEffect Copy()
    {
        return new ÜberdragonJabahaEffect();
    }

    public override string ToString()
    {
        return "Each of your other fire creatures in the battle zone has \"power attacker +2000.\"";
    }

    protected override IEnumerable<ICreature> GetAffectedCards(IGame game)
    {
        return game.BattleZone.GetCreatures(Controller.Id).Where(
            x => !IsSourceOfAbility(x) && x.HasCivilization(Civilization.Fire));
    }
}
