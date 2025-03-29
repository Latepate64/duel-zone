using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM12
{
    class KilstineNebulaElemental : WaveStrikerCreature
    {
        public KilstineNebulaElemental() : base("Kilstine, Nebula Elemental", 7, 5000, Race.AngelCommand, Civilization.Light)
        {
            AddWaveStrikerAbility(new KilstineNebulaElementalEffect(5000));
        }
    }

    public class KilstineNebulaElementalEffect : ContinuousEffect, IPowerModifyingEffect, IAbilityAddingEffect
    {
        private readonly int power;

        public KilstineNebulaElementalEffect(int power) : base()
        {
            this.power = power;
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
            return new KilstineNebulaElementalEffect(power);
        }

        public void ModifyPower(IGame game)
        {
            GetAffectedCards(game).ForEach(x => x.Power += power);
        }

        public override string ToString()
        {
            return "Each of your other creatures in battle zone gets +5000 power and has \"blocker\" and \"double breaker\".";
        }

        private List<ICard> GetAffectedCards(IGame game)
        {
            return game.BattleZone.GetCreatures(Controller.Id).Where(x => !IsSourceOfAbility(x)).ToList();
        }
    }
}
