using System.ComponentModel;

namespace Exam1
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public string PageName { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
    }
}