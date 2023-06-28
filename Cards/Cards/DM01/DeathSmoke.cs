using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM01
{
    class DeathSmoke : Spell
    {
        public DeathSmoke() : base("Death Smoke", 4, Civilization.Darkness)
        {
            AddSpellAbilities(new DeathSmokeEffect());
        }
    }

    class DeathSmokeEffect : DestroyEffect
    {
        public DeathSmokeEffect() : base(1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new DeathSmokeEffect();
        }

        public override string ToString()
        {
            return "Destroy one of your opponent's untapped creatures.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableUntappedCreaturesControlledByChoosersOpponent(Applier);
        }
    }
}
