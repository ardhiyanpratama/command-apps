using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandApps.Helper
{
    public class ResponseBase
    {
        #region Fields

        private List<ResponseException> _exceptions;

        #endregion

        public ResponseBase()
        {
            this._exceptions = new List<ResponseException>();
        }

        #region Properties

        public IEnumerable<ResponseException> Exceptions
        {
            get { return this._exceptions; }
        }

        public bool HasError
        {
            get { return this._exceptions.Count != 0; }
        }

        #endregion

        #region (public) Methods

        public void AddException(int errorCode, string errorMessage)
        {
            this._exceptions.Add(new ResponseException(errorCode, errorMessage));
        }

        public void AddException(ResponseException exception)
        {
            this._exceptions.Add(exception);
        }

        public void AddExceptions(IEnumerable<ResponseException> exceptions)
        {
            this._exceptions.AddRange(exceptions);
        }

        #endregion
    }
}
