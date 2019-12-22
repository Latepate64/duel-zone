using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Effects.OneShotEffects
{
    public class ReadOnlyOneShotEffectCollection : ReadOnlyCollection<OneShotEffect>
    {
        public ReadOnlyOneShotEffectCollection(IEnumerable<OneShotEffect> oneShotEffects) : base(oneShotEffects.ToList()) { }

        public ReadOnlyOneShotEffectCollection(OneShotEffect oneShotEffect) : base(new List<OneShotEffect>() { oneShotEffect }) { }
    }
}
