using Cirrious.MvvmCross.Binding;
using Cirrious.MvvmCross.Binding.Bindings.Target;
using System;

namespace MvvmCrossSpikes.Droid.Bindings
{
    public abstract class MvxTargetBinding<TTarget, TValue> : MvxTargetBinding
    {
        public MvxTargetBinding(TTarget target)
            : base(target)
        {
        }

        public override MvxBindingMode DefaultMode
        {
            get { return MvxBindingMode.TwoWay; }
        }

        public override Type TargetType { get { return typeof(TValue); } }

        protected new TTarget Target { get { return (TTarget)base.Target; } }

        public abstract void SetTypedValue(TValue value);

        public override void SetValue(object value)
        {
            if (value is TValue)
                SetTypedValue((TValue)value);
            else
                SetTypedValue(default(TValue));
        }
    }
}