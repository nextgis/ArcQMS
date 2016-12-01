using BrutileArcGIS.Lib;
using BruTile;
using BruTile.Predefined;
using BruTile.Web;
using System.Collections.Generic;

namespace BrutileArcGIS.lib
{
    public class TileLayerConfig : IConfig
    {
        private string _name;
        private string _url;

        public TileLayerConfig(string name, string url)
        {
            _name = name;
            _url = url;
        }

        public List<string> Domains { get; set; }

        public ITileSource CreateTileSource()
        {
            var tileSchema = new GlobalSphericalMercator();
            var tileLayerRequest = new BasicRequest(_url, Domains);
            var tileProvider = new WebTileProvider(tileLayerRequest);
            var tileSource = new TileSource(tileProvider, tileSchema);
            return tileSource;
        }

        public string Url
        {
            get { return _url; }
        }
    }
}
