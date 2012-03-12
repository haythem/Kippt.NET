using System;
using System.Runtime.Serialization;

namespace Kippt
{
    /// <summary>
    /// Provides rights for sending and receiving data.
    /// </summary>
    [DataContract(IsReference = false)]
    public class KipptClient
    {
        #region Private Methods

        /// <summary>
        /// Instance of <see cref="KipptSession"/> class used to execute queries.
        /// </summary>
        protected static KipptSession Session { get; set; }

        #endregion Private Methods

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="KipptClient"/> class.
        /// </summary>
        public KipptClient()
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of <see cref="KipptClient"/> class.
        /// </summary>
        /// 
        /// <param name="session">Authentication credentials.</param>
        public KipptClient(KipptSession session)
        {
            Session = session;
        }

        #endregion Constructors

        #region Events

        private delegate void EventHandler(object sender, KipptEventArgs e);

        private static event EventHandler OperationExecuted;
        /// <summary>
        /// Occurs when a query has successfully been executed.
        /// </summary>
        /// 
        /// <param name="e">Event arguments.</param>
        protected static void OnOperationExecuted(KipptEventArgs e)
        {
            if (OperationExecuted != null)
                OperationExecuted(null, e);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Check if the session is present.
        /// </summary>
        private void Initialize()
        {
            if (Session == null)
                throw new KipptException("Session is null !");
        }

        #endregion Private Methods
    }
}