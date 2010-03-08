﻿#region

using System;
using System.Xml.Serialization;

#endregion

namespace jeza.Travian.GameCenter
{
    [Serializable]
    [XmlRoot(ElementName = "settings", IsNullable = false)]
    public class Settings
    {
        [XmlElement(ElementName = "login")]
        public Login LoginData { get; set; }

        [XmlElement(ElementName = "languageId")]
        public string LanguageId { get; set; }
    }

    [Serializable]
    public class Login
    {
        [XmlElement(ElementName = "server")]
        public string Servername { get; set; }

        [XmlElement(ElementName = "username")]
        public string Username { get; set; }

        [XmlElement(ElementName = "password")]
        public string Password { get; set; }
    }
}