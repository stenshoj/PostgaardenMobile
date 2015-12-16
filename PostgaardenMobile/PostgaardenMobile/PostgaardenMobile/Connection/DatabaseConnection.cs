using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postgaarden.Connection
{
    /*
        Developed by Chris Wohlert
    */
    public abstract class DatabaseConnection
    {
        /// <summary>
        /// Opens this instance.
        /// </summary>
        protected abstract void Open();
        /// <summary>
        /// Closes this instance.
        /// </summary>
        protected abstract void Close();
        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <returns></returns>
        public abstract IEnumerable<IEnumerable<object>> ExecuteQuery(string sql);
    }
}
