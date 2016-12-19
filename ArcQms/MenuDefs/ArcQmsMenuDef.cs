using ESRI.ArcGIS.SystemUI;
using LocalizationMenu = ArcQms.Localization.Menu.ArcQmsMenuDef.Resource;

namespace ArcQms.MenuDefs
{
    public class ArcQmsMenuDef : IMenuDef
    {
        public string Caption
        {
            get { return LocalizationMenu.Caption; }
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
            get { return "ArcQMS"; }
        }
    }
}
