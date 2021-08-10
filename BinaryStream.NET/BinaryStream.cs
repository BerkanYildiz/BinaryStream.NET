namespace BinaryStream.NET
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    public enum BpStreamPermission
    {
        None = 0,
        Read = 1,
        Write = 2,
        ReadWrite = 4,
        Maximum = ReadWrite
    }

    public class BinaryStream : Stream
    {
        /// <summary>
        /// When overridden in a derived class,
        /// gets a value indicating whether the current stream supports reading.
        /// </summary>
        public override bool CanRead
        {
            get;
        }

        /// <summary>
        /// When overridden in a derived class,
        /// gets a value indicating whether the current stream supports seeking.
        /// </summary>
        public override bool CanSeek
        {
            get;
        }

        /// <summary>
        /// When overridden in a derived class,
        /// gets a value indicating whether the current stream supports writing.
        /// </summary>
        public override bool CanWrite
        {
            get;
        }

        /// <summary>
        /// Gets a value indicating whether we can resize the buffer.
        /// </summary>
        public bool CanResize
        {
            get;
        }

        /// <summary>
        /// When overridden in a derived class,
        /// gets the length in bytes of the stream.
        /// </summary>
        public override long Length => this.Buffer?.LongLength ?? 0;

        /// <summary>
        /// When overridden in a derived class,
        /// gets or sets the position within the current stream.
        /// </summary>
        public override long Position
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the number of bytes read from this this stream.
        /// </summary>
        public long NumberOfBytesRead
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the number of bytes written into this this stream.
        /// </summary>
        public long NumberOfBytesWritten
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the number of bytes left.
        /// </summary>
        public long NumberOfBytesLeft => this.Length - this.Position;

        /// <summary>
        /// Gets a value indicating whether the end of the stream was reached.
        /// </summary>
        public bool IsEndOfStream => this.NumberOfBytesLeft == 0;

        /// <summary>
        /// Gets the buffer.
        /// </summary>
        public byte[] Buffer
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryStream"/> class.
        /// </summary>
        public BinaryStream()
        {
            // 
            // Setup the buffer.
            // 

            this.Buffer = new byte[0];

            // 
            // Setup the permissions.
            // 
            
            this.CanRead = true;
            this.CanWrite = true;
            this.CanSeek = false;
            this.CanResize = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryStream"/> class.
        /// </summary>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="Permission">The permission.</param>
        public BinaryStream(byte[] Buffer, BpStreamPermission Permission = BpStreamPermission.ReadWrite)
        {
            if (Buffer == null)
            {
                // throw new ArgumentNullException(nameof(Buffer));
            }

            // 
            // Setup the buffer.
            // 

            this.Buffer = Buffer;

            // 
            // Setup the permissions.
            // 

            this.CanRead = Permission == BpStreamPermission.Read || Permission == BpStreamPermission.ReadWrite;
            this.CanWrite = Permission == BpStreamPermission.Write || Permission == BpStreamPermission.ReadWrite;
            this.CanSeek = false;
            this.CanResize = false;
        }

        /// <summary>
        /// Ensures the buffer is capable of holding the specified amount of data.
        /// </summary>
        /// <param name="InRequestedCapacity">The desired length of the current stream in bytes.</param>
        public void EnsureCapacity(long InRequestedCapacity)
        {
            // 
            // Check if we need a resize.
            // 

            if (this.Buffer?.Length >= InRequestedCapacity)
            {
                return;
            }

            // 
            // Check if resizing is allowed.
            // 

            if (this.CanResize == false)
            {
                throw new NotSupportedException("The stream cannot be resized");
            }

            // 
            // Allocate memory for the new buffer and zero it.
            // 

            var NewBuffer = new byte[InRequestedCapacity];

            // 
            // If we previous had a buffer, copy its content to the new buffer.
            // 

            if (this.Buffer != null)
            {
                Array.Copy(this.Buffer, 0, NewBuffer, 0, this.Buffer.Length);
            }

            // 
            // Set the new buffer to this stream.
            // 

            this.Buffer = NewBuffer;
        }

        /// <summary>
        /// When overridden in a derived class,
        /// reads a sequence of bytes from the current stream and advances the position within the stream by the number of bytes read.
        /// </summary>
        /// <param name="InBuffer">An array of bytes. When this method returns, the buffer contains the specified byte array with the values between <paramref name="InOffset" /> and (<paramref name="InOffset" /> + <paramref name="InCount" /> - 1) replaced by the bytes read from the current source.</param>
        /// <param name="InOffset">The zero-based byte offset in <paramref name="InBuffer" /> at which to begin storing the data read from the current stream.</param>
        /// <param name="InCount">The maximum number of bytes to be read from the current stream.</param>
        public override int Read(byte[] InBuffer, int InOffset, int InCount)
        {
            if (!this.CanRead)
            {
                throw new NotSupportedException("Failed to read from the buffer, no read permission.");
            }

            // 
            // Sanity checks.
            // 

            if (InOffset >= InBuffer.Length)
            {
                throw new ArgumentException("The offset is out of the buffer range.");
            }

            if (InOffset + InCount > InBuffer.Length)
            {
                throw new ArgumentException("The offset + count is out of the buffer range.");
            }

            // 
            // Read from the buffer.
            // 

            var BytesRead = 0;

            if (InCount > 0)
            {
                // 
                // Verify if we are not going out of range.
                // 

                BytesRead = InCount;

                if (this.Position + InCount >= this.Length)
                {
                    BytesRead = (int) this.NumberOfBytesLeft;

                    if (BytesRead == 0)
                    {
                        throw new InternalBufferOverflowException("The stream has reached the end of the buffer.");
                    }
                }

                // 
                // Copy the byte(s) to the provided buffer.
                // 

                Array.Copy(this.Buffer, this.Position, InBuffer, InOffset, BytesRead);

                // 
                // Advance the cursor position.
                // 

                this.Position += InCount;
                this.NumberOfBytesRead += InCount;
            }

            return BytesRead;
        }

        /// <summary>
        /// When overridden in a derived class, writes a sequence of bytes to the current stream and advances the current position within this stream by the number of bytes written.
        /// </summary>
        /// <param name="InBuffer">An array of bytes. This method copies <paramref name="InCount" /> bytes from <paramref name="InBuffer" /> to the current stream.</param>
        /// <param name="InOffset">The zero-based byte offset in <paramref name="InBuffer" /> at which to begin copying bytes to the current stream.</param>
        /// <param name="InCount">The number of bytes to be written to the current stream.</param>
        public override void Write(byte[] InBuffer, int InOffset, int InCount)
        {
            if (!this.CanWrite)
            {
                throw new NotSupportedException("Failed to write into the buffer, no write permission.");
            }

            // 
            // Sanity checks.
            // 

            if (InOffset >= InBuffer.Length)
            {
                throw new ArgumentException("The offset is out of the buffer range.");
            }

            if (InOffset + InCount > InBuffer.Length)
            {
                throw new ArgumentException("The offset + count is out of the buffer range.");
            }

            // 
            // Write into the buffer.
            // 

            if (InCount > 0)
            {
                // 
                // Verify that we are not going out of range.
                // 

                this.EnsureCapacity(this.Position + InCount);

                // 
                // Copy the byte(s) to the stream's buffer.
                // 

                Array.Copy(InBuffer, InOffset, this.Buffer, this.Position, InCount);

                // 
                // Advance the cursor position.
                // 

                this.Position += InCount;
                this.NumberOfBytesWritten += InCount;
            }
        }

        /// <summary>
        /// When overridden in a derived class,
        /// sets the position within the current stream.
        /// </summary>
        /// <param name="InOffset">A byte offset relative to the <paramref name="InOrigin" /> parameter.</param>
        /// <param name="InOrigin">A value of type <see cref="SeekOrigin" /> indicating the reference point used to obtain the new position.</param>
        public override long Seek(long InOffset, SeekOrigin InOrigin)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// When overridden in a derived class,
        /// sets the length of the current stream.
        /// </summary>
        /// <param name="InValue">The desired length of the current stream in bytes.</param>
        public override void SetLength(long InValue)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Copies this stream's content to the given buffer.
        /// </summary>
        /// <param name="InBuffer">The buffer.</param>
        /// <param name="InOffset">The start index into the buffer.</param>
        /// <param name="InLength">The number of bytes to copy into the buffer.</param>
        public void CopyTo(byte[] InBuffer, int InOffset, int InLength)
        {
            // 
            // Check if we have enough bytes in this stream to copy to the buffer.
            // 

            if (InLength > this.Length)
            {
                throw new InvalidOperationException("The stream does not have enough bytes to copy to the given buffer.");
            }

            // 
            // Copy the stream's data to the buffer.
            // 

            System.Buffer.BlockCopy(this.Buffer, 0, InBuffer, InOffset, InLength);
        }

        /// <summary>
        /// Asynchronously reads the bytes from the current stream and writes them to another stream, using a specified buffer size and cancellation token.
        /// </summary>
        /// <param name="Destination">The stream to which the contents of the current stream will be copied.</param>
        /// <param name="BufferSize">The size, in bytes, of the buffer. This value must be greater than zero. The default size is 81920.</param>
        /// <param name="CancellationToken">The token to monitor for cancellation requests. The default value is <see cref="P:System.Threading.CancellationToken.None" />.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="Destination" /> is <see langword="null" />.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// <paramref name="BufferSize" /> is negative or zero.</exception>
        /// <exception cref="T:System.ObjectDisposedException">Either the current stream or the destination stream is disposed.</exception>
        /// <exception cref="T:System.NotSupportedException">The current stream does not support reading, or the destination stream does not support writing.</exception>
        /// <returns>A task that represents the asynchronous copy operation.</returns>
        public override Task CopyToAsync(Stream Destination, int BufferSize, CancellationToken CancellationToken)
        {
            return Task.Run(() => this.CopyTo(Destination, BufferSize), CancellationToken);
        }

        /// <summary>
        /// When overridden in a derived class,
        /// clears all buffers for this stream and causes any buffered data to be written to the underlying device.
        /// </summary>
        public override void Flush()
        {
            throw new NotSupportedException("Flushing this stream is not supported.");
        }
    }
}