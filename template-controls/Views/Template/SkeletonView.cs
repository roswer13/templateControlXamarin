using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace templatecontrols.Views.Template
{
    public class SkeletonView : Label
    {
        public static readonly BindableProperty IsLoadingProperty =
            BindableProperty.Create(nameof(IsLoading), typeof(bool), typeof(LabelTemplate), default(bool), BindingMode.TwoWay);

        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            switch (propertyName)
            {
                case nameof(IsLoading):
                    if (IsLoading)
                        OnStartAnimationButtonClicked();
                    else
                        OnCancelAnimationButtonClicked();
                    break;
            }
        }

        async void OnStartAnimationButtonClicked()
        {
            while (IsLoading)
            {
                await Task.WhenAll(
                     this.ColorTo(Color.Transparent, Color.Transparent, c => this.TextColor = c, 1000),
                     this.ColorTo(Color.DarkGray, Color.White, c => this.BackgroundColor = c, 1000));
                await Task.WhenAll(
                     this.ColorTo(Color.Transparent, Color.Transparent, c => this.TextColor = c, 1000),
                     this.ColorTo(Color.White, Color.DarkGray, c => this.BackgroundColor = c, 1000));
            }
            this.TextColor = Color.Default;
            this.BackgroundColor = Color.Default;
        }

        void OnCancelAnimationButtonClicked()
        {
            this.CancelAnimation();
        }
    }
}
