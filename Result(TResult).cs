//
//	Do you like this project? Do you find it helpful? Pay it forward by hiring me as a consultant!
//  https://jason-iverson.com
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM0ney.Framework {

    /// <summary>
    /// Represents the result of some action allowing for a return value
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public class Result<TResult> : Result, ITypedResult {

        #region Fields

        private readonly TResult _ReturnValue = default( TResult );

        #endregion Fields

        #region Constructor(s)

        internal Result( bool isSuccess, String message, Exception exception, TResult returnValue )
            : base( isSuccess, message, exception ) {
            this._ReturnValue = returnValue;
        }

        #endregion Constructor(s)

        #region Properties
        
        /// <summary>
        /// The return value returned as a result of some action being performed
        /// </summary>
        public TResult ReturnValue {
            get {
                return _ReturnValue;
            }
        }

        #endregion Properties

        #region Interface implementations

        Object ITypedResult.ReturnValue {
            get { return this.ReturnValue; }
        }

        #endregion Interface implementations

    }
}
