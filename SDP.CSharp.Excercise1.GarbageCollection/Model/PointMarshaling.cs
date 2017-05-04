using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SDP.CSharp.Excercise1.GarbageCollection.Model
{
    /// <summary>
    /// This class represents a complex dispose pattern example
    /// </summary>
    class PointMarshaling : IDisposable
    {
        // an unmanaged pointer field
        private IntPtr mPointPointer;

        /// <summary>
        /// Marshals provided point structure and allocates an unmanaged memory location for it
        /// </summary>
        /// <param name="p">point to marshal</param>
        public void MarshalPoint(Point p)
        {
            // Initialize unmanged memory to hold the struct.
            mPointPointer = Marshal.AllocHGlobal(Marshal.SizeOf(p));

            // Copy the struct to unmanaged memory.
            Marshal.StructureToPtr(p, mPointPointer, false);
        }

        /// <summary>
        /// Unmarshals previously marshaled point and returns retrieved structure
        /// </summary>
        /// <returns>unmarshaled point structure</returns>
        public Point UnmarshalPoint()
        {
            // Create another point.
            Point anotherP;

            // Set this Point to the value of the 
            // Point in unmanaged memory. 
            anotherP = (Point)Marshal.PtrToStructure(mPointPointer, typeof(Point));

            return anotherP;
        }

        // This code added to correctly implement the disposable pattern.
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
                
                // Free the unmanaged memory.
                Marshal.FreeHGlobal(mPointPointer);

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~PointMarshaling()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        /// <summary>
        /// Disposes all resources held by this instance
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: comment the following line if the finalizer is NOT overridden above.
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
