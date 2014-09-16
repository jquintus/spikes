using Android.Widget;
using Cirrious.MvvmCross.ViewModels;
using System;
using System.Windows.Input;

namespace MvvmCrossSpikes.Droid.Bindings
{
    public class ButtonCommandBinding : MvxTargetBinding<Button, ICommand>
    {
        private ICommand _command;

        public ButtonCommandBinding(Button target)
            : base(target)
        {
            if (target != null)
                target.Click += Target_Click;
        }

        public static string Name { get { return "Command"; } }

        public override void SetTypedValue(ICommand cmd)
        {
            if (_command != null)
                _command.CanExecuteChanged -= command_CanExecuteChanged;

            _command = cmd;

            if (_command != null)
            {
                _command.CanExecuteChanged += command_CanExecuteChanged;
            }

            command_CanExecuteChanged(this, EventArgs.Empty);
        }

        protected override void Dispose(bool isDisposing)
        {
            var button = Target;
            if (isDisposing && button != null)
            {
                button.Click -= Target_Click;
            }
            base.Dispose(isDisposing);
        }

        private void command_CanExecuteChanged(object sender, EventArgs e)
        {
            var cmd = _command;
            var parameter = sender;
            var target = Target;
            if (cmd != null && target != null)
            {
                target.Enabled = cmd.CanExecute(parameter);
            }
        }

        private void Target_Click(object sender, EventArgs e)
        {
            var cmd = _command;
            var parameter = sender;
            if (cmd != null && cmd.CanExecute(parameter))
            {
                cmd.Execute(parameter);
            }
        }
    }
}