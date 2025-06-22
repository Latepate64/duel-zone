using ContinuousEffects;
using Engine;
using Engine.Abilities;
using Interfaces;
using Interfaces.ContinuousEffects;
using System.Linq;

namespace Cards.DM10
{
    sealed class TechnoTotem : Creature
    {
        public TechnoTotem() : base("Techno Totem", 4, 5000, Race.MysteryTotem, Civilization.Light, Civilization.Nature)
        {
            AddStaticAbilities(new TechnoTotemEffect());
            AddAbilities(new TapAbility(new OneShotEffects.ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect()));
        }
    }

    sealed class TechnoTotemEffect : ContinuousEffect, IAbilityAddingEffect
    {
        public TechnoTotemEffect()
        {
        }

        public TechnoTotemEffect(TechnoTotemEffect effect) : base(effect)
        {
        }

        public void AddAbility(IGame game)
        {
            if (Source.Tapped)
            {
                game.BattleZone.GetOtherCreatures(Controller.Id, Source.Id).ToList().ForEach(x => x.AddGrantedAbility(
                    new StaticAbility(new PowerAttackerEffect(1500))));
            }
        }

        public override IContinuousEffect Copy()
        {
            return new TechnoTotemEffect(this);
        }

        public override string ToString()
        {
            return "While this creature is tapped, each of your other creatures has \"power attacker +1500.\"";
        }
    }
}
