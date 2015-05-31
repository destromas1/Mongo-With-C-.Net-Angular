// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataAccessController.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace MongoDbRestServer.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using MongoDB.Bson;
    using MongoDB.Driver;

    /// <summary>
    /// The entity.
    /// </summary>
    public class EntityDto
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        #endregion
    }


    public class EntityVm
    {
        #region Public Properties
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        #endregion
    }



    /// <summary>
    /// The data access controller.
    /// </summary>
    public class DataAccessController : ApiController
    {
        #region Constants

        /// <summary>
        ///     The connection string.
        /// </summary>
        private const string ConnectionString = "mongodb://localhost";

        #endregion

        #region Fields

        /// <summary>
        ///     The collection.
        /// </summary>
        private readonly MongoCollection<EntityDto> collection = null;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DataAccessController"/> class.
        /// </summary>
        public DataAccessController()
        {
            var client = new MongoClient(ConnectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("myDb");
            this.collection = database.GetCollection<EntityDto>("entities");
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void Delete(int id)
        {
        }

        // GET api/dataaccess
        /// <summary>
        /// The get.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<EntityVm> Get()
        {
            List<EntityVm> vms = new List<EntityVm>();
            var dtoList = this.collection.FindAll();
            foreach (EntityDto entity in dtoList)
            {
                vms.Add(new EntityVm { Name = entity.Name });
            }
            return vms;
        }

        // GET api/dataaccess/5
        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string Get(int id)
        {
            return null;
        }

        // POST api/dataaccess
        /// <summary>
        /// The post.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Post([FromBody] EntityVm entity)
        {
            this.collection.Insert(entity);
        }

        // PUT api/dataaccess/5
        /// <summary>
        /// The put.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        public void Put(int id, [FromBody] string value)
        {
        }

        #endregion

        // DELETE api/dataaccess/5
    }
}