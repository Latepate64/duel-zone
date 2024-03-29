﻿using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM07
{
    class Cratersaur : Creature
    {
        public Cratersaur() : base("Cratersaur", 3, 2000, Race.RockBeast, Civilization.Fire)
        {
            AddStaticAbilities(new CratersaurEffect());
        }
    }

    class CratersaurEffect : ContinuousEffect, ICanAttackUntappedCreaturesEffect, IAbilityAddingEffect
    {
        public CratersaurEffect() : base()
        {
        }

        public void AddAbility(IGame game)
        {
            if (YouHaveNoShields(game))
            {
                Source.AddGrantedAbility(new StaticAbilities.PowerAttackerAbility(3000));
            }
        }

        public bool CanAttackUntappedCreature(ICard attacker, ICard targetOfAttack, IGame game)
        {
            return YouHaveNoShields(game) && IsSourceOfAbility(attacker);
        }

        public override IContinuousEffect Copy()
        {
            return new CratersaurEffect();
        }

        public override string ToString()
        {
            return "While you have no shields, this creature can attack untapped creatures and has \"Power attacker +3000.\"";
        }

        private bool YouHaveNoShields(IGame game)
        {
            return !Ability.Controller.ShieldZone.HasCards;
        }
    }
}
