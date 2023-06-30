using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace Exam1
{
    public class Item
    {
        public string Content { get; set; }
        public int Id { get; set; }

        public ICommand DeleteButtonCommand { get; set; }

        public SolidColorBrush TagColor { get; set; }

        private SolidColorBrush tagColor { get; set; }


        public Item GetItem
        {
            get
            {
                return this;
            }
        }
        //public Item GetItem
        //{
        //    get
        //    {
        //        return new 
        //    }; set;
        //}

        MainWindowViewModel ViewModel { get; set; }

        public Item(MainWindowViewModel viewModel)
        {
            DeleteButtonCommand = new RelayCommand(DeleteButtonClick);
            ViewModel = viewModel;
        }


        public void DeleteButtonClick()
        {
            //ViewModel.Items;
            Item i = GetItem;

            ViewModel.Items.Remove(i);
            ViewModel.Items = ViewModel.Items.ToList();

            ViewModel.OnPropertyChanged(nameof(ViewModel.Items));
        }
    }
}
