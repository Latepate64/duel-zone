using Common;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM04
{
    class GregoriaPrincessOfWar : Creature
    {
        public GregoriaPrincessOfWar() : base("Gregoria, Princess of War", 6, 5000, Subtype.DarkLord, Civilization.Darkness)
        {
            AddAbilities(new GregoriaPrincessOfWarAbility());
        }
    }

    class GregoriaPrincessOfWarAbility : Engine.Abilities.StaticAbility
    {
        public GregoriaPrincessOfWarAbility() : base(new GregoriaPrincessOfWarEffect())
        {
        }
    }

    class GregoriaPrincessOfWarEffect : ContinuousEffect, IPowerModifyingEffect, IAbilityAddingEffect
    {
        public GregoriaPrincessOfWarEffect() : base(new CardFilters.BattleZoneSubtypeCreatureFilter(Subtype.DemonCommand)) { }

        public GregoriaPrincessOfWarEffect(GregoriaPrincessOfWarEffect effect) : base(effect)
        {
        }

        public void AddAbility(IGame game)
        {
            GetAffectedCards(game).ToList().ForEach(x => x.AddGrantedAbility(new StaticAbilities.BlockerAbility()));
        }

        public override IContinuousEffect Copy()
        {
            return new GregoriaPrincessOfWarEffect(this);
        }

        public void ModifyPower(IGame game)
        {
            GetAffectedCards(game).ToList().ForEach(x => x.Power += 2000);
        }

        public override string ToString()
        {
            return "Each Demon Command in the battle zone gets +2000 power and has \"blocker.\"";
        }
    }
}
