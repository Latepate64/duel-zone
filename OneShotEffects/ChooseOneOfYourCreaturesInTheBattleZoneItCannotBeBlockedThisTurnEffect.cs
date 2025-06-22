using ContinuousEffects;
using Interfaces;

namespace OneShotEffects;

public sealed class ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect : CreatureSelectionEffect
{
    public ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect() : base(1, 1, true)
    {
    }

    public ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect(
        ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect effect) : base(effect)
    {
    }

    public override ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect Copy()
    {
        return new ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect(this);
    }

    public override string ToString()
    {
        return "Choose one of your creatures in the battle zone. It can't be blocked this turn.";
    }

    protected override void Apply(IGame game, IAbility source, params ICreature[] cards)
    {
        game.AddContinuousEffects(Ability, new ChosenCreaturesCannotBeBlockedThisTurnEffect(cards));
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetCreatures(Ability.Controller.Id);
    }
}
