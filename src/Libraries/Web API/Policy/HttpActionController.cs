using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MixERP.Net.ApplicationState.Cache;
using MixERP.Net.Common.Extensions;
using PetaPoco;

namespace MixERP.Net.Api.Policy
{
    /// <summary>
    ///     Provides a direct HTTP access to perform various tasks such as adding, editing, and removing Http Actions.
    /// </summary>
    [RoutePrefix("api/v1.5/policy/http-action")]
    public class HttpActionController : ApiController
    {
        /// <summary>
        ///     The HttpAction data context.
        /// </summary>
        private readonly MixERP.Net.Schemas.Policy.Data.HttpAction HttpActionContext;

        public HttpActionController()
        {
            this.LoginId = AppUsers.GetCurrent().View.LoginId.ToLong();
            this.UserId = AppUsers.GetCurrent().View.UserId.ToInt();
            this.OfficeId = AppUsers.GetCurrent().View.OfficeId.ToInt();
            this.Catalog = AppUsers.GetCurrentUserDB();

            this.HttpActionContext = new MixERP.Net.Schemas.Policy.Data.HttpAction
            {
                Catalog = this.Catalog,
                LoginId = this.LoginId
            };
        }

        public long LoginId { get; }
        public int UserId { get; private set; }
        public int OfficeId { get; private set; }
        public string Catalog { get; }

        /// <summary>
        ///     Counts the number of http actions.
        /// </summary>
        /// <returns>Returns the count of the http actions.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("count")]
        public long Count()
        {
            try
            {
                return this.HttpActionContext.Count();
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Returns an instance of http action.
        /// </summary>
        /// <param name="httpActionCode">Enter HttpActionCode to search for.</param>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("{httpActionCode}")]
        public MixERP.Net.Entities.Policy.HttpAction Get(string httpActionCode)
        {
            try
            {
                return this.HttpActionContext.Get(httpActionCode);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Creates a paginated collection containing 25 http actions on each page, sorted by the property HttpActionCode.
        /// </summary>
        /// <returns>Returns the first page from the collection.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("")]
        public IEnumerable<MixERP.Net.Entities.Policy.HttpAction> GetPagedResult()
        {
            try
            {
                return this.HttpActionContext.GetPagedResult();
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Creates a paginated collection containing 25 http actions on each page, sorted by the property HttpActionCode.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset.</param>
        /// <returns>Returns the requested page from the collection.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("page/{pageNumber}")]
        public IEnumerable<MixERP.Net.Entities.Policy.HttpAction> GetPagedResult(long pageNumber)
        {
            try
            {
                return this.HttpActionContext.GetPagedResult(pageNumber);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Displayfields is a lightweight key/value collection of http actions.
        /// </summary>
        /// <returns>Returns an enumerable key/value collection of http actions.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("display-fields")]
        public IEnumerable<DisplayField> GetDisplayFields()
        {
            try
            {
                return this.HttpActionContext.GetDisplayFields();
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Adds your instance of Account class.
        /// </summary>
        /// <param name="httpAction">Your instance of http actions class to add.</param>
        [AcceptVerbs("POST")]
        [Route("add/{httpAction}")]
        public void Add(MixERP.Net.Entities.Policy.HttpAction httpAction)
        {
            if (httpAction == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                this.HttpActionContext.Add(httpAction);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Edits existing record with your instance of Account class.
        /// </summary>
        /// <param name="httpAction">Your instance of Account class to edit.</param>
        /// <param name="httpActionCode">Enter the value for HttpActionCode in order to find and edit the existing record.</param>
        [AcceptVerbs("PUT")]
        [Route("edit/{httpActionCode}/{httpAction}")]
        public void Edit(string httpActionCode, MixERP.Net.Entities.Policy.HttpAction httpAction)
        {
            if (httpAction == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                this.HttpActionContext.Update(httpAction, httpActionCode);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Deletes an existing instance of Account class via HttpActionCode.
        /// </summary>
        /// <param name="httpActionCode">Enter the value for HttpActionCode in order to find and delete the existing record.</param>
        [AcceptVerbs("DELETE")]
        [Route("delete/{httpActionCode}")]
        public void Delete(string httpActionCode)
        {
            try
            {
                this.HttpActionContext.Delete(httpActionCode);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }
    }
}