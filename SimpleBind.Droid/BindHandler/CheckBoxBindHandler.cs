using Android.Widget;
using SimpleBind.Core;
using SimpleBind.Core.BindHandler;

namespace SimpleBind.Droid.BindHandler
{
    public class CheckBoxBindHandler : BindHandler<CheckBox>
    {
        public CheckBoxBindHandler(BindContainer container, CheckBox item, IBindedItem config, BindHandlerOrientation orientation)
            : base(container, item, config, orientation)
        {
        }

        public override void Apply()
        {
            Item.CheckedChange += CheckedChangeEvent;
        }

        public override void Remove()
        {
            Item.CheckedChange -= CheckedChangeEvent;
        }

        private void CheckedChangeEvent(object sender, CompoundButton.CheckedChangeEventArgs args)
        {
            BroadcastValueChanged(
                sender,
                c => ((CheckBox) c).Checked,
                args.IsChecked);
        }
    }
}