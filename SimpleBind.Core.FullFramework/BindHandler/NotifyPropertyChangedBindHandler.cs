using SimpleBind.Core.Lib;
using System.ComponentModel;

namespace SimpleBind.Core.BindHandler
{
    public class NotifyPropertyChangedBindHandler : BindHandler<INotifyPropertyChanged>
    {
        public NotifyPropertyChangedBindHandler(BindContainer container, INotifyPropertyChanged item, IBindedItem config, BindHandlerOrientation orientation)
            : base(container, item, config, orientation)
        {
        }

        public override void Apply()
        {
            Item.PropertyChanged += PropertyChangedEvent;
        }

        public override void Remove()
        {
            Item.PropertyChanged -= PropertyChangedEvent;
        }

        private void PropertyChangedEvent(object sender, PropertyChangedEventArgs e)
        {
            if (sender == null)
                return;

            var lValue = sender.GetType().GetProperty(e.PropertyName)?.GetValue(sender);
            BroadcastValueChanged(
                sender,
                e.PropertyName,
                lValue);
        }
    }
}