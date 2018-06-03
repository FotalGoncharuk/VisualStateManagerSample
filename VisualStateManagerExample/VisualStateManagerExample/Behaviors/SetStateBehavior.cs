using System;
using VisualStateManagerExample.Behaviors.Base;
using Xamarin.Forms;

namespace VisualStateManagerExample.Behaviors
{
    public class SetStateBehavior : BindableBehavior<Entry>
    {

        // ===== Bindable Properties =====

        public static readonly BindableProperty StateProperty = BindableProperty.CreateAttached(
            nameof(State),
            typeof(string),
            typeof(SetStateBehavior),
            null,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var state = (string) newValue;
                ((SetStateBehavior)bindable).State = state;
            });

        private string _state = String.Empty;
        public string State
        {
            get => _state;
            set
            {
                if (_state.Equals(value))
                    return;

                _state = value;
                GoToState();
            }
        }


        // ===== Private Fields =====

        private View _element;


        // ===== Override Methods =====

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);

            _element = bindable;               
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            _element = null;

            base.OnDetachingFrom(bindable);
        }


        // ===== Private Methods =====

        private void GoToState()
        {
            VisualStateManager.GoToState(_element, _state);
        }
    }
}
