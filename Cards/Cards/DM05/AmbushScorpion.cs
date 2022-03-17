using Cards.OneShotEffects;
using Common;
using Engine.Abilities;

namespace Cards.Cards.DM05
{
    class AmbushScorpion : Creature
    {
        public AmbushScorpion() : base("Ambush Scorpion", 5, 3000, Subtype.GiantInsect, Civilization.Nature)
        {
            AddAbilities(new StaticAbilities.PowerAttackerAbility(3000));

            // When this creature is destroyed, you may choose an Ambush Scorpion in your mana zone and put it into the battle zone.
            AddAbilities(new TriggeredAbilities.DestroyedAbility(new AmbushScorpionEffect()));
        }
    }

    class AmbushScorpionEffect : CardMovingChoiceEffect
    {
        public AmbushScorpionEffect(AmbushScorpionEffect effect) : base(effect)
        {
        }

        public AmbushScorpionEffect() : base(new CardFilters.OwnersManaZoneNamedCardFilter("Ambush Scorpion"), 0, 1, true, ZoneType.ManaZone, ZoneType.BattleZone)
        {
        }

        public override OneShotEffect Copy()
        {
            return new AmbushScorpionEffect(this);
        }

        public override string ToString()
        {
            return "You may choose an Ambush Scorpion in your mana zone and put it into the battle zone.";
        }
    }
}
