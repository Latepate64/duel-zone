using Interfaces;

namespace OneShotEffects;

public sealed class RoyalDurianEffect : OneShotEffect
{
    public RoyalDurianEffect()
    {
    }

    public RoyalDurianEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        game.BattleZone.Creatures.Where(x => x.Supertypes.Contains(Supertype.Evolution)).ToList()
            .ForEach(x => game.MoveTopCard(x, ZoneType.ManaZone, Ability));
    }

    public override IOneShotEffect Copy()
    {
        return new RoyalDurianEffect(this);
    }

    public override string ToString()
    {
        return "Put the top card of each evolution creature from the battle zone into its owner's mana zone.";
    }
}
