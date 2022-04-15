using Common;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM05
{
    class DeathCruzerTheAnnihilator : Creature
    {
        public DeathCruzerTheAnnihilator() : base("Death Cruzer, the Annihilator", 7, 13000, Engine.Subtype.DemonCommand, Civilization.Darkness)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new DeathCruzerTheAnnihilatorEffect());
            AddTripleBreakerAbility();
        }
    }

    class DeathCruzerTheAnnihilatorEffect : OneShotEffects.DestroyAreaOfEffect
    {
        public DeathCruzerTheAnnihilatorEffect() : base()
        {
        }

        public override IOneShotEffect Copy()
        {
            return new DeathCruzerTheAnnihilatorEffect();
        }

        public override string ToString()
        {
            return "Destroy all your other creatures.";
        }

        protected override IEnumerable<Engine.ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetOtherCreatures(source.Controller, source.Source);
        }
    }
}
