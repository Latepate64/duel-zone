using OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace Cards.DM07
{
    sealed class VacuumGel : Spell
    {
        public VacuumGel() : base("Vacuum Gel", 4, Civilization.Darkness)
        {
            AddSpellAbilities(new VacuumGelEffect());
        }
    }

    sealed class VacuumGelEffect : DestroyEffect
    {
        public VacuumGelEffect() : base(1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new VacuumGelEffect();
        }

        public override string ToString()
        {
            return "Destroy one of your opponent's untapped light or untapped nature creatures.";
        }

        protected override IEnumerable<ICreature> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableUntappedCreaturesControlledByPlayer(game, GetOpponent(game).Id).Where(x => x.HasCivilization(Civilization.Light, Civilization.Nature));
        }
    }
}
