using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace templatecontrols.Views.Template
{
    public partial class LabelTemplate : ContentView
    {
        public static readonly BindableProperty IsLoadingProperty =
             BindableProperty.Create("IsLoading", typeof(bool), typeof(LabelTemplate), false, BindingMode.TwoWay);

        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(LabelTemplate), "");

        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public LabelTemplate()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            switch (propertyName)
            {
                case "Title":
                    TitleLabel.Text = Title;
                    break;
                case "IsLoading":
                    if (IsLoading)
                        OnStartAnimationButtonClicked(TitleLabel);
                    else
                        OnCancelAnimationButtonClicked(TitleLabel);
                    break;

            }
        }

        async void OnStartAnimationButtonClicked(Label label)
        {
            while (IsLoading)
            {
                await Task.WhenAll(
                     label.ColorTo(Color.Transparent, Color.Transparent, c => label.TextColor = c, 1000),
                     label.ColorTo(Color.DarkGray, Color.White, c => label.BackgroundColor = c, 1000));
                await Task.WhenAll(
                     label.ColorTo(Color.Transparent, Color.Transparent, c => label.TextColor = c, 1000),
                     label.ColorTo(Color.White, Color.DarkGray, c => label.BackgroundColor = c, 1000));
            }
            label.BackgroundColor = Color.Default;
            label.TextColor = Color.Default;
        }

        void OnCancelAnimationButtonClicked(Label label)
        {
            label.CancelAnimation();
            this.CancelAnimation();
        } 
    }
}
