using Cards.ContinuousEffects;
using Cards.StaticAbilities;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

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
            var creature = GetSourceCard(game);
            if (!game.BattleZone.GetOtherCreatures(GetController(game).Id, creature.Id, Civilization.Fire).Any())
            {
                creature.AddGrantedAbility(new PowerAttackerAbility(3000));
                creature.AddGrantedAbility(new DoubleBreakerAbility());
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
