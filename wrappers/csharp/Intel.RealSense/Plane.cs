using System;
using System.Runtime.InteropServices;

namespace Intel.RealSense
{
    public class Plane: IDisposable
    {
        internal HandleRef m_instance;
        public Plane(IntPtr ptr)
        {
            m_instance = new HandleRef(this, ptr);
            object e;
            Rms = NativeMethods.rs2_get_plane_rms(m_instance.Handle, out e);
            Valid = NativeMethods.rs2_is_plane_valid(m_instance.Handle, out e) == 1;
        }
        public float Rms { get; private set; }
        public bool Valid { get; private set; }

        public void Delete()
        {
            if (m_instance.Handle != IntPtr.Zero)
                NativeMethods.rs2_delete_plane(m_instance.Handle);
            m_instance = new HandleRef(this, IntPtr.Zero);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                Delete();
                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~Plane()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
