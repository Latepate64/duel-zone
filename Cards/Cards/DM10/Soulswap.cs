using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM10
{
    class Soulswap : Spell
    {
        public Soulswap() : base("Soulswap", 3, Civilization.Nature)
        {
            AddShieldTrigger();
            AddSpellAbilities(new SoulswapEffect());
        }

        class SoulswapEffect : OneShotEffect
        {
            public override IOneShotEffect Copy()
            {
                return new SoulswapEffect();
            }

            public override void Apply(IGame game)
            {
                ICard creature = Controller.ChooseCreatureInBattleZoneOptionally(game, "You may choose a creature in the battle zone and put it into its owner's mana zone.");
                if (creature != null)
                {
                    Controller.PutCreatureFromBattleZoneIntoItsOwnersManaZone(creature, game, Ability);
                    IEnumerable<ICard> manas = creature.Owner.ManaZone.GetNonEvolutionCreaturesThatCostSameOrLessThan(creature.Owner.ManaZone.Cards.Count);
                    ICard mana = Controller.ChooseCard(manas, "Choose a non-evolution creature in that player's mana zone that costs the same as or less than the number of cards in that mana zone. That player puts that creature into the battle zone.");
                    mana?.Owner.PutCreatureFromOwnManaZoneIntoBattleZone(mana, game, Ability);
                }
            }

            public override string ToString()
            {
                return "You may choose a creature in the battle zone and put it into its owner's mana zone. If you do, choose a non-evolution creature in that player's mana zone that costs the same as or less than the number of cards in that mana zone. That player puts that creature into the battle zone.";
            }
        }
    }
}
