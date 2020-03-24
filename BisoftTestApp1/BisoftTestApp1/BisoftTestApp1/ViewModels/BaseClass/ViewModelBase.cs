using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BisoftTestApp1.ViewModels.BaseClass
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        


        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, e);
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
