using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM10
{
    class EarthRipperTalonOfRage : EvolutionCreature
    {
        public EarthRipperTalonOfRage() : base("Earth Ripper, Talon of Rage", 4, 6000, Race.BeastFolk, Civilization.Nature)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new EarthRipperTalonOfRageEffect());
            AddDoubleBreakerAbility();
        }
    }

    class EarthRipperTalonOfRageEffect : OneShotEffects.ManaRecoveryAreaOfEffect
    {
        public EarthRipperTalonOfRageEffect() : base()
        {
        }

        public override IOneShotEffect Copy()
        {
            return new EarthRipperTalonOfRageEffect();
        }

        public override string ToString()
        {
            return "Return all tapped cards from your mana zone to your hand.";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return Applier.ManaZone.TappedCards;
        }
    }
}
