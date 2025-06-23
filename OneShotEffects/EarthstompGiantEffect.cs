using Interfaces;

namespace OneShotEffects;

public sealed class EarthstompGiantEffect : ManaRecoveryAreaOfEffect
{
    public EarthstompGiantEffect() : base()
    {
    }

    public override IOneShotEffect Copy()
    {
        return new EarthstompGiantEffect();
    }

    public override string ToString()
    {
        return "Return all creatures from your mana zone to your hand.";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return Controller.ManaZone.Creatures;
    }
}
