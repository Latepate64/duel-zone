using Engine;
using Engine.Abilities;

namespace OneShotEffects;

public class PutOneOfYourCreaturesFromTheBattleZoneIntoYourManaZoneEffect : ManaFeedEffect
{
    public PutOneOfYourCreaturesFromTheBattleZoneIntoYourManaZoneEffect() : base(1, 1, true)
    {
    }

    public PutOneOfYourCreaturesFromTheBattleZoneIntoYourManaZoneEffect(
        PutOneOfYourCreaturesFromTheBattleZoneIntoYourManaZoneEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new PutOneOfYourCreaturesFromTheBattleZoneIntoYourManaZoneEffect(this);
    }

    public override string ToString()
    {
        return "Put one of your creatures from the battle zone into your mana zone.";
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetCreatures(Ability.Controller.Id);
    }
}
