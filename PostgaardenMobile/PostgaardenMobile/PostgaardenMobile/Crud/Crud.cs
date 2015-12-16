using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postgaarden.Connection;

namespace Postgaarden.Crud
{
    /*
        Developed by Chris Wohlert
    */
    public abstract class Crud<T, TKey>
    {
        /// <summary>
        /// Gets or sets the database connection.
        /// </summary>
        /// <value>
        /// The database connection.
        /// </value>
        protected DatabaseConnection DBConnection{ get; set; }
        /// <summary>
        /// Creates the specified entry.
        /// </summary>
        /// <param name="entry">The entry.</param>
        public abstract void Create(T entry);
        /// <summary>
        /// Reads this instance.
        /// </summary>
        /// <returns>Returns every T from the database connection</returns>
        public abstract IEnumerable<T> Read();
        /// <summary>
        /// Reads the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Returns the T with the TKey primary key from the database connection</returns>
        public abstract T Read(TKey key);
        /// <summary>
        /// Updates the specified entry.
        /// </summary>
        /// <param name="entry">The entry.</param>
        public abstract void Update(T entry);
        /// <summary>
        /// Deletes the specified entry.
        /// </summary>
        /// <param name="entry">The entry.</param>
        public abstract void Delete(T entry);
    }
}
