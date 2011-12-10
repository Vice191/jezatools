using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace jeza.Item.Tracker
{
    [XmlRoot]
    public class Settings
    {
        [XmlArray]
        public List<Language> Languages { get; set; }
    }

    public class Language
    {
        [XmlAttribute]
        public string Culture { get; set; }

        [XmlElement]
        public TabItems TabItems { get; set; }

        [XmlElement]
        public TabOrders TabOrders { get; set; }

        [XmlElement]
        public TabReports TabReports { get; set; }
    }

    public class TabItems
    {
        [XmlAttribute]
        public string TabPageItems { get; set; }

        [XmlElement]
        public string GroupBoxItemsType { get; set; }

        [XmlElement]
        public string LabelItemsTypeExisting { get; set; }

        [XmlElement]
        public string LabelItemsTypeNew { get; set; }

        [XmlElement]
        public string ButtonItemsTypeSelect { get; set; }

        [XmlElement]
        public string ButtonItemsTypeSave { get; set; }

        [XmlElement]
        public string GroupBoxItemsStatus { get; set; }

        [XmlElement]
        public string LabelItemsStatusExisting { get; set; }

        [XmlElement]
        public string LabelItemsStatusNew { get; set; }

        [XmlElement]
        public string ButtonItemsStatusSelect { get; set; }

        [XmlElement]
        public string ButtonItemsStatusSave { get; set; }

        [XmlElement]
        public string GroupBoxItems { get; set; }

        [XmlElement]
        public string LabelItemsList { get; set; }

        [XmlElement]
        public string ButtonItemsSelect { get; set; }

        [XmlElement]
        public string LabelItemsNew { get; set; }

        [XmlElement]
        public string LabelItemsItemType { get; set; }

        [XmlElement]
        public string LabelItemsImage { get; set; }

        [XmlElement]
        public string ButtonItemsSave { get; set; }

        [XmlElement]
        public string ButtonItemsPictureBoxSelect { get; set; }
    }

    public class TabOrders
    {
        [XmlAttribute]
        public string Name { get; set; }
    }

    public class TabReports
    {
        [XmlAttribute]
        public string Name { get; set; }
    }
}