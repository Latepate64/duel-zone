using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class TanzanyteTheAwakenerEffect : CreatureSelectionEffect
{
    public TanzanyteTheAwakenerEffect() : base(1, 1, true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new TanzanyteTheAwakenerEffect();
    }

    public override string ToString()
    {
        return "Choose a creature in your graveyard. Return all creatures that have that name from your graveyard to your hand.";
    }

    protected override void Apply(IGame game, IAbility source, params ICreature[] cards)
    {
        var names = cards.Select(x => x.Name).Distinct();
        var creatures = Controller.Graveyard.Creatures.Where(x => names.Contains(x.Name));
        game.Move(Ability, ZoneType.Graveyard, ZoneType.Hand, [.. creatures]);
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return Controller.Graveyard.Creatures;
    }
}
