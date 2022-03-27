using Cards.TriggeredAbilities;
using Common;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM05
{
    class KulusSoulshineEnforcer : Creature
    {
        public KulusSoulshineEnforcer() : base("Kulus, Soulshine Enforcer", 4, 3500, Subtype.Berserker, Civilization.Light)
        {
            AddAbilities(new KulusSoulshineEnforcerAbility());
        }
    }

    class KulusSoulshineEnforcerAbility : WhenYouPutThisCreatureIntoTheBattleZoneAbility
    {
        public KulusSoulshineEnforcerAbility() : base(new OneShotEffects.PutTopCardsOfDeckIntoManaZoneEffect(1))
        {
        }

        public KulusSoulshineEnforcerAbility(KulusSoulshineEnforcerAbility ability) : base(ability)
        {
        }

        public override bool CheckInterveningIfClause(IGame game)
        {
            var player = game.GetPlayer(Controller);
            if (player != null)
            {
                var opponent = game.GetOpponent(player);
                return opponent != null && opponent.ManaZone.Cards.Count > player.ManaZone.Cards.Count;
            }
            return false;
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
