using Android.Widget;
using SimpleBind.Core;
using SimpleBind.Core.BindHandler;
using SimpleBind.Droid.Extensions;
using SimpleBind.Droid.Proxy;

namespace SimpleBind.Droid.BindHandler
{
    public class SpinnerProxyBindHandler : BindHandler<SpinnerProxyBind>
    {
        public SpinnerProxyBindHandler(BindContainer container, SpinnerProxyBind item, IBindedItem config, BindHandlerOrientation orientation)
            : base(container, item, config, orientation)
        {
        }

        public override void Apply()
        {
            Item.ItemSelected += ItemSelectedEvent;
        }

        public override void Remove()
        {
            Item.ItemSelected -= ItemSelectedEvent;
        }

        private void ItemSelectedEvent(object sender, AdapterView.ItemSelectedEventArgs args)
        {
            BroadcastValueChanged(
                Item,
                s => ((SpinnerProxyBind) s).SelectedItemPosition,
                args.Position);

            var lValueJava = Item.Spinner.Adapter.GetItem(args.Position);
            var lValue = lValueJava.GetInstance();
            BroadcastValueChanged(
                Item,
                s => ((SpinnerProxyBind)s).SelectedItem,
                lValue ?? lValueJava);

            /*BroadcastValueChanged(
                Item,
                s => ((SpinnerProxyBind) s).SelectedItemJava,
                lValueJava);*/
        }
    }
}