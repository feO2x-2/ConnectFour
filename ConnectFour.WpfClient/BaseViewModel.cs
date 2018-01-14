using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ConnectFour.WpfClient
{
    public class BaseViewModel : INotifyPropertyChanged, IRaisePropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        void IRaisePropertyChanged.RaisePropertyChanged(string propertyName)
        {
// ReSharper disable once ExplicitCallerInfoArgument
            OnPropertyChanged(propertyName);
        }
    }
}