namespace CH04_Finalization
{
    using System;

    public class DisposableBase : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
                GC.SuppressFinalize(this);
            ReleaseManagedResources();
            ReleaseUnmanagedResources();
        }

        protected virtual void ReleaseManagedResources()
        {

        }

        protected virtual void ReleaseUnmanagedResources()
        {

        }
    }
}
