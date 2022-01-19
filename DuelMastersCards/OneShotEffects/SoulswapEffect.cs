using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using DuelMastersModels.Zones;
using System.Linq;

namespace DuelMastersCards.OneShotEffects
{
    public class SoulswapEffect : OneShotEffect
    {
        public SoulswapEffect()
        {
        }

        public SoulswapEffect(SoulswapEffect effect) : base(effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new SoulswapEffect(this);
        }

        public override void Apply(Duel duel)
        {
            // You may choose a creature in the battle zone and put it into its owner's mana zone.
            var player = duel.GetPlayer(Controller);
            var creatures = duel.GetChoosableCreaturePermanents(player);
            if (creatures.Any())
            {
                var decision = player.Choose(new GuidSelection(Controller, creatures, 0, 1));
                var toManaCreatures = decision.Decision;
                if (toManaCreatures.Any())
                {
                    var creature = duel.GetPermanent(toManaCreatures.Single());
                    var owner = duel.GetPlayer(creature.Owner);
                    duel.Move(creature, ZoneType.BattleZone, ZoneType.ManaZone);

                    // If you do, choose a non-evolution creature in that player's mana zone that costs the same as or less than the number of cards in that mana zone. That player puts that creature into the battle zone.
                    var manas = owner.ManaZone.Creatures.Where(c => c.ManaCost <= owner.ManaZone.Cards.Count); //TODO: Check that is not evolution creature
                    if (manas.Any())
                    {
                        var decision2 = player.Choose(new GuidSelection(Controller, manas, 1, 1));
                        var mana = duel.GetCard(decision2.Decision.Single());
                        duel.Move(mana, ZoneType.ManaZone, ZoneType.BattleZone);
                    }
                }
            }
        }
    }
}
