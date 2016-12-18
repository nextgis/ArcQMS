using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ArcQms.Properties;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Framework;
using BrutileArcGIS.lib;
using BrutileArcGIS.Lib;
using ArcQms.Forms;
using ESRI.ArcGIS.GISClient;
using ESRI.ArcGIS.esriSystem;

namespace ArcQms.Commands
{
    [ProgId("AddQmsServiceCommand")]
    public sealed class AddQmsServiceCommand : BaseCommand
    {
        private IMap _map;
        private IApplication _application;

        public AddQmsServiceCommand()
        {
            m_category = "ArcQMS";
            m_caption = "&Add QMS service...";
            m_message = "Add QMS service...";
            m_toolTip = m_message;
            m_name = "QmsServiceCommand";
        }

        public override void OnCreate(object hook)
        {
            if (hook == null)
                return;

            _application = hook as IApplication;

            //Disable if it is not ArcMap
            if (hook is IMxApplication)
                m_enabled = true;
            else
                m_enabled = false;

        }

        public override bool Enabled
        {
            get
            {
                return true;
            }
        }

        public override void OnClick()
        {
            try
            {
                var mxdoc = (IMxDocument)_application.Document;
                _map = mxdoc.FocusMap;

                var addQmsService = new AddQmsServiceForm();
                var result = addQmsService.ShowDialog(new ArcMapWindow(_application));

                BruTileLayer brutileLayer = null;

                if (result == DialogResult.OK)
                {
                    var url = addQmsService.QmsServiceDetail.Url;
                    var name = addQmsService.QmsServiceDetail.Name;

                    EnumBruTileLayer layerType = EnumBruTileLayer.Giscloud;
                    if (addQmsService.QmsServiceDetail.Type == "tms" &&
                        addQmsService.QmsServiceDetail.YOriginTop)
                    {
                        layerType = EnumBruTileLayer.InvertedTMS;
                        var tileLayerConfig = new TileLayerConfig(name, url);
                        brutileLayer = new BruTileLayer(_application, tileLayerConfig, layerType)
                        {
                            Name = name,
                            Visible = true
                        };
                    }

                    if (addQmsService.QmsServiceDetail.Type == "tms" &&
                        !addQmsService.QmsServiceDetail.YOriginTop)
                    {
                        layerType = EnumBruTileLayer.InvertedTMS;
                        var tileLayerConfig = new TileLayerConfig(name, url);
                        brutileLayer = new BruTileLayer(_application, tileLayerConfig, layerType)
                        {
                            Name = name,
                            Visible = true
                        };
                    }

                    if (layerType == EnumBruTileLayer.Giscloud) return;

                    ((IMapLayers)_map).InsertLayer(brutileLayer, true, 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //public void load_wms(ESRI.ArcGIS.Controls.AxMapControl mapcontrol)
        //{

        //    // Create an WMSMapLayer Instance - this will be added to the map later

        //    IWMSGroupLayer wmsMapLayer = new WMSMapLayerClass();
        //    // create and configure wms connection name
        //    // this is used to store the connection properties

        //    IWMSConnectionName connName = new WMSConnectionNameClass();

        //    IPropertySet propSet = new PropertySetClass();
        //    propSet.SetProperty("URL", "http://173.244.165.194/geoserver/Land_Managment/wms?");
        //    connName.ConnectionProperties = propSet;


        //    // uses the name information to connect to the service
        //    IDataLayer dataLayer = (IDataLayer)wmsMapLayer;
        //    dataLayer.Connect((IName)connName);

        //    // get service description out of the layer
        //    // the service description contains inforamtion about the wms categories
        //    // and layers supported by the service

        //    IWMSServiceDescription serviceDesc = wmsMapLayer.WMSServiceDescription;
        //    IWMSLayerDescription groupDesc = serviceDesc.LayerDescription[0];


        //    // for each wms layer either add the stand-alone layer or
        //    // group layer to the WMSMapLayer which will be added to ArcMap
        //    for (int i = 0; i < groupDesc.LayerDescriptionCount - 1; i++)
        //    {
        //        IWMSLayerDescription layerDesc = groupDesc.LayerDescription[i];

        //        //  if (layerDesc.Title == WMSLayers.SelectedItem.ToString())//Checking if this is the selected layer
        //        // {
        //        // Configure the layer before adding it to the map
        //        ILayer newLayer;
        //        IWMSLayer newWMSLayer = wmsMapLayer.CreateWMSLayer(layerDesc);
        //        newLayer = (ILayer)newWMSLayer;
        //        wmsMapLayer.InsertLayer(newLayer, 0);
        //        // add layer to Map

        //        mapcontrol.AddLayer((ILayer)wmsMapLayer);
        //        IActiveView activeview = (IActiveView)mapcontrol.ActiveView;
        //        activeview.Refresh();
        //    }
        //}
    }
}
