using Common;
using Engine;
using Engine.Abilities;
using Common.Choices;
using System.Linq;

namespace Cards.OneShotEffects
{
    public class SoulswapEffect : OneShotEffect
    {
        public SoulswapEffect()
        {
        }

        public SoulswapEffect(SoulswapEffect effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new SoulswapEffect(this);
        }

        public override void Apply(Game game, Ability source)
        {
            // You may choose a creature in the battle zone and put it into its owner's mana zone.
            var player = game.GetPlayer(source.Owner);
            var creatures = game.GetChoosableBattleZoneCreatures(player);
            if (creatures.Any())
            {
                var decision = player.Choose(new CardSelectionInEffect(source.Owner, creatures, 0, 1, "You may choose a creature in the battle zone and put it into its owner's mana zone."), game);
                var toManaCreatures = decision.Decision;
                if (toManaCreatures.Any())
                {
                    var creature = game.GetCard(toManaCreatures.Single());
                    var owner = game.GetPlayer(creature.Owner);
                    game.Move(ZoneType.BattleZone, ZoneType.ManaZone, creature);

                    // If you do, choose a non-evolution creature in that player's mana zone that costs the same as or less than the number of cards in that mana zone. That player puts that creature into the battle zone.
                    var manas = owner.ManaZone.Creatures.Where(c => c.ManaCost <= owner.ManaZone.Cards.Count); //TODO: Check that is not evolution creature
                    if (manas.Any())
                    {
                        var decision2 = player.Choose(new CardSelectionInEffect(source.Owner, manas, 1, 1, "Choose a non-evolution creature in that player's mana zone that costs the same as or less than the number of cards in that mana zone. That player puts that creature into the battle zone."), game);
                        var mana = game.GetCard(decision2.Decision.Single());
                        game.Move(ZoneType.ManaZone, ZoneType.BattleZone, mana);
                    }
                }
            }
        }

        public override string ToString()
        {
            return "You may choose a creature in the battle zone and put it into its owner's mana zone. If you do, choose a non-evolution creature in that player's mana zone that costs the same as or less than the number of cards in that mana zone. That player puts that creature into the battle zone.";
        }
    }
}
