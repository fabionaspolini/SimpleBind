using Android.Widget;
using SimpleBind.Core;
using SimpleBind.Droid.Extensions;
using System;

namespace SimpleBind.Droid.Proxy
{
    public class SpinnerProxyBind
    {
        #region Properties

        public ISpinnerAdapter Adapter => Spinner.Adapter;

        public Spinner Spinner { get; }

        public bool Animated { get; set; } = false;

		public object SelectedItem
        {
            get => Spinner.SelectedItem;
		    set
            {
                var lPosition = GetAdapterPositionFromItem(value);
                Spinner.SetSelection(lPosition, Animated);
            }
        }

        public Java.Lang.Object SelectedItemJava => Spinner.SelectedItem;

        public int SelectedItemPosition
        {
            get => Spinner.SelectedItemPosition;
            set => Spinner.SetSelection(value, Animated);
        }

        #endregion

        public event EventHandler<AdapterView.ItemSelectedEventArgs> ItemSelected;

        public SpinnerProxyBind(Spinner spinner, bool animated = false)
        {
            Animated = animated;
            Spinner = spinner;
            Spinner.ItemSelected += (sender, args) => ItemSelected?.Invoke(sender, args);
        }

        public int GetAdapterPositionFromItem(object item)
        {
            if (item == null || Spinner?.Adapter == null)
                return -1;

            var lIsPrimitiveType = BindEngine.Platform.IsDotNetPrimitiveType(item.GetType());

            for (int i = 0; i < Spinner.Adapter.Count; i++)
            {
                var lAdptItemJava = Spinner.Adapter.GetItem(i);
                if (lAdptItemJava != null && lAdptItemJava.Equals(item))
                    return i;

                var lAdptItemCasted = lAdptItemJava?.GetInstance();
                if (lAdptItemCasted != null && lAdptItemCasted.Equals(item))
                    return i;

                if (lIsPrimitiveType && PrimitiveCompare(item, lAdptItemJava))
                    return i;
            }

            return -1;
        }

        private bool PrimitiveCompare(object dotNetItemValue, Java.Lang.Object adapterItemValue)
        {
            try
            {
                if (adapterItemValue is Java.Lang.Byte)
                    return ((Java.Lang.Byte) adapterItemValue).ByteValue() == Convert.ToByte(dotNetItemValue);

                if (adapterItemValue is Java.Lang.Double)
                    return Math.Abs(((Java.Lang.Double) adapterItemValue).DoubleValue() - Convert.ToDouble(dotNetItemValue)) < 0.00001;

                if (adapterItemValue is Java.Lang.Float)
                    return Math.Abs(((Java.Lang.Float) adapterItemValue).DoubleValue() - Convert.ToDouble(dotNetItemValue)) < 0.00001;

                if (adapterItemValue is Java.Lang.Integer)
                    return ((Java.Lang.Integer) adapterItemValue).IntValue() == Convert.ToInt32(dotNetItemValue);

                if (adapterItemValue is Java.Lang.Long)
                    return ((Java.Lang.Long) adapterItemValue).LongValue() == Convert.ToInt64(dotNetItemValue);

                if (adapterItemValue is Java.Lang.Short)
                    return ((Java.Lang.Short) adapterItemValue).ShortValue() == Convert.ToInt16(dotNetItemValue);

                if (adapterItemValue is Java.Lang.String)
                    return ((Java.Lang.String) adapterItemValue).ToString() == Convert.ToString(dotNetItemValue);

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}