using Cards.ContinuousEffects;
using Common;
using Engine.ContinuousEffects;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM03
{
    class ÜberdragonJabaha : EvolutionCreature
    {
        public ÜberdragonJabaha() : base("Überdragon Jabaha", 7, 11000, Engine.Subtype.ArmoredDragon, Civilization.Fire)
        {
            AddStaticAbilities(new ÜberdragonJabahaEffect());
            AddDoubleBreakerAbility();
        }
    }

    class ÜberdragonJabahaEffect : AbilityAddingEffect
    {
        public ÜberdragonJabahaEffect() : base(new StaticAbilities.PowerAttackerAbility(2000)) { }

        public override IContinuousEffect Copy()
        {
            return new ÜberdragonJabahaEffect();
        }

        public override string ToString()
        {
            return "Each of your other fire creatures in the battle zone has \"power attacker +2000.\"";
        }

        protected override IEnumerable<Engine.ICard> GetAffectedCards(Engine.IGame game)
        {
            return game.BattleZone.GetCreatures(GetController(game).Id).Where(x => !IsSourceOfAbility(x, game) && x.HasCivilization(Civilization.Fire));
        }
    }
}
