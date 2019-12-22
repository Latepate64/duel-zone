using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Effects.ContinuousEffects
{
    public class ReadOnlyContinuousEffectCollection : ReadOnlyCollection<ContinuousEffect>
    {
        public ReadOnlyContinuousEffectCollection() : base(new List<ContinuousEffect>())
        {
        }

        public ReadOnlyContinuousEffectCollection(IEnumerable<ContinuousEffect> continuousEffects) : base(continuousEffects.ToList()) { }

        public ReadOnlyContinuousEffectCollection(ContinuousEffect continuousEffect) : base(new List<ContinuousEffect>() { continuousEffect }) { }
    }

    public class ContinuousEffectCollection : ReadOnlyContinuousEffectCollection
    {
        public ContinuousEffectCollection() : base(new List<ContinuousEffect>())
        {
        }

        public void Add(ContinuousEffect continuousEffect)
        {
            Items.Add(continuousEffect);
        }

        public void Remove(ContinuousEffect continuousEffect)
        {
            Items.Remove(continuousEffect);
        }
    }

    public class ObservableContinuousEffectCollection : ObservableCollection<ContinuousEffect>
    {

    }
}
