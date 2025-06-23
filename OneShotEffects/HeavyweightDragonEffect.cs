using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class HeavyweightDragonEffect : CreatureSelectionEffect
{
    public HeavyweightDragonEffect() : base(0, 2, true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new HeavyweightDragonEffect();
    }

    public override string ToString()
    {
        return "Choose up to 2 of your opponent's tapped creatures in the battle zone. If they have total power less than this creature's power, destroy them.";
    }

    protected override void Apply(IGame game, IAbility source, params ICreature[] cards)
    {
        if (cards.Sum(x => x.Power) < (Ability.Source as ICreature).Power)
        {
            game.Destroy(source, cards);
        }
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, GetOpponent(game).Id).Where(x => x.Tapped);
    }
}
