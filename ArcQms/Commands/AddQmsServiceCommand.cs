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

                if (result == DialogResult.OK)
                {
                    var url = addQmsService.QmsServiceDetail.Url;
                    var name = addQmsService.QmsServiceDetail.Name;

                    EnumBruTileLayer layerType = EnumBruTileLayer.Giscloud;
                    if (addQmsService.QmsServiceDetail.Type == "tms" && 
                        addQmsService.QmsServiceDetail.YOriginTop)
                    {
                        layerType = EnumBruTileLayer.InvertedTMS;
                    }

                    if (addQmsService.QmsServiceDetail.Type == "tms" &&
                        !addQmsService.QmsServiceDetail.YOriginTop)
                    {
                        layerType = EnumBruTileLayer.TMS;
                    }

                    if (layerType == EnumBruTileLayer.Giscloud) return;

                    var tileLayerConfig = new TileLayerConfig(name, url);
                    var brutileLayer = new BruTileLayer(_application, tileLayerConfig, layerType)
                    {
                        Name = name,
                        Visible = true
                    };
                    ((IMapLayers)_map).InsertLayer(brutileLayer, true, 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
