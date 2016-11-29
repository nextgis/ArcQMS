using ESRI.ArcGIS.SystemUI;

namespace ArcQms.MenuDefs
{
    public class ArcQmsMenuDef : IMenuDef
    {
        public string Caption
        {
            get { return "&ArcQms 0.1"; }
        }

        public void GetItemInfo(int pos, IItemDef itemDef)
        {
            switch (pos)
            {
                case 0:
                    itemDef.ID = "AddQmsServiceCommand";
                    itemDef.Group = false;
                    break;

            }
        }

        public int ItemCount
        {
            get { return 1; }
        }

        public string Name
        {
            get { return "ArcQms"; }
        }
    }
}
