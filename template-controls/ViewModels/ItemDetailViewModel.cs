using System;
using System.Threading.Tasks;
using System.Windows.Input;
using template_controls.Models;
using Xamarin.Forms;

namespace template_controls.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }

        public ItemDetailViewModel(Item item = null)
        {
            IsLoading = false;
            Title = item?.Text;
            Item = item;

            SkeletonLoadCommand = new Command(async () =>
            {
                IsLoading = true;
                await Task.Delay(4000);
                IsLoading = false;
            });
        }

        public ICommand SkeletonLoadCommand { get; }
    }
}
