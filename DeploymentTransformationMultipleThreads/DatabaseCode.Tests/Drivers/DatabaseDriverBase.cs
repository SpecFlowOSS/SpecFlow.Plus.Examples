using System;
using DatabaseCode.Tests.Support;

namespace DatabaseCode.Tests.Drivers
{
    public abstract class DatabaseDriverBase
        : IDisposable
    {
        protected DatabaseDriverBase(DatabaseContextWrapper dbContext, DriverPersonState state)
        {
            DbContext = dbContext;
            State = state;
        }

        ~DatabaseDriverBase()
        {
            Dispose(false);
        }

        protected DatabaseContextWrapper DbContext { get; }

        protected DriverPersonState State { get; }

        protected bool IsDisposed { get; private set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed)
            {
                return;
            }

            DbContext.Dispose();
            IsDisposed = true;
        }
    }
}
