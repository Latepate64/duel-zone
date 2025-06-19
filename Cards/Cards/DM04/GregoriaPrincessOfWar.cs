using Abilities.Static;
using Effects.Continuous;
using Engine;
using Engine.ContinuousEffects;
using System.Collections.Generic;

namespace Cards.Cards.DM04
{
    class GregoriaPrincessOfWar : Creature
    {
        public GregoriaPrincessOfWar() : base("Gregoria, Princess of War", 6, 5000, Race.DarkLord, Civilization.Darkness)
        {
            AddStaticAbilities(new GregoriaPrincessOfWarEffect());
        }
    }

    class GregoriaPrincessOfWarEffect : ContinuousEffect, IPowerModifyingEffect, IAbilityAddingEffect
    {
        public GregoriaPrincessOfWarEffect() : base() { }

        public GregoriaPrincessOfWarEffect(GregoriaPrincessOfWarEffect effect) : base(effect)
        {
        }

        public void AddAbility(IGame game)
        {
            GetAffectedCards(game).ForEach(x => x.AddGrantedAbility(new BlockerAbility()));
        }

        public override IContinuousEffect Copy()
        {
            return new GregoriaPrincessOfWarEffect(this);
        }

        public void ModifyPower(IGame game)
        {
            GetAffectedCards(game).ForEach(x => x.IncreasePower(2000));
        }

        public override string ToString()
        {
            return "Each Demon Command in the battle zone gets +2000 power and has \"blocker.\"";
        }

        private static List<Creature> GetAffectedCards(IGame game)
        {
            return [.. game.BattleZone.GetCreatures(Race.DemonCommand)];
        }
    }
}
