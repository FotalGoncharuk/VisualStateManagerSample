using Xamarin.Forms;

namespace VisualStateManagerExample.CustomView
{
    [ContentProperty("Child")]
    public class OnPlatformView : Grid
    {
        private OnPlatform<View> _child;

        public OnPlatform<View> Child
        {
            get => _child;
            set
            {
                if (_child == value)
                {
                    return;
                }

                if (_child != null)
                {
                    Children.Remove(_child);
                }
                _child = value;

                if (_child != null)
                {
                    Children.Add(_child);
                }
            }
        }
    }
}
