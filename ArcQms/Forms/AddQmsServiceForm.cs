using ArcQms.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocalizationForm = ArcQms.Localization.Forms.AddQmsService.Resource;

namespace ArcQms.Forms
{
    public partial class AddQmsServiceForm : Form
    {
        BindingList<QmsServiceInfo> services = new BindingList<QmsServiceInfo>();

        public AddQmsServiceForm()
        {
            InitializeComponent();
            InitControls();
            BindControls();
            StartWebRequest();
            DisableClickSounds();
        }

        void InitControls ()
        {
            this.tbfilterServices.Text = LocalizationForm.FilterText;
        }

        void BindControls()
        {
            this.lbQmsServices.DataSource = services;
            this.lbQmsServices.DisplayMember = "Name";
            this.lbQmsServices.ValueMember = "Id";
            
            this.tbfilterServices.GotFocus += RemoveText;
            this.tbfilterServices.LostFocus += AddText;

            this.FormClosing += FormClosingHandler; 
        }

        WebRequest servicesListWebRequest;
        const string QmsServicesListApi = "https://qms.nextgis.com/api/v1/geoservices/";

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
                services.ForEach(s => this.services.Add(s));
            }
            catch (Exception e)
            {
                // todo: Handle Exception
            }
        }

        public void RemoveText(object sender, EventArgs e)
        {
            if (this.tbfilterServices.Text == LocalizationForm.FilterText)
            {
                this.tbfilterServices.Text = "";
            }
        }

        public void AddText(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.tbfilterServices.Text))
                this.tbfilterServices.Text = LocalizationForm.FilterText;
        }

        private void tbfilterServices_TextChanged(object sender, EventArgs e)
        {

        }

        
        private void lbQmsServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            var serviceInfo = (QmsServiceInfo)lbQmsServices.SelectedItem;
            this.StartServiceDetailWebRequest(serviceInfo);
        }

        WebRequest serviceDetailWebRequest;
        const string QmsServiceGetDetail = "https://qms.nextgis.com/api/v1/geoservices/{0}/";

        void StartServiceDetailWebRequest(QmsServiceInfo serviceInfo)
        {
            this.QmsServiceDetail = null;
            var url = string.Format(QmsServiceGetDetail, serviceInfo.Id);
            serviceDetailWebRequest = HttpWebRequest.Create(url);
            serviceDetailWebRequest.BeginGetResponse(new AsyncCallback(FinishServiceDetailWebRequest), null);
        }

        const string QmsServiceWebPage = "https://qms.nextgis.com/geoservices/{0}/";

        public QmsServiceDetail QmsServiceDetail { get; private set; }

        void FinishServiceDetailWebRequest(IAsyncResult result)
        {
            try
            {
                var dataStream = serviceDetailWebRequest.GetResponse().GetResponseStream();
                var dataStreamReader = new StreamReader(dataStream);
                var res = dataStreamReader.ReadToEnd();
                this.QmsServiceDetail = JsonConvert.DeserializeObject<QmsServiceDetail>(res);
                //this.wbQmsService.Navigate(new Uri(string.Format(QmsServiceWebPage, this.QmsServiceDetail.Id)));
            }
            catch (Exception e)
            {
                // todo: Handle Exception
            }
        }

        void FormClosingHandler (object sender, EventArgs e)
        {
            this.wbQmsService.Stop();
            this.wbQmsService.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // http://tile2.maps.2gis.com/tiles?x={x}&y={y}&z={z}&v=1.1
            if (this.QmsServiceDetail != null)
            {
                
            }
        }

        const int FEATURE_DISABLE_NAVIGATION_SOUNDS = 21;
        const int SET_FEATURE_ON_PROCESS = 0x00000002;

        [DllImport("urlmon.dll")]
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Error)]
        static extern int CoInternetSetFeatureEnabled(int FeatureEntry,
                                                      [MarshalAs(UnmanagedType.U4)] int dwFlags,
                                                      bool fEnable);

        static void DisableClickSounds()
        {
            CoInternetSetFeatureEnabled(FEATURE_DISABLE_NAVIGATION_SOUNDS,
                                        SET_FEATURE_ON_PROCESS,
                                        true);
        }
    }
}
