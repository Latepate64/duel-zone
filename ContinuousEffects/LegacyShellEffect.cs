using Engine.Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class LegacyShellEffect : AbilityAddingEffect
{
    public LegacyShellEffect() : base(new StaticAbility(new PowerAttackerEffect(3000)))
    {
    }

    public override IContinuousEffect Copy()
    {
        return new LegacyShellEffect();
    }

    public override string ToString()
    {
        return "Each of your light creatures and fire creatures has \"power attacker +3000.\"";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game)
    {
        return game.BattleZone.GetCreatures(Controller.Id, Civilization.Light, Civilization.Fire);
    }
}
