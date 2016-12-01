using ArcQms.Model;
using System.ComponentModel;

namespace ArcQms.Forms.ViewModel
{
    public class QmsServiceDetailProperty : ModelBase
    {
        private QmsServiceDetail qmsServiceDetail;

        private QmsServiceDetailProperty()
        {
        }

        public static QmsServiceDetailProperty CreateNew()
        {
            return new QmsServiceDetailProperty();
        }

        public QmsServiceDetail QmsServiceDetail
        {
            get
            {
                return this.qmsServiceDetail;
            }

            set
            {
                if (value != this.qmsServiceDetail)
                {
                    this.qmsServiceDetail = value;
                    this.NotifyPropertyChanged();
                }
            }
        }
    }
}
