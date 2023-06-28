using Cards.TriggeredAbilities;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM05
{
    class KulusSoulshineEnforcer : Creature
    {
        public KulusSoulshineEnforcer() : base("Kulus, Soulshine Enforcer", 4, 3500, Race.Berserker, Civilization.Light)
        {
            AddTriggeredAbility(new KulusSoulshineEnforcerAbility());
        }
    }

    class KulusSoulshineEnforcerAbility : WhenYouPutThisCreatureIntoTheBattleZoneAbility
    {
        public KulusSoulshineEnforcerAbility() : base(new OneShotEffects.PutTopCardOfDeckIntoManaZoneEffect())
        {
        }

        public KulusSoulshineEnforcerAbility(KulusSoulshineEnforcerAbility ability) : base(ability)
        {
        }

        public override bool CheckInterveningIfClause()
        {
            return Controller.Opponent.ManaZone.Cards.Count > Controller.ManaZone.Cards.Count;
        }

        public override IAbility Copy()
        {
            return new KulusSoulshineEnforcerAbility(this);
        }

        public override string ToString()
        {
            return $"When you put this creature into the battle zone, if your opponent has more cards in his mana zone than you have in yours, {OneShotEffect}";
        }
    }
}
