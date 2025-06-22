using Engine.Abilities;
using Interfaces;

namespace Cards.DM10;

public sealed class SoulswapEffect : OneShotEffect
{
    public override IOneShotEffect Copy()
    {
        return new SoulswapEffect();
    }

    public override void Apply(IGame game)
    {
        var creature = Controller.ChooseCreatureInBattleZoneOptionally(
            game, "You may choose a creature in the battle zone and put it into its owner's mana zone.");
        if (creature != null)
        {
            Controller.PutCreatureFromBattleZoneIntoItsOwnersManaZone(creature, game, Ability);
            var manas = creature.Owner.ManaZone.GetNonEvolutionCreaturesThatCostSameOrLessThan(
                creature.Owner.ManaZone.Size);
            var mana = Controller.ChooseCard(
                manas,
                "Choose a non-evolution creature in that player's mana zone that costs the same as or less than the number of cards in that mana zone. That player puts that creature into the battle zone.");
            mana?.Owner.PutCreatureFromOwnManaZoneIntoBattleZone(mana, game, Ability);
        }
    }

    public override string ToString()
    {
        return "You may choose a creature in the battle zone and put it into its owner's mana zone. If you do, choose a non-evolution creature in that player's mana zone that costs the same as or less than the number of cards in that mana zone. That player puts that creature into the battle zone.";
    }
}