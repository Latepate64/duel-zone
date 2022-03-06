using Common;
using Engine.ContinuousEffects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Engine.Abilities
{
    /// <summary>
    /// Static abilities do something all the time rather than being activated or triggered. They are written as statements, and they’re simply true.
    /// </summary>
    public class StaticAbility : Ability
    {
        /// <summary>
        /// Static abilities create continuous effects, some of which are prevention effects or replacement effects. These effects are active as long as the card with the ability remains on the battle zone and has the ability, or as long as the card with the ability remains in the appropriate zone.
        /// </summary>
        public List<ContinuousEffect> ContinuousEffects { get; private set; } = new List<ContinuousEffect>();

        public ZoneType FunctionZone { get; set; } = ZoneType.BattleZone;

        public StaticAbility(params ContinuousEffect[] continuousEffects) : base()
        {
            ContinuousEffects.AddRange(continuousEffects);
        }

        public StaticAbility(ContinuousEffect effect)
        {
            ContinuousEffects.Add(effect);
        }

        protected StaticAbility(StaticAbility ability) : base(ability)
        {
            ContinuousEffects = ability.ContinuousEffects.Select(x => x.Copy()).ToList();
            FunctionZone = ability.FunctionZone;
        }

        public override Ability Copy()
        {
            return new StaticAbility(this);
        }

        public override string ToString()
        {
            return string.Join(" ", ContinuousEffects.Select(x => UpperCaseFirstCharacter(x.ToString())));
        }
    }
}
