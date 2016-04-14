using DotGather.GatherContent.Objects;
using DotGather.Interfaces;
using DotGather.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace DotGather.Test.TestUtil
{
    /// <summary>
    /// Use this library to store sample objects to assert against.
    /// </summary>
    public class ExpectedValuesLibrary
    {
        public static int SampleAccountId = 25293;
        public static int SampleProjectId = 70052;
        public static int SamplePostProjectID = 70719;
        public static int SampleStatusId = 319149;
        public static int SampleItemId = 2505897;
        public static int SamplePostItemId = 2615022;
        public static int SampleTemplateId = 300229;

        public static Accounts GetAccountsTestJsonData
        {
            get
            {
                string jsonString = readJsonString("GetAccountsTestData.json");
                return (Accounts) JsonConvert.DeserializeObject(jsonString, typeof(Accounts));
            }
            private set { }
        }
        public static Projects GetProjectsTestJsonData
        {
            get
            {
                string jsonString = readJsonString("GetProjectsTestData.json");
                return (Projects)JsonConvert.DeserializeObject(jsonString, typeof(Projects));
            }
            private set { }
        }
        public static IEnumerable<ISection> SampleConfigJsonData
        {
            get
            {
                string jsonString = readJsonString("SampleConfigData.json");
                JsonConvert.DefaultSettings = () => new JsonSerializerSettings { ContractResolver = new GatherContentContractResolver() };
                return ((Page)JsonConvert.DeserializeObject(jsonString, typeof(Page))).ContentSections;
            }
            private set { }
        }
        public static User GetMeTestJsonData
        {
            get
            {
                string jsonString = readJsonString("GetMeTestData.json");
                return (User)JsonConvert.DeserializeObject(jsonString, typeof(User));
            }
            private set { }
        }
        public static GatherFiles GetFilesForItemTestJsonData
        {
            get
            {
                string jsonString = readJsonString("GetFilesForItemTestData.json");
                return (GatherFiles)JsonConvert.DeserializeObject(jsonString, typeof(GatherFiles));
            }
            private set { }
        }
        public static Page GetItemTestJsonData
        {
            get
            {
                string jsonString = readJsonString("GetItemTestData.json");
                return (Page)JsonConvert.DeserializeObject(jsonString, typeof(Page));
            }
            private set { }
        }
        public static Statuses GetStatusesTestJsonData
        {
            get
            {
                string jsonString = readJsonString("GetStatusesTestData.json");
                return (Statuses)JsonConvert.DeserializeObject(jsonString, typeof(Statuses));
            }
            private set { }
        }
        public static Templates GetTemplatesTestJsonData
        {
            get
            {
                string jsonString = readJsonString("GetTemplatesTestData.json");
                return (Templates)JsonConvert.DeserializeObject(jsonString, typeof(Templates));
            }
            private set { }
        }
        private static string readJsonString(string fileName)
        {
            string jsonString = "";
            using (var r = new StreamReader("./TestContent/" + fileName))
            {
                jsonString = r.ReadToEnd();
            }
            return jsonString;
        }
    }

}
