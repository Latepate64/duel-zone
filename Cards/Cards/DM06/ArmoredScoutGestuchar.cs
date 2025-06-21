using ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM06
{
    class ArmoredScoutGestuchar : Creature
    {
        public ArmoredScoutGestuchar() : base("Armored Scout Gestuchar", 5, 4000, Race.Armorloid, Civilization.Fire)
        {
            AddStaticAbilities(new ArmoredScoutGestucharEffect());
        }
    }

    class ArmoredScoutGestucharEffect : ContinuousEffect, IAbilityAddingEffect
    {
        public ArmoredScoutGestucharEffect()
        {
        }

        public ArmoredScoutGestucharEffect(ArmoredScoutGestucharEffect effect) : base(effect)
        {
        }

        public void AddAbility(IGame game)
        {
            var creature = Source;
            if (game.BattleZone.GetOtherCreatureCount(Controller.Id, creature.Id, Civilization.Fire) == 0)
            {
                creature.AddGrantedAbility(new StaticAbility(new PowerAttackerEffect(3000)));
                creature.AddGrantedAbility(new StaticAbility(new DoubleBreakerEffect()));
            }
        }

        public override IContinuousEffect Copy()
        {
            return new ArmoredScoutGestucharEffect(this);
        }

        public override string ToString()
        {
            return "While you have no other fire creatures in the battle zone, this creature has \"power attacker +3000\" and \"double breaker.\"";
        }
    }
}
