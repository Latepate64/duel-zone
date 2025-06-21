using ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM12
{
    class KilstineNebulaElemental : WaveStrikerCreature
    {
        public KilstineNebulaElemental() : base("Kilstine, Nebula Elemental", 7, 5000, Race.AngelCommand, Civilization.Light)
        {
            AddWaveStrikerAbility(new KilstineNebulaElementalEffect());
        }
    }

    class KilstineNebulaElementalEffect : ContinuousEffect, IPowerModifyingEffect, IAbilityAddingEffect
    {
        public KilstineNebulaElementalEffect() : base()
        {
        }

        public void AddAbility(IGame game)
        {
            GetAffectedCards(game).ForEach(x => { 
                x.AddGrantedAbility(new StaticAbility(new ThisCreatureHasBlockerEffect()));
                x.AddGrantedAbility(new StaticAbility(new DoubleBreakerEffect()));
                });
        }

        public override IContinuousEffect Copy()
        {
            return new KilstineNebulaElementalEffect();
        }

        public void ModifyPower(IGame game)
        {
            GetAffectedCards(game).ForEach(x => x.IncreasePower(5000));
        }

        public override string ToString()
        {
            return "Each of your other creatures in battle zone gets +5000 power and has \"blocker\" and \"double breaker\".";
        }

        private List<Creature> GetAffectedCards(IGame game)
        {
            return [.. game.BattleZone.GetCreatures(Controller.Id).Where(x => !IsSourceOfAbility(x))];
        }
    }
}
