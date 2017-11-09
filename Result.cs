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
    /// Represents the result of some action
    /// </summary>
    public class Result : IResult {

        #region Fields

        private bool _IsSuccess = false;
        private String _Message = String.Empty;
        private Exception _Exception = null;

        #endregion Fields

        #region Constructor(s)

        internal Result( bool isSuccess, String message, Exception exception ) {
            this.IsSuccess = isSuccess;
            this.Message = message;
            this.Exception = exception;
        }

        #endregion Constructor(s)

        #region Properties

        /// <summary>
        /// Indicates whether or not the action completed successfully
        /// </summary>
        public Boolean IsSuccess {
            get {
                return _IsSuccess;
            }
            set {
                this._IsSuccess = value;
            }
        }

        /// <summary>
        /// Message indicating the state of the action that was executed
        /// </summary>
        public String Message {
            get {
                return _Message;
            }
            set {
                this._Message = value;
            }
        }

        /// <summary>
        /// Exception associated with the recently executed action
        /// </summary>
        public Exception Exception {
            get {
                return _Exception;
            }
            set {
                this._Exception = value;
            }
        }

        #endregion Properties

        #region Static accessors

        public static Result SuccessResult( ) {
            return new Result( true, Localization.Messages.Success, null );
        }

        public static Result SuccessResult( String message ) {
            return new Result( true, message, null );
        }

        public static Result ErrorResult(String message ) {
            return new Result( false, message, null );
        }

        public static Result ErrorResult(String message, Exception exception ) {
            return new Result( false, message, exception );
        }


        public static Result<TResult> SuccessResult<TResult>( TResult returnValue ) {
            return new Result<TResult>( true, Localization.Messages.Success, null, returnValue );
        }

        public static Result<TResult> SuccessResult<TResult>( String message, TResult returnValue ) {
            return new Result<TResult>( true, message, null, returnValue );
        }

        public static Result<TResult> ErrorResult<TResult>( String message ) {
            return new Result<TResult>( false, message, null, default( TResult ) );
        }

        public static Result<TResult> ErrorResult<TResult>( String message, Exception exception ) {
            return new Result<TResult>( false, message, exception, default( TResult ) );
        }

        #endregion Static accessors

        public override String ToString( ) {
            String message = this.Message;
            if ( !this.IsSuccess ) {
                message = String.Format( Localization.ErrorMessages.Generic_FS, Localization.ErrorMessages.Error, this.Message );
            }
            if ( this.Exception != null ) {
                message = String.Format( "{0}{1}{1}{2}", message, Environment.NewLine, ExceptionHelper.Traverse( this.Exception ) );
            }
            return message;
        }
    }



}
