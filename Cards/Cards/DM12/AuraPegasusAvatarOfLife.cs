using Cards.TriggeredAbilities;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM12
{
    class AuraPegasusAvatarOfLife : VortexEvolutionCreature
    {
        public AuraPegasusAvatarOfLife() : base("Aura Pegasus, Avatar of Life", 6, 12000, Civilization.Light, Civilization.Nature, Race.Pegasus, Race.HornedBeast, Race.AngelCommand)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksOrLeavesTheBattleZoneAbility(new AuraPegasusEffect()));
            AddTripleBreakerAbility();
        }
    }

    class AuraPegasusEffect : OneShotEffect
    {
        public AuraPegasusEffect()
        {
        }

        public AuraPegasusEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var cards = Applier.RevealTopCardsOfDeck(1);
            game.Move(Ability, ZoneType.Deck, cards.All(x => x.IsNonEvolutionCreature) ? ZoneType.BattleZone : ZoneType.Hand, cards.ToArray());
        }

        public override IOneShotEffect Copy()
        {
            return new AuraPegasusEffect(this);
        }

        public override string ToString()
        {
            return "Reveal the top card of your deck. If it's a non-evolution creature, put it into battle zone. Otherwise, put it to your hand.";
        }
    }
}
