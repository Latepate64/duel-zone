using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class AmbushScorpionEffect : CardMovingChoiceEffect
    {
        public AmbushScorpionEffect(AmbushScorpionEffect effect) : base(effect)
        {
        }

        public AmbushScorpionEffect() : base(new CardFilters.OwnersManaZoneCardFilter { CardName = "Ambush Scorpion" }, 0, 1, true, Common.ZoneType.ManaZone, Common.ZoneType.BattleZone)
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
