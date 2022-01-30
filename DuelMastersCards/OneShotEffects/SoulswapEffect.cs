using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using DuelMastersModels.Zones;
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
                var decision = player.Choose(new GuidSelection(source.Owner, creatures, 0, 1));
                var toManaCreatures = decision.Decision;
                if (toManaCreatures.Any())
                {
                    var creature = game.GetCard(toManaCreatures.Single());
                    var owner = game.GetPlayer(creature.Owner);
                    game.Move(creature, ZoneType.BattleZone, ZoneType.ManaZone);

                    // If you do, choose a non-evolution creature in that player's mana zone that costs the same as or less than the number of cards in that mana zone. That player puts that creature into the battle zone.
                    var manas = owner.ManaZone.Creatures.Where(c => c.ManaCost <= owner.ManaZone.Cards.Count); //TODO: Check that is not evolution creature
                    if (manas.Any())
                    {
                        var decision2 = player.Choose(new GuidSelection(source.Owner, manas, 1, 1));
                        var mana = game.GetCard(decision2.Decision.Single());
                        game.Move(mana, ZoneType.ManaZone, ZoneType.BattleZone);
                    }
                }
            }
        }
    }
}
