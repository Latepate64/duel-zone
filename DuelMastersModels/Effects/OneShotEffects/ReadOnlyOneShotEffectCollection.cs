using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Effects.OneShotEffects
{
    public class ReadOnlyOneShotEffectCollection : ReadOnlyCollection<OneShotEffect>
    {
        internal ReadOnlyOneShotEffectCollection(IEnumerable<OneShotEffect> oneShotEffects) : base(oneShotEffects.ToList()) { }

        internal ReadOnlyOneShotEffectCollection(OneShotEffect oneShotEffect) : base(new List<OneShotEffect>() { oneShotEffect }) { }
    }
}
