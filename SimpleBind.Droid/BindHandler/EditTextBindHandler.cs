using Android.Text;
using Android.Widget;
using SimpleBind.Core;
using SimpleBind.Core.BindHandler;

namespace SimpleBind.Droid.BindHandler
{
    public class EditTextBindHandler : BindHandler<EditText>
    {
        public EditTextBindHandler(BindContainer container, EditText item, IBindedItem config, BindHandlerOrientation orientation)
            : base(container, item, config, orientation)
        {
        }

        public override void Apply()
        {
            Item.TextChanged += TextChangedEvent;
        }

        public override void Remove()
        {
            Item.TextChanged -= TextChangedEvent;
        }

        private void TextChangedEvent(object sender, TextChangedEventArgs args)
        {
            BroadcastValueChanged(
                sender,
                et => ((EditText) et).Text,
                ((EditText) sender).Text);
        }
    }
}