using Cards.ContinuousEffects;
using Common;
using Engine;
using Engine.ContinuousEffects;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM04
{
    class GregoriaPrincessOfWar : Creature
    {
        public GregoriaPrincessOfWar() : base("Gregoria, Princess of War", 6, 5000, Subtype.DarkLord, Civilization.Darkness)
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
            GetAffectedCards(game).ForEach(x => x.AddGrantedAbility(new StaticAbilities.BlockerAbility()));
        }

        public override IContinuousEffect Copy()
        {
            return new GregoriaPrincessOfWarEffect(this);
        }

        public void ModifyPower(IGame game)
        {
            GetAffectedCards(game).ForEach(x => x.Power += 2000);
        }

        public override string ToString()
        {
            return "Each Demon Command in the battle zone gets +2000 power and has \"blocker.\"";
        }

        private static List<Engine.ICard> GetAffectedCards(IGame game)
        {
            return game.BattleZone.Creatures.Where(x => x.HasSubtype(Subtype.DemonCommand)).ToList();
        }
    }
}
