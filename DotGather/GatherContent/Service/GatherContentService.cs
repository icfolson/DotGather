using DotGather.Flags;
using DotGather.GatherContent.Objects;
using DotGather.Interfaces;
using DotGather.Json;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Configuration;
using System.Text;
using System.Web;

namespace DotGather.GatherContent.Service
{
    /// <summary>
    /// Connector to the GatherContent API
    /// </summary>
    /// <example>
    /// This example shows how to use this class.
    /// <code>
    /// var service = new GatherContentService();
    /// var me = service.GetMe();
    /// </code>
    /// </example>
    public class GatherContentService
    {

        #region Private Variables

        private static readonly ILog Logger = LogManager.GetLogger(typeof(GatherContentService));
        private HttpWebRequest _request;
        private readonly Uri _serviceUrl;

        #endregion

        #region Public Variables

        /// <summary>
        /// URL Path for requests to the GatherContent API
        /// </summary>
        public string RequestPath { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Connector Constructor that sets the Service URL from application configuration and default GatherContent JSON serializer.
        /// </summary>
        /// <param name="requestPath">Sets the request path to an API method on initialization of the connector</param>
        public GatherContentService(string requestPath = null)
        {
            RequestPath = requestPath;
            _serviceUrl = new Uri(ConfigurationManager.AppSettings["ApiUrl"]);
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings { ContractResolver = new GatherContentContractResolver() };
        }

        #endregion

        #region Public Methods

        #region Get Methods

        /// <summary>
        /// You have access to all fields if information about the logged in User such as
        /// their avatar url, name, and other fields.
        /// </summary>
        /// <returns>Returns <see cref="IUser"/> with the users' information</returns>
        /// <seealso cref="User"/>
        public IUser GetMe()
        {
            RequestPath = "me";
            return GetSingleObjectRequest<User>();
        }

        /// <summary>
        /// Retrieves a list of all Accounts associated with a specific User in GatherContent.
        /// </summary>
        /// <returns>Returns all <see cref="Accounts"/> for user</returns>
        /// <seealso cref="Account"/>
        public Accounts GetAccounts()
        {
            RequestPath = "accounts";
            return GetSingleObjectRequest<Accounts>();
        }

        /// <summary>
        /// Retrieves a list of all Projects associated with the given Account.
        /// </summary>
        /// <param name="accountId">The ID of the specified Account</param>
        /// <returns>Returns all <see cref="Projects"/> for the given accountId</returns>
        /// <seealso cref="Project"/>
        /// <exception cref="ArgumentNullException">Account Id cannot be less than or equal to zero.</exception>
        public Projects GetProjects(int accountId)
        {
            if (accountId <= 0)
                throw new ArgumentNullException(nameof(accountId), "Project ID cannot be less than or equal to zero.");
            RequestPath = $"projects?account_id={accountId}";
            return GetSingleObjectRequest<Projects>();
        }

        /// <summary>
        /// Retrieves all information for a specific Project.
        /// </summary>
        /// <param name="projectId">The ID of the specified Project</param>
        /// <returns>Returns an <see cref="IProject"/> for the given projectId</returns>
        /// <seealso cref="Project"/>
        /// <exception cref="ArgumentNullException">Project Id cannot be less than or equal to zero.</exception>
        public IProject GetProject(int projectId)
        {
            if (projectId <= 0)
                throw new ArgumentNullException(nameof(projectId), "Project ID cannot be less than or equal to zero.");
            RequestPath = $"projects/{projectId}";
            return GetSingleObjectRequest<Project>();
        }

        /// <summary>
        /// Retrieves a list of all Statuses associated with a given Project.
        /// This includes their names, descriptions, associated colors and their due dates.
        /// </summary>
        /// <param name="projectId">The ID of the specified Project</param>
        /// <returns>Returns the <see cref="Statuses"/> for the given projectId</returns>
        /// <seealso cref="Status"/>
        /// <exception cref="ArgumentNullException">Project Id cannot be less than or equal to zero.</exception>
        public Statuses GetStatuses(int projectId)
        {
            if (projectId <= 0)
                throw new ArgumentNullException(nameof(projectId), "Project ID cannot be less than or equal to zero.");
            RequestPath = $"projects/{projectId}/statuses";
            return GetSingleObjectRequest<Statuses>();
        }

        /// <summary>
        /// Retrieves information about a specific Status for a Project.
        /// </summary>
        /// <param name="projectId">The ID of the specified Project</param>
        /// <param name="statusId">The ID of the specified Status</param>
        /// <returns>Returns an <see cref="IStatus"/> for the given projectId and statusId</returns>
        /// <seealso cref="Status"/>
        /// <exception cref="ArgumentNullException">Project Id and Status ID cannot be less than or equal to zero.</exception>
        public IStatus GetStatus(int projectId, int statusId)
        {
            if (projectId <= 0)
                throw new ArgumentNullException(nameof(projectId), "Project ID cannot be less than or equal to zero.");
            if (statusId <= 0)
                throw new ArgumentNullException(nameof(statusId), "Status ID cannot be less than or equal to zero.");
            RequestPath = $"projects/{projectId}/statuses/{statusId}";
            return GetSingleObjectRequest<Status>();
        }

        /// <summary>
        /// Retrieves a list of all items that exist in a particular Project.
        /// </summary>
        /// <param name="projectId">The ID of the specified Project</param>
        /// <returns>Returns a list of <see cref="Pages"/> for the given projectId</returns>
        /// <seealso cref="Page"/>
        /// <exception cref="ArgumentNullException">Project Id cannot be less than or equal to zero.</exception>
        public Pages GetItems(int projectId)
        {
            if (projectId <= 0)
                throw new ArgumentNullException(nameof(projectId), "Project ID cannot be less than or equal to zero.");
            RequestPath = $"items?project_id={projectId}";
            return GetSingleObjectRequest<Pages>();
        }

        /// <summary>
        /// Get all data related to a particular item in a Project.
        /// </summary>
        /// <param name="itemId">The unique ID of the specified Item</param>
        /// <returns>Returns an <see cref="IPage"/> for the given itemId</returns>
        /// <seealso cref="Page"/>
        /// <exception cref="ArgumentNullException">Item Id cannot be less than or equal to zero.</exception>
        public IPage GetItem(int itemId)
        {
            if (itemId <= 0)
                throw new ArgumentNullException(nameof(itemId), "Item ID cannot be less than or equal to zero.");
            RequestPath = $"items/{itemId}";
            return GetSingleObjectRequest<Page>();
        }

        /// <summary>
        /// Get a list of all files related to a particular item.
        /// </summary>
        /// <param name="itemId">The unique ID of the specified Item</param>
        /// <returns>Returns all <see cref="GatherFiles"/> for the given itemId</returns>
        /// <seealso cref="GatherFile"/>
        /// <exception cref="ArgumentNullException">Item Id cannot be less than or equal to zero.</exception>
        public GatherFiles GetFilesForItem(int itemId)
        {
            if (itemId <= 0)
                throw new ArgumentNullException(nameof(itemId), "Item ID cannot be less than or equal to zero.");
            RequestPath = $"items/{itemId}/files";
            return GetSingleObjectRequest<GatherFiles>();
        }

        /// <summary>
        /// Retrieves a list of all Templates associated with the given Project.
        /// </summary>
        /// <param name="projectId">The ID of the specified Project</param>
        /// <returns>Returns all <see cref="Templates"/> for the given projectId</returns>
        /// <seealso cref="Template"/>
        /// <exception cref="ArgumentNullException">Project Id cannot be less than or equal to zero.</exception>
        public Templates GetTemplates(int projectId)
        {
            if (projectId <= 0)
                throw new ArgumentNullException(nameof(projectId), "Project ID cannot be less than or equal to zero.");
            RequestPath = $"templates/?project_id={projectId}";
            return GetSingleObjectRequest<Templates>();
        }

        /// <summary>
        /// This retrieves all data related to a specific Template.
        /// </summary>
        /// <param name="templateId">The ID of the specified Template</param>
        /// <returns>Returns an <see cref="ITemplate"/> for the given templateId</returns>
        /// <seealso cref="Template"/>
        /// <exception cref="ArgumentNullException">Template Id cannot be less than or equal to zero.</exception>
        public ITemplate GetTemplate(int templateId)
        {
            if(templateId <= 0)
                throw new ArgumentNullException(nameof(templateId), "Template ID cannot be less than or equal to zero.");
            RequestPath = $"templates/{templateId}";
            return GetSingleObjectRequest<Template>();
        }

        /// <summary>
        /// Sets up and executes a GET request to the GatherContent API with the specified <see cref="RequestPath"/> 
        /// and Authentication from the app.config.
        /// </summary>
        /// <typeparam name="T">The Type of object for the response to be deserialized into</typeparam>
        /// <returns>The result of the deserialized JSON response</returns>
        public T GetSingleObjectRequest<T>()
        {
            SetRequest(HttpVerbType.Get);
            var response = _request.GetResponse().GetResponseStream();
            if (response == null) throw new HttpException("The Response from the GatherContent API was null");
            var json = new StreamReader(response).ReadToEnd();
            return (T)JsonConvert.DeserializeObject(json, typeof(T));
        }

        #endregion

        #region Post Methods

        /// <summary>
        /// Creates a new Project for a specific Account.  When you create a Project,
        /// a default workflow containing four statuses will be created and associated with it.
        /// </summary>
        /// <param name="accountId">The ID of the Account that you want to associate the new Project</param>
        /// <param name="name">The name you want to give the new Project</param>
        /// <exception cref="ArgumentNullException">Project name and Account Id cannot be null or default values</exception>
        public void CreateProject(int accountId, string name)
        {
            if (accountId <= 0)
                throw new ArgumentNullException(nameof(accountId), "Account ID cannot be less than or equal to zero.");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Project name cannot be empty.");
            RequestPath = $"projects?account_id={accountId}&name={name}";
            PostRequest();
        }

        /// <summary>
        /// Creates a new item within a particular Project.
        /// </summary>
        /// <param name="page"><see cref="Page"/> that will be created in GatherContent</param>
        /// <exception cref="ArgumentNullException">Page name and project Id cannot be null or default values</exception>
        public void CreateItem(Page page)
        {
            if (string.IsNullOrWhiteSpace(page.Name) || page.ProjectId <= 0)
                throw new ArgumentNullException(nameof(page), "The Page being created cannot have a blank name or a project ID less than or equal to 0");
            var templateAddition = (page.TemplateId != null) ? $"&template_id={page.TemplateId}" : string.Empty;
            var encodedFields = JsonConvert.SerializeObject(page.ContentSections);
            var fieldAddition = (page.ContentSections != null) ? $"&config={EncodeFieldsJson(encodedFields)}" : string.Empty;
            RequestPath = $"items?project_id={page.ProjectId}&name={page.Name}&parent_id={page.ParentId}{templateAddition}{fieldAddition}";
            PostRequest();
        }

        /// <summary>
        /// Saves an item with the newly updated data. It expects all the fields
        /// from the item to be passed in, and only changed fields will be updated.
        /// </summary>
        /// <param name="itemId">The ID of the specified item</param>
        /// <param name="ContentSections">All of the <see cref="ISection"/> from the item</param>
        /// <seealso cref="Section"/>
        /// <exception cref="ArgumentNullException">Item ID cannot be less than or equal to zero.</exception>
        public void SaveItem(int itemId, IEnumerable<ISection> ContentSections)
        {        
            if (itemId <= 0)
                throw new ArgumentNullException(nameof(itemId), "Item ID cannot be less than or equal to zero.");
            Page page = new Page();
            page.ContentSections = ContentSections;
            var configPath = $"{EncodeFieldsJson(JsonConvert.SerializeObject(page.ContentSections))}";
            RequestPath = $"items/{itemId}/save?config={configPath}";
            PostRequest();
        }

        /// <summary>
        /// Applies the structure of a Template to an existing Item.
        /// </summary>
        /// <param name="itemId">The ID of the specified Item</param>
        /// <param name="templateId">The ID of the specified Template</param>
        /// <remarks>
        /// Beware: this action will override the existing
        /// structure of an item and will result in loss of content if fields do not match.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Item and Template IDs cannot be less than or equal to zero.</exception>
        public void ApplyTemplate(int itemId, int templateId)
        {
            if (itemId <= 0)
                throw new ArgumentNullException(nameof(itemId), "Item ID cannot be less than or equal to zero.");
            if (templateId <= 0)
                throw new ArgumentNullException(nameof(templateId), "Template ID cannot be less than or equal to zero.");
            RequestPath = $"items/{itemId}/apply_template?template_id={templateId}";
            PostRequest();
        }

        /// <summary>
        /// Apply a <see cref="Status"/> to a particular Item.
        /// </summary>
        /// <param name="itemId">The ID of the specified Item</param>
        /// <param name="statusId">The ID of the specified Status</param>
        /// <exception cref="ArgumentNullException">Item and Status IDs cannot be less than or equal to zero.</exception>
        public void ChooseStatus(int itemId, int statusId)
        {
            if (itemId <= 0)
                throw new ArgumentNullException(nameof(itemId), "Item ID cannot be less than or equal to zero.");
            if (statusId <= 0)
                throw new ArgumentNullException(nameof(statusId), "Status ID cannot be less than or equal to zero.");
            RequestPath = $"items/{itemId}/choose_status?status_id={statusId}";
            PostRequest();
        }

        /// <summary>
        /// Sets up and executes a POST request to the GatherContent API with the specified <see cref="RequestPath"/>
        /// and Authentication from the app.config.
        /// </summary>
        public void PostRequest()
        {
            try
            {
                SetRequest(HttpVerbType.Post);
                var response = (HttpWebResponse) _request.GetResponse();
            }
            catch(WebException wex)
            {
                switch (((HttpWebResponse)wex.Response).StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        throw new InvalidOperationException("The request you made doesn't exist.");
                    case HttpStatusCode.InternalServerError:
                        throw new UnauthorizedAccessException(
                            "You do not have the required privileges to perform this task.");
                }
                throw;
            }
        }

        #endregion

        #endregion

        #region Private Methods

        private void SetRequest(HttpVerbType verbType)
        {
            Logger.DebugFormat("Setting Request \"{0}{1}\" with header information", _serviceUrl, RequestPath);
            _request = (HttpWebRequest)WebRequest.Create(_serviceUrl + RequestPath);
            AddAuthentication();
            _request.Method = verbType.ToString();
            _request.Accept = "application/vnd.gathercontent.v0.5+json";
        }

        private void AddAuthentication()
        {
            Logger.Debug("Adding Authentication to Request");
            _request.Credentials = new CredentialCache { { _serviceUrl, "Basic", new NetworkCredential(ConfigurationManager.AppSettings["ApiUser"], ConfigurationManager.AppSettings["ApiKey"]) } };
            _request.PreAuthenticate = true;
        }

        private static string EncodeFieldsJson(string json)
        {
            if(string.IsNullOrWhiteSpace(json))
                throw new ArgumentNullException(nameof(json), "Section JSON data cannot be null.");
            var byteEncoded = Encoding.UTF8.GetBytes(json);
            var sixFourByteEncoded = Convert.ToBase64String(byteEncoded);
            var urlEncoded = HttpUtility.UrlEncode(sixFourByteEncoded);

            return urlEncoded;
        }

        #endregion
    }
}
