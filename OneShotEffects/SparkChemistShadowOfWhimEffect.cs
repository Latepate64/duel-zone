using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class SparkChemistShadowOfWhimEffect : ManaRecoveryAreaOfEffect
{
    public SparkChemistShadowOfWhimEffect() : base()
    {
    }

    public override IOneShotEffect Copy()
    {
        return new SparkChemistShadowOfWhimEffect();
    }

    public override string ToString()
    {
        return "Return all the cards from your mana zone to your hand.";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return Controller.ManaZone.Cards;
    }
}
