using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace Exam1
{
    public class MainWindowViewModel : BaseViewModel
    {
        public ICommand AddButtonCommand { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public Item SelectedItem { get; set; }
        public Item SelectedDropDownItem
        {
            get
            {
                return selectedDropDownItem;
            }
            set
            {
                selectedDropDownItem = value;
                if (SelectedDropDownItem != null)
                {
                    for (int i = 0; i < Items.Count(); i++)
                    {
                        if (SelectedDropDownItem.Content == Items[i].Content)
                        {
                            Items.RemoveAt(i);
                            SolidColorBrush green = new SolidColorBrush(Colors.Green);
                            Items.Add(new Item(this) { Content = SelectedDropDownItem.Content, TagColor = green });
                        }
                    }

                    Items = Items.ToList();
                    OnPropertyChanged(nameof(Items));
                }
            }
        }

        private Item selectedDropDownItem { get; set; }


        public string DisplayString
        {
            get
            {
                string con = "";
                List<String> content = new List<String>();
                for (int i = 0; i < Items.Count; i++)
                {
                    content.Add(Items[i].Content);
                }
                con = string.Join(", ", content);
                return con;
            }
        }

        public MainWindowViewModel()
        {
            AddButtonCommand = new RelayCommand(AddButtonClick);
            SelectedItem = new Item(this);
        }

        public void AddButtonClick()
        {
            Items = Items.ToList();

            var i = Items.Where(x => x.Content.Trim() == SelectedItem.Content.Trim());

            if (i.Count() == 0)
            {
                Items.Add(new Item(this)
                {
                    Content = SelectedItem.Content,
                    TagColor = new SolidColorBrush(Colors.Gray),
                    Id = Items.Count(),
                });

                OnPropertyChanged(nameof(Items));
                OnPropertyChanged(nameof(DisplayString));
            }
        }
    }
}
