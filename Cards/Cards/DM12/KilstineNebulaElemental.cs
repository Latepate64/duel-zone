using Common;
using Engine;
using Engine.ContinuousEffects;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM12
{
    class KilstineNebulaElemental : WaveStrikerCreature
    {
        public KilstineNebulaElemental() : base("Kilstine, Nebula Elemental", 7, 5000, Subtype.AngelCommand, Civilization.Light)
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
                x.AddGrantedAbility(new StaticAbilities.BlockerAbility());
                x.AddGrantedAbility(new StaticAbilities.DoubleBreakerAbility());
                });
        }

        public override IContinuousEffect Copy()
        {
            return new KilstineNebulaElementalEffect();
        }

        public void ModifyPower(IGame game)
        {
            GetAffectedCards(game).ForEach(x => x.Power += 5000);
        }

        public override string ToString()
        {
            return "Each of your other creatures in battle zone gets +5000 power and has \"blocker\" and \"double breaker\".";
        }

        private List<Engine.ICard> GetAffectedCards(IGame game)
        {
            return game.BattleZone.GetCreatures(Controller).Where(x => !IsSourceOfAbility(x, game)).ToList();
        }
    }
}
