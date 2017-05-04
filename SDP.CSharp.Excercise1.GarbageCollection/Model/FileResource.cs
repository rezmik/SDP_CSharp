using System;
using System.IO;

namespace SDP.CSharp.Excercise1.GarbageCollection.Model
{
    /// <summary>
    /// This class represents a simple dispose pattern scenario, only managed resources need to be disposed
    /// </summary>
    class FileResource : IDisposable
    {
        private StreamWriter mStreamWriter;

        /// <summary>
        /// Create new instance of FileResource class
        /// </summary>
        public FileResource()
        {
            mStreamWriter = File.CreateText("ExampleTextFile.txt");
        }

        /// <summary>
        /// Writes provided string to the file
        /// </summary>
        /// <param name="s">string to write to file</param>
        public void WriteToFile(string s)
        {
            mStreamWriter.Write(s);
        }

        // This code added to correctly implement the simple disposable pattern.
        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        /// <summary>
        /// Disposes all resources held by this instance
        /// </summary>
        public void Dispose()
        {
            if (!disposedValue)
            {
                mStreamWriter.Flush();
                mStreamWriter.Close();
                mStreamWriter.Dispose();

                disposedValue = true;
            }
        }

        #endregion
    }
}
