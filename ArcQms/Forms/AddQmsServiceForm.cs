using ArcQms.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows.Forms;
using LocalizationForm = ArcQms.Localization.Forms.AddQmsServiceForm.Resource;
using w = BruTile.Web;

namespace ArcQms.Forms
{
    public partial class AddQmsServiceForm : Form
    {
        BindingList<QmsServiceInfo> services = new BindingList<QmsServiceInfo>();

        public AddQmsServiceForm()
        {
            InitializeComponent();
        }

        public QmsServiceDetail QmsServiceDetail
        {
            get
            {
                var addQmsServiceControl = this.wpfAddQmsService.Child as AddQmsServiceControl;
                return addQmsServiceControl.QmsServiceDetailProperty.QmsServiceDetail;
            }
            private set { }
        }
    }
}
