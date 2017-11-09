//
//  Do you like this project? Do you find it helpful? Pay it forward by hiring me as a consultant!
//  https://jason-iverson.com
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM0ney.Framework {
    
    /// <summary>
    /// Utility class related to managing Exceptions
    /// </summary>
    public static class ExceptionHelper {

        /// <summary>
        /// Traverses an exception's inner exception and builds a comprehensive message with all exception details.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static String Traverse(Exception exception) {
            StringBuilder builder = new StringBuilder( );
            Exception realException = exception;
            while(realException != null ) {
                builder.Append( realException.Message );
                realException = realException.InnerException;
                if ( realException != null )
                    builder.Append( Environment.NewLine + Environment.NewLine );
            }
            return builder.ToString( );
        }

    }

}
