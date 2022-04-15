using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM09
{
    class SimianWarriorGrash : Creature
    {
        public SimianWarriorGrash() : base("Simian Warrior Grash", 4, 3000, Engine.Subtype.Armorloid, Engine.Civilization.Fire)
        {
            AddTriggeredAbility(new SimianWarriorGrashAbility(new OneShotEffects.YourOpponentChoosesCardsInHisManaZoneAndPutsThemIntoHisGraveyardEffect(1)));
        }
    }

    class SimianWarriorGrashAbility : TriggeredAbilities.DestroyedAbility
    {
        public SimianWarriorGrashAbility(IOneShotEffect effect) : base(effect)
        {
        }

        public SimianWarriorGrashAbility(SimianWarriorGrashAbility ability) : base(ability)
        {
        }

        public override IAbility Copy()
        {
            return new SimianWarriorGrashAbility(this);
        }

        public override string ToString()
        {
            return $"Whenever one of your Armorloids is destroyed, {GetEffectText()}";
        }

        protected override bool TriggersFrom(ICard card, IGame game)
        {
            return card.Owner == Controller && card.HasSubtype(Engine.Subtype.Armorloid);
        }
    }
}
