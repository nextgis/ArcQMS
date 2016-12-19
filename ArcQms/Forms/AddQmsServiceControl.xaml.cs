using ArcQms.Forms.ViewModel;
using ArcQms.Model;
using mshtml;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using WinForms = System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ArcQms.Hepers;

namespace ArcQms.Forms
{
    /// <summary>
    /// Interaction logic for AddQmsServiceControl.xaml
    /// </summary>
    public partial class AddQmsServiceControl : UserControl
    {
        private static object _lock = new object();
        public AddQmsServiceControl()
        {
            InitializeComponent();
            BindControls();
            BindingOperations.EnableCollectionSynchronization(this.qmsServices, _lock);
            StartWebRequest();
        }

        ICollectionView viewQmsSerices;
        private void BindControls()
        {

            this.viewQmsSerices = CollectionViewSource.GetDefaultView(this.qmsServices);
            this.lbQmsServices.ItemsSource = this.viewQmsSerices;
            QmsServiceDetailProperty.PropertyChanged += new PropertyChangedEventHandler(QmsServiceDetailProperty_PropertyChanged);
        }

        private void QmsServiceDetailProperty_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var qmsServiceDetailProperty = sender as QmsServiceDetailProperty;
            var qmsServiceDetail = qmsServiceDetailProperty.QmsServiceDetail;
            if (qmsServiceDetail == null)
            {
                Dispatcher.InvokeAsync(() =>
                {
                    this.btnServiceOnMap.IsEnabled = false;
                });
                return;
            }

            Dispatcher.InvokeAsync(() =>
            {
                this.btnServiceOnMap.IsEnabled = true;
                var keyValues = ReflectionExtensions.GetValues<QmsServiceDetail>(qmsServiceDetail);
                this.dgMetadata.ItemsSource = keyValues.OrderBy(kv => kv.Key);
            });
        }

        public string SearchFilter
        {
            get
            {
                return "";
            }
            set
            {
                if (!string.IsNullOrEmpty(SearchFilter))
                    this.viewQmsSerices.Filter = new Predicate<object>(x =>
                                                  ((QmsServiceInfo)x).Name.Contains(SearchFilter));
                this.viewQmsSerices.Refresh();
            }
        }

        WebRequest servicesListWebRequest;
        const string QmsServicesListApi = "https://qms.nextgis.com/api/v1/geoservices/";
        ObservableCollection<QmsServiceInfo> qmsServices = new ObservableCollection<QmsServiceInfo>();

        void StartWebRequest()
        {
            servicesListWebRequest = HttpWebRequest.Create(QmsServicesListApi);
            servicesListWebRequest.BeginGetResponse(new AsyncCallback(FinishWebRequest), null);
        }

        void FinishWebRequest(IAsyncResult result)
        {
            try
            {
                var dataStream = servicesListWebRequest.GetResponse().GetResponseStream();
                var dataStreamReader = new StreamReader(dataStream);
                var res = dataStreamReader.ReadToEnd();
                var services = JsonConvert.DeserializeObject<List<QmsServiceInfo>>(res);
                services.ForEach(s => this.qmsServices.Add(s));
            }
            catch (Exception e)
            {
                // todo: Handle Exception
            }
        }

        private void AddStyles(WebBrowser browser, List<KeyValuePair<string, string>> styleRules)
        {
            try
            {
                if (browser.Document != null)
                {
                    var document = browser.Document as HTMLDocument;
                    int length = document.styleSheets.length;
                    var styleSheet = document.createStyleSheet(@"", -1);
                    styleRules.ForEach(r => styleSheet.addRule(r.Key, r.Value));
                }
            }
            catch (Exception ex)
            {

            }
        }

        void lbQmsServices_OnSelection(object sender, SelectionChangedEventArgs args)
        {
            ListBox lstbox = sender as ListBox;
            var qmsServiceInfo = lstbox.SelectedItem as QmsServiceInfo;
            if (qmsServiceInfo == null) return;
            this.StartServiceDetailWebRequest(qmsServiceInfo);
        }

        WebRequest serviceDetailWebRequest;
        const string QmsServiceGetDetail = "https://qms.nextgis.com/api/v1/geoservices/{0}/";

        void StartServiceDetailWebRequest(QmsServiceInfo qmsServiceInfo)
        {
            var url = string.Format(QmsServiceGetDetail, qmsServiceInfo.Id);
            serviceDetailWebRequest = HttpWebRequest.Create(url);
            serviceDetailWebRequest.BeginGetResponse(new AsyncCallback(FinishServiceDetailWebRequest), null);
        }

        const string QmsServiceWebPage = "https://qms.nextgis.com/geoservices/{0}/";

        public QmsServiceDetailProperty QmsServiceDetailProperty = QmsServiceDetailProperty.CreateNew();

        void FinishServiceDetailWebRequest(IAsyncResult result)
        {
            try
            {
                var dataStream = serviceDetailWebRequest.GetResponse().GetResponseStream();
                var dataStreamReader = new StreamReader(dataStream);
                var res = dataStreamReader.ReadToEnd();
                this.QmsServiceDetailProperty.QmsServiceDetail = JsonConvert.DeserializeObject<QmsServiceDetail>(res);
            }
            catch (Exception e)
            {
                // todo: Handle Exception
            }
        }

        private void btnServiceOnMap_Click(object sender, RoutedEventArgs e)
        {
            var source = (HwndSource)PresentationSource.FromDependencyObject(this.btnServiceOnMap);
            var host = (WinForms.Integration.ElementHost)WinForms.Control.FromChildHandle(source.Handle);
            var parentForm = (WinForms.Form)host.TopLevelControl;
            parentForm.DialogResult = WinForms.DialogResult.OK;
            parentForm.Close();
        }

        private void tbFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                this.viewQmsSerices.Filter = null;
            }
            else
            {
                this.viewQmsSerices.Filter = new Predicate<object>(x =>
                {
                    var qmsServiceInfo = x as QmsServiceInfo;
                    return (string.IsNullOrEmpty(qmsServiceInfo.Name) ? false : qmsServiceInfo.Name.Contains(textBox.Text));
                });
            }
            this.viewQmsSerices.Refresh();

        }

        private void lbQmsServices_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.btnServiceOnMap_Click(null, null);
        }
    }
}