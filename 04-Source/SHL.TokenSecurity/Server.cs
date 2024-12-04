using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SHL.TokenSecurity
{
    /// <summary>
    /// Server.
    /// </summary>
    public static class Server
    {
        private static String _WebRootPath;

        /// <summary>
        /// Gets or sets the web root path.
        /// </summary>
        /// <value>The web root path.</value>
        public static String WebRootPath
        {
            get { return _WebRootPath; }
            set { _WebRootPath = value; }
        }

        /// <summary>
        /// Maps the path.
        /// </summary>
        /// <returns>The path.</returns>
        /// <param name="path">Path.</param>
        public static String MapPath(String path)
        {
            var filePath = Path.Combine(_WebRootPath, path);

            return filePath;
        }

    }
}
