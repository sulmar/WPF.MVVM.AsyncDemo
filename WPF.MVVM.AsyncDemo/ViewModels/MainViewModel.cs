using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.MVVM.AsyncDemo.Common;

namespace WPF.MVVM.AsyncDemo.ViewModels
{
    public class MainViewModel : ViewModelBase
    {



        #region Status

        private string _Status;

        public string Status
        {
            get { return _Status; }
            set { _Status = value; OnPropertyChanged();  }
        }

        #endregion

        #region IsBusy

        private bool _IsBusy;

        public bool IsBusy
        {
            get { return _IsBusy; }
            set { _IsBusy = value; OnPropertyChanged(); }
        }

        #endregion


        public ICommand LoadCommand => new RelayCommand(() => Load());

        public IAsyncCommand AsyncLoadCommand => new AsyncRelayCommand(async () => await LoadAsync());


        public void Load()
        {
            Status = "Loading...";

            Thread.Sleep(TimeSpan.FromSeconds(3));

            Status = "Loaded";
        }

        public async Task LoadAsync()
        {
            Status = "Loading...";

            IsBusy = true;

            await Task.Delay(TimeSpan.FromSeconds(3));

            Status = "Loaded";

            IsBusy = false;
        }
    }
}
