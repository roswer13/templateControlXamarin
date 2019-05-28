using System.Threading.Tasks;
using template_controls.Models;
using template_controls.ViewModels;
using Xamarin.Forms;

namespace template_controls.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            viewModel.IsLoading = true;
            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Item
            {
                Text = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.IsLoading = true;
            await Task.Delay(4000);
            viewModel.IsLoading = false;
        }
    }
}