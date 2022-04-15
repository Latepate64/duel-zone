using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM10
{
    class Soulswap : Spell
    {
        public Soulswap() : base("Soulswap", 3, Common.Civilization.Nature)
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

            public override object Apply(IGame game, IAbility source)
            {
                // You may choose a creature in the battle zone and put it into its owner's mana zone.
                var creatures = game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, source.Controller);
                if (creatures.Any())
                {
                    var creature = source.GetController(game).ChooseCardOptionally(creatures, "You may choose a creature in the battle zone and put it into its owner's mana zone.");
                    if (creature != null)
                    {
                        game.Move(ZoneType.BattleZone, ZoneType.ManaZone, creature);

                        // If you do, choose a non-evolution creature in that player's mana zone that costs the same as or less than the number of cards in that mana zone. That player puts that creature into the battle zone.
                        var manas = game.GetPlayer(creature.Owner).ManaZone.Creatures.Where(c => !c.IsEvolutionCreature && c.ManaCost <= game.GetPlayer(creature.Owner).ManaZone.Cards.Count);
                        if (manas.Any())
                        {
                            var mana = source.GetController(game).ChooseCard(manas, "Choose a non-evolution creature in that player's mana zone that costs the same as or less than the number of cards in that mana zone. That player puts that creature into the battle zone.");
                            game.Move(ZoneType.ManaZone, ZoneType.BattleZone, mana);
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            public override string ToString()
            {
                return "You may choose a creature in the battle zone and put it into its owner's mana zone. If you do, choose a non-evolution creature in that player's mana zone that costs the same as or less than the number of cards in that mana zone. That player puts that creature into the battle zone.";
            }
        }
    }
}
