using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM11
{
    class RoyalDurian : Creature
    {
        public RoyalDurian() : base("Royal Durian", 5, 1000, Race.WildVeggies, Civilization.Nature)
        {
            AddShieldTrigger();
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new RoyalDurianEffect());
        }
    }

    class RoyalDurianEffect : OneShotEffect
    {
        public RoyalDurianEffect()
        {
        }

        public RoyalDurianEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply()
        {
            Game.BattleZone.EvolutionCreatures.ToList().ForEach(x => Game.MoveTopCard(x, ZoneType.ManaZone, Ability));
        }

        public override IOneShotEffect Copy()
        {
            return new RoyalDurianEffect(this);
        }

        public override string ToString()
        {
            return "Put the top card of each evolution creature from the battle zone into its owner's mana zone.";
        }
    }
}
