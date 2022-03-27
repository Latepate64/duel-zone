using Common;
using Common.Choices;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM10
{
    class Soulswap : Spell
    {
        public Soulswap() : base("Soulswap", 3, Common.Civilization.Nature)
        {
            ShieldTrigger = true;
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
                var creatures = game.GetChoosableBattleZoneCreatures(source.GetController(game));
                if (creatures.Any())
                {
                    var decision = source.GetController(game).Choose(new BoundedCardSelectionInEffect(source.Controller, creatures, 0, 1, "You may choose a creature in the battle zone and put it into its owner's mana zone."), game);
                    var toManaCreatures = decision.Decision;
                    if (toManaCreatures.Any())
                    {
                        var creature = game.GetCard(toManaCreatures.Single());
                        game.Move(ZoneType.BattleZone, ZoneType.ManaZone, creature);

                        // If you do, choose a non-evolution creature in that player's mana zone that costs the same as or less than the number of cards in that mana zone. That player puts that creature into the battle zone.
                        var manas = game.GetPlayer(creature.Owner).ManaZone.Creatures.Where(c => !c.IsEvolutionCreature && c.ManaCost <= game.GetPlayer(creature.Owner).ManaZone.Cards.Count);
                        if (manas.Any())
                        {
                            var decision2 = source.GetController(game).Choose(new BoundedCardSelectionInEffect(source.Controller, manas, 1, 1, "Choose a non-evolution creature in that player's mana zone that costs the same as or less than the number of cards in that mana zone. That player puts that creature into the battle zone."), game);
                            var mana = game.GetCard(decision2.Decision.Single());
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
