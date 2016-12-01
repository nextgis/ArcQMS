using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ArcQms.Forms.ViewModel
{
    public abstract class ModelBase : INotifyPropertyChanged
    {
        private Guid idValue = Guid.NewGuid();

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
