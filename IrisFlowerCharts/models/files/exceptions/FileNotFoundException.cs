using System;

#nullable enable

namespace IrisFlowerCharts.Files.Exceptions
{
    /// <summary>Represents error that occur in case of attempt to open non-existent file.</summary>
    public class FileNotFoundException : Exception
    {
        /// <inheritdoc cref="Exception.Exception"/>
        public FileNotFoundException() 
            : base()
        { 
        }

        /// <inheritdoc cref="Exception.Exception(string?)"/>
        public FileNotFoundException(string message) 
            : base(message) 
        { 
        }

        /// <inheritdoc cref="Exception.Exception(string?, Exception?)"/>
        public FileNotFoundException(string? message, Exception? inner) 
            : base(message, inner) 
        { 
        }
    }
}
