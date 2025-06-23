using TriggeredAbilities;
using OneShotEffects;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace Cards.DM10;

public sealed class IkazTheSpydroidEffect : CreatureSelectionEffect
{
    public IkazTheSpydroidEffect() : base(1, 1, true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new IkazTheSpydroidEffect();
    }

    public override string ToString()
    {
        return "Choose one of your creatures in the battle zone. Untap it after the battle.";
    }

    protected override void Apply(IGame game, IAbility source, params ICreature[] cards)
    {
        game.AddDelayedTriggeredAbility(new AfterBattleDelayedTriggeredAbility(
            new IkazTheSpydroidUntapEffect(cards.Single()), Ability));
    }

    protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
    {
        return game.BattleZone.GetCreatures(Ability.Controller.Id);
    }
}
