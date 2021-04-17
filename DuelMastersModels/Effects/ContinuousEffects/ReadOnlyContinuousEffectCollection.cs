using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Effects.ContinuousEffects
{
    public class ReadOnlyContinuousEffectCollection : ReadOnlyCollection<IContinuousEffect>
    {
        internal ReadOnlyContinuousEffectCollection() : base(new List<IContinuousEffect>())
        {
        }

        internal ReadOnlyContinuousEffectCollection(IEnumerable<IContinuousEffect> continuousEffects) : base(continuousEffects.ToList()) { }

        internal ReadOnlyContinuousEffectCollection(IContinuousEffect continuousEffect) : base(new List<IContinuousEffect>() { continuousEffect }) { }
    }
}
