using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM12
{
    class PhantomachTheGigatrooper : EvolutionCreature
    {
        public PhantomachTheGigatrooper() : base("Phantomach, the Gigatrooper", 5, 6000, Engine.Subtype.Chimera, Engine.Subtype.Armorloid, Engine.Civilization.Darkness, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new PhantomachPowerEffect(), new PhantomachDoubleBreakerEffect());
        }
    }

    class PhantomachPowerEffect : ContinuousEffect, IPowerModifyingEffect
    {
        public PhantomachPowerEffect() : base()
        {
        }

        public override IContinuousEffect Copy()
        {
            return new PhantomachPowerEffect();
        }

        public void ModifyPower(IGame game)
        {
            game.BattleZone.GetCreatures(GetController(game).Id).Where(x => !IsSourceOfAbility(x, game) && (x.HasSubtype(Engine.Subtype.Chimera) || x.HasSubtype(Engine.Subtype.Armorloid))).ToList().ForEach(x => x.Power += 2000);
        }

        public override string ToString()
        {
            return "Each of your other Chimeras and Armorloids in the battle zone gain +2000 power.";
        }
    }

    class PhantomachDoubleBreakerEffect : AbilityAddingEffect
    {
        public PhantomachDoubleBreakerEffect() : base(new StaticAbilities.DoubleBreakerAbility())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new PhantomachDoubleBreakerEffect();
        }

        public override string ToString()
        {
            return "Each of your Chimeras and Armorloids in the battle zone has \"double breaker.\"";
        }

        protected override IEnumerable<Engine.ICard> GetAffectedCards(IGame game)
        {
            return game.BattleZone.GetCreatures(GetController(game).Id, Engine.Subtype.Chimera, Engine.Subtype.Armorloid);
        }
    }
}
