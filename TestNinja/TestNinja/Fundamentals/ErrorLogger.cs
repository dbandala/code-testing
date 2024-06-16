
using System;

namespace TestNinja.Fundamentals
{
    public class ErrorLogger
    {
        public string LastError { get; set; }

        public event EventHandler<Guid> ErrorLogged; 
        
        public void Log(string error)
        {
            if (String.IsNullOrWhiteSpace(error))
                throw new ArgumentNullException();
                
            LastError = error;

            // Write the log to a storage
            // ...

            //ErrorLogged?.Invoke(this, Guid.NewGuid());
            OnErrorLogger(Guid.NewGuid());
        }

        protected void OnErrorLogger(Guid errorId) {
            ErrorLogged?.Invoke(this, errorId);
        }
    }
}