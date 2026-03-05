using Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class FrostSpecterShadowOfAgeEffect : AbilityAddingEffect
{
    public FrostSpecterShadowOfAgeEffect() : base(new StaticAbility(new ThisCreatureHasSlayerEffect()))
    {
    }

    public override IContinuousEffect Copy()
    {
        return new FrostSpecterShadowOfAgeEffect();
    }

    public override string ToString()
    {
        return "Each of your Ghosts in the battle zone has \"slayer.\"";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game)
    {
        return game.BattleZone.GetCreatures(Controller.Id, Race.Ghost);
    }
}
