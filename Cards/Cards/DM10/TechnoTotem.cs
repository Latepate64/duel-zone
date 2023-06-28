using Cards.ContinuousEffects;
using Cards.StaticAbilities;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM10
{
    class TechnoTotem : Creature
    {
        public TechnoTotem() : base("Techno Totem", 4, 5000, Race.MysteryTotem, Civilization.Light, Civilization.Nature)
        {
            AddStaticAbilities(new TechnoTotemEffect());
            AddTapAbility(new OneShotEffects.ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect());
        }
    }

    class TechnoTotemEffect : ContinuousEffect, IAbilityAddingEffect
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
                game.BattleZone.GetOtherCreatures(Applier, Source).ToList().ForEach(x => x.AddGrantedAbility(new PowerAttackerAbility(1500)));
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
