﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Video.Pages.Services
{
    public class AppXmlResource
    {
        private static Dictionary<string, string> resources = null;
        private static object sync = new object();

        public static string GetResource(string key)
        {

            if (resources == null)
            {
                lock (sync)
                {
                    Initialize();
                }
            }
            try
            {
                return resources[key];
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static bool ContainsKey(string key) {
            if (resources == null)
            {
                Initialize();
            }
            return resources.ContainsKey(key);
        }

        private static void Initialize() {
            resources = new Dictionary<string, string>();
            XmlDocument xml = new XmlDocument();
            string resourcesFilePath = Path.Combine(AppContext.BaseDirectory,"App_Data/resources.xml");
            if (resourcesFilePath.Trim() != "")
            {
                xml.Load(resourcesFilePath);
            }
            XmlNodeList xl = xml.SelectNodes("resources/res");

            foreach (XmlNode n in xl)
            { 
                try
                {
                    resources.Add(n.Attributes["name"].Value, n.InnerText);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}