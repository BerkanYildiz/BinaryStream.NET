namespace BinaryStream.NET.Extensions
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    using Ionic.Zlib;

    public static partial class StreamReader
    {
        /// <summary>
        /// Reads a byte value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        #if NET5_0
        public static async ValueTask<byte> ReadByteAsync(this Stream Stream)
        #else
        public static async Task<byte> ReadByteAsync(this Stream Stream)
        #endif
        {
            var Buffer = new byte[sizeof(byte)];
            await Stream.ReadAsync(Buffer, 0, Buffer.Length);
            return Buffer[0];
        }

        /// <summary>
        /// Reads a signed byte value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        #if NET5_0
        public static async ValueTask<sbyte> ReadSignedByteAsync(this Stream Stream)
        #else
        public static async Task<sbyte> ReadSignedByteAsync(this Stream Stream)
        #endif
        {
            var Buffer = new byte[sizeof(sbyte)];
            await Stream.ReadAsync(Buffer, 0, Buffer.Length);
            return (sbyte) Buffer[0];
        }

        /// <summary>
        /// Reads a boolean value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        #if NET5_0
        public static async ValueTask<bool> ReadBoolAsync(this Stream Stream)
        #else
        public static async Task<bool> ReadBoolAsync(this Stream Stream)
        #endif
        {
            var Buffer = new byte[sizeof(bool)];
            await Stream.ReadAsync(Buffer, 0, Buffer.Length);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            return BitConverter.ToBoolean(Buffer, 0);
        }

        /// <summary>
        /// Reads a char value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        #if NET5_0
        public static async ValueTask<char> ReadCharAsync(this Stream Stream)
        #else
        public static async Task<char> ReadCharAsync(this Stream Stream)
        #endif
        {
            var Buffer = new byte[sizeof(char)];
            await Stream.ReadAsync(Buffer, 0, Buffer.Length);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            return BitConverter.ToChar(Buffer, 0);
        }

        /// <summary>
        /// Reads a short value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        #if NET5_0
        public static async ValueTask<short> ReadShortAsync(this Stream Stream)
        #else
        public static async Task<short> ReadShortAsync(this Stream Stream)
        #endif
        {
            var Buffer = new byte[sizeof(short)];
            await Stream.ReadAsync(Buffer, 0, Buffer.Length);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            return BitConverter.ToInt16(Buffer, 0);
        }

        /// <summary>
        /// Reads an unsigned short value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        #if NET5_0
        public static async ValueTask<ushort> ReadUnsignedShortAsync(this Stream Stream)
        #else
        public static async Task<ushort> ReadUnsignedShortAsync(this Stream Stream)
        #endif
        {
            var Buffer = new byte[sizeof(ushort)];
            await Stream.ReadAsync(Buffer, 0, Buffer.Length);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            return BitConverter.ToUInt16(Buffer, 0);
        }

        /// <summary>
        /// Reads an integer value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        #if NET5_0
        public static async ValueTask<int> ReadIntegerAsync(this Stream Stream)
        #else
        public static async Task<int> ReadIntegerAsync(this Stream Stream)
        #endif
        {
            var Buffer = new byte[sizeof(int)];
            await Stream.ReadAsync(Buffer, 0, Buffer.Length);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            return BitConverter.ToInt32(Buffer, 0);
        }

        /// <summary>
        /// Reads an unsigned integer value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        #if NET5_0
        public static async ValueTask<uint> ReadUnsignedIntegerAsync(this Stream Stream)
        #else
        public static async Task<uint> ReadUnsignedIntegerAsync(this Stream Stream)
        #endif
        {
            var Buffer = new byte[sizeof(uint)];
            await Stream.ReadAsync(Buffer, 0, Buffer.Length);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            return BitConverter.ToUInt32(Buffer, 0);
        }

        /// <summary>
        /// Reads a long value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        #if NET5_0
        public static async ValueTask<long> ReadLongAsync(this Stream Stream)
        #else
        public static async Task<long> ReadLongAsync(this Stream Stream)
        #endif
        {
            var Buffer = new byte[sizeof(long)];
            await Stream.ReadAsync(Buffer, 0, Buffer.Length);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            return BitConverter.ToInt64(Buffer, 0);
        }

        /// <summary>
        /// Reads an unsigned long value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        #if NET5_0
        public static async ValueTask<ulong> ReadUnsignedLongAsync(this Stream Stream)
        #else
        public static async Task<ulong> ReadUnsignedLongAsync(this Stream Stream)
        #endif
        {
            var Buffer = new byte[sizeof(ulong)];
            await Stream.ReadAsync(Buffer, 0, Buffer.Length);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            return BitConverter.ToUInt64(Buffer, 0);
        }

        /// <summary>
        /// Reads a double value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        #if NET5_0
        public static async ValueTask<double> ReadDoubleAsync(this Stream Stream)
        #else
        public static async Task<double> ReadDoubleAsync(this Stream Stream)
        #endif
        {
            var Buffer = new byte[sizeof(double)];
            await Stream.ReadAsync(Buffer, 0, Buffer.Length);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            return BitConverter.ToDouble(Buffer, 0);
        }

        /// <summary>
        /// Reads a single value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        #if NET5_0
        public static async ValueTask<float> ReadSingleAsync(this Stream Stream)
        #else
        public static async Task<float> ReadSingleAsync(this Stream Stream)
        #endif
        {
            var Buffer = new byte[sizeof(float)];
            await Stream.ReadAsync(Buffer, 0, Buffer.Length);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            return BitConverter.ToSingle(Buffer, 0);
        }
        
        /// <summary>
        /// Reads an enum value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        #if NET5_0
        public static async ValueTask<T> ReadEnumAsync<T>(this Stream Stream) where T : Enum
        #else
        public static async Task<T> ReadEnumAsync<T>(this Stream Stream) where T : Enum
        #endif
        {
            switch (Type.GetTypeCode(typeof(T)))
            {
                case TypeCode.Byte:
                    return (T) Enum.ToObject(typeof(T), (byte) await Stream.ReadByteAsync());

                case TypeCode.SByte:
                    return (T) Enum.ToObject(typeof(T), (sbyte) await Stream.ReadByteAsync());
                    
                case TypeCode.Int16:
                    return (T) Enum.ToObject(typeof(T), await Stream.ReadShortAsync());

                case TypeCode.UInt16:
                    return (T) Enum.ToObject(typeof(T), await Stream.ReadUnsignedShortAsync());

                case TypeCode.Int32:
                    return (T) Enum.ToObject(typeof(T),  await Stream.ReadIntegerAsync());

                case TypeCode.UInt32:
                    return (T) Enum.ToObject(typeof(T),  await Stream.ReadUnsignedIntegerAsync());

                case TypeCode.Int64:
                    return (T) Enum.ToObject(typeof(T),  await Stream.ReadLongAsync());

                case TypeCode.UInt64:
                    return (T) Enum.ToObject(typeof(T),  await Stream.ReadUnsignedLongAsync());

                default:
                    throw new InvalidOperationException("This underlying type of enum is not supported");
            }
        }

        /// <summary>
        /// Reads an array from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="EntryDecoder">The entry decoder.</param>
        #if NET5_0
        public static async ValueTask<T[]> ReadArrayAsync<T>(this Stream Stream, Func<Stream, ValueTask<T>> EntryDecoder)
        #else
        public static async Task<T[]> ReadArrayAsync<T>(this Stream Stream, Func<Stream, Task<T>> EntryDecoder)
        #endif
        {
            var NumberOfEntries = await Stream.ReadLongAsync();

            if (NumberOfEntries == -1)
                return null;

            var Entries = new T[NumberOfEntries];

            for (var EntryId = 0; EntryId < NumberOfEntries; EntryId++)
                Entries[EntryId] = await EntryDecoder(Stream);

            return Entries;
        }

        /// <summary>
        /// Reads an enumerable from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="EntryDecoder">The entry decoder.</param>
        #if NET5_0
        public static async ValueTask<IEnumerable<T>> ReadEnumerableAsync<T>(this Stream Stream, Func<Stream, ValueTask<T>> EntryDecoder)
        #else
        public static async Task<IEnumerable<T>> ReadEnumerableAsync<T>(this Stream Stream, Func<Stream, Task<T>> EntryDecoder)
        #endif
        {
            var NumberOfEntries = await Stream.ReadIntegerAsync();

            if (NumberOfEntries == -1)
                return null;

            var Entries = new T[NumberOfEntries];

            for (var EntryId = 0; EntryId < NumberOfEntries; EntryId++)
                Entries[EntryId] = await EntryDecoder(Stream);

            return Entries;
        }

        /// <summary>
        /// Reads a collection from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="EntryDecoder">The entry decoder.</param>
        #if NET5_0
        public static async ValueTask<ICollection<T>> ReadCollectionAsync<T>(this Stream Stream, Func<Stream, ValueTask<T>> EntryDecoder)
        #else
        public static async Task<ICollection<T>> ReadCollectionAsync<T>(this Stream Stream, Func<Stream, Task<T>> EntryDecoder)
        #endif
        {
            var NumberOfEntries = await Stream.ReadIntegerAsync();

            if (NumberOfEntries == -1)
                return null;

            var Entries = new List<T>(NumberOfEntries);

            for (var EntryId = 0; EntryId < NumberOfEntries; EntryId++)
                Entries.Add(await EntryDecoder(Stream));

            return Entries;
        }

        /// <summary>
        /// Reads a collection from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="EntryDecoder">The entry decoder.</param>
        #if NET5_0
        public static async ValueTask<TCollection> ReadCollectionAsync<TCollection, TEntry>(this Stream Stream, Func<Stream, ValueTask<TEntry>> EntryDecoder) where TCollection : ICollection<TEntry>, new()
        #else
        public static async Task<TCollection> ReadCollectionAsync<TCollection, TEntry>(this Stream Stream, Func<Stream, Task<TEntry>> EntryDecoder) where TCollection : ICollection<TEntry>, new()
        #endif
        {
            var NumberOfEntries = await Stream.ReadIntegerAsync();

            if (NumberOfEntries == -1)
                return default(TCollection);

            var Entries = new TCollection();

            for (var EntryId = 0; EntryId < NumberOfEntries; EntryId++)
                Entries.Add(await EntryDecoder(Stream));

            return Entries;
        }

        /// <summary>
        /// Reads an array from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        #if NET5_0
        public static async ValueTask<byte[]> ReadBufferAsync(this Stream Stream)
        #else
        public static async Task<byte[]> ReadBufferAsync(this Stream Stream)
        #endif
        {
            var NumberOfBytes = await Stream.ReadIntegerAsync();

            if (NumberOfBytes == -1)
                return null;

            var Buffer = new byte[NumberOfBytes];

            if (NumberOfBytes != 0)
                await Stream.ReadAsync(Buffer, 0, Buffer.Length);

            return Buffer;
        }

        /// <summary>
        /// Writes a compressed array to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        #if NET5_0
        public static async ValueTask<byte[]> ReadCompressedBufferAsync(this Stream Stream)
        #else
        public static async Task<byte[]> ReadCompressedBufferAsync(this Stream Stream)
        #endif
        {
            var CompressedBuffer = await Stream.ReadBufferAsync();

            if (CompressedBuffer == null)
                return null;

            if (CompressedBuffer.Length == 0)
                return Array.Empty<byte>();

            return ZlibStream.UncompressBuffer(CompressedBuffer);
        }

        /// <summary>
        /// Reads a string value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Encoding">The string encoding.</param>
        #if NET5_0
        public static async ValueTask<string> ReadStringAsync(this Stream Stream, Encoding Encoding = null)
        #else
        public static async Task<string> ReadStringAsync(this Stream Stream, Encoding Encoding = null)
        #endif
        {
            if (Encoding == null || Encoding.Equals(Encoding.Unicode))
                Encoding = Encoding.BigEndianUnicode;

            var Buffer = await Stream.ReadBufferAsync();

            if (Buffer == null)
                return null;

            if (Buffer.Length == 0)
                return string.Empty;

            return Encoding.GetString(Buffer);
        }
        
        /// <summary>
        /// Reads a compressed string value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Encoding">The string encoding.</param>
        #if NET5_0
        public static async ValueTask<string> ReadCompressedStringAsync(this Stream Stream, Encoding Encoding = null)
        #else
        public static async Task<string> ReadCompressedStringAsync(this Stream Stream, Encoding Encoding = null)
        #endif
        {
            if (Encoding == null || Encoding.Equals(Encoding.Unicode))
                Encoding = Encoding.BigEndianUnicode;

            var Buffer = await Stream.ReadCompressedBufferAsync();

            if (Buffer == null)
                return null;

            if (Buffer.Length == 0)
                return string.Empty;

            return Encoding.GetString(Buffer);
        }

        /// <summary>
        /// Reads a <see cref="DateTime"/> value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <returns>A datetime that is expected to be UTC.</returns>
        #if NET5_0
        public static async ValueTask<DateTime> ReadDateTimeAsync(this Stream Stream)
        #else
        public static async Task<DateTime> ReadDateTimeAsync(this Stream Stream)
        #endif
        {
            var Ticks = await Stream.ReadLongAsync();
            var Value = new DateTime(Ticks, DateTimeKind.Utc);
            return Value;
        }

        /// <summary>
        /// Reads a <see cref="DateTimeOffset"/> value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <returns>A datetime that is expected to be UTC.</returns>
        #if NET5_0
        public static async ValueTask<DateTimeOffset> ReadDateTimeOffsetAsync(this Stream Stream)
        #else
        public static async Task<DateTimeOffset> ReadDateTimeOffsetAsync(this Stream Stream)
        #endif
        {
            var Ticks = await Stream.ReadLongAsync();
            var Offset = await Stream.ReadTimeSpanAsync();
            var Value = new DateTimeOffset(Ticks, Offset);
            return Value;
        }

        /// <summary>
        /// Reads a <see cref="TimeSpan"/> value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        #if NET5_0
        public static async ValueTask<TimeSpan> ReadTimeSpanAsync(this Stream Stream)
        #else
        public static async Task<TimeSpan> ReadTimeSpanAsync(this Stream Stream)
        #endif
        {
            var Ticks = await Stream.ReadLongAsync();
            return new TimeSpan(Ticks);
        }

        /// <summary>
        /// Reads a <see cref="Guid"/> value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        #if NET5_0
        public static async ValueTask<Guid> ReadGuidAsync(this Stream Stream)
        #else
        public static async Task<Guid> ReadGuidAsync(this Stream Stream)
        #endif
        {
            return new Guid(await Stream.ReadBufferAsync());
        }

        /// <summary>
        /// Reads a compressed integer value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        #if NET5_0
        public static async ValueTask<int> ReadCompressedIntegerAsync(this Stream Stream)
        #else
        public static async Task<int> ReadCompressedIntegerAsync(this Stream Stream)
        #endif
        {
            var Byte = await Stream.ReadByteAsync();
            int Result;

            if ((Byte & 0x40) != 0)
            {
                Result = Byte & 0x3F;

                if ((Byte & 0x80) != 0)
                {
                    Result |= ((Byte = await Stream.ReadByteAsync()) & 0x7F) << 6;

                    if ((Byte & 0x80) != 0)
                    {
                        Result |= ((Byte = await Stream.ReadByteAsync()) & 0x7F) << 13;

                        if ((Byte & 0x80) != 0)
                        {
                            Result |= ((Byte = await Stream.ReadByteAsync()) & 0x7F) << 20;

                            if ((Byte & 0x80) != 0)
                            {
                                Result |= ((Byte = await Stream.ReadByteAsync()) & 0x7F) << 27;
                                return (int) (Result | 0x80000000);
                            }

                            return (int) (Result | 0xF8000000);
                        }

                        return (int) (Result | 0xFFF00000);
                    }

                    return (int) (Result | 0xFFFFE000);
                }

                return (int) (Result | 0xFFFFFFC0);
            }
            else
            {
                Result = Byte & 0x3F;

                if ((Byte & 0x80) != 0)
                {
                    Result |= ((Byte = await Stream.ReadByteAsync()) & 0x7F) << 6;

                    if ((Byte & 0x80) != 0)
                    {
                        Result |= ((Byte = await Stream.ReadByteAsync()) & 0x7F) << 13;

                        if ((Byte & 0x80) != 0)
                        {
                            Result |= ((Byte = await Stream.ReadByteAsync()) & 0x7F) << 20;

                            if ((Byte & 0x80) != 0)
                            {
                                Result |= ((Byte = await Stream.ReadByteAsync()) & 0x7F) << 27;
                            }
                        }
                    }
                }
            }

            return Result;
        }

        /// <summary>
        /// Reads a compressed unsigned integer value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        #if NET5_0
        public static async ValueTask<uint> ReadCompressedUnsignedIntegerAsync(this Stream Stream)
        #else
        public static async Task<uint> ReadCompressedUnsignedIntegerAsync(this Stream Stream)
        #endif
        {
            var Byte = await Stream.ReadByteAsync();
            int Result;

            if ((Byte & 0x40) != 0)
            {
                Result = Byte & 0x3F;

                if ((Byte & 0x80) != 0)
                {
                    Result |= ((Byte = await Stream.ReadByteAsync()) & 0x7F) << 6;

                    if ((Byte & 0x80) != 0)
                    {
                        Result |= ((Byte = await Stream.ReadByteAsync()) & 0x7F) << 13;

                        if ((Byte & 0x80) != 0)
                        {
                            Result |= ((Byte = await Stream.ReadByteAsync()) & 0x7F) << 20;

                            if ((Byte & 0x80) != 0)
                            {
                                Result |= ((Byte = await Stream.ReadByteAsync()) & 0x7F) << 27;
                                return (uint) (Result | 0x80000000);
                            }

                            return (uint) (Result | 0xF8000000);
                        }

                        return (uint) (Result | 0xFFF00000);
                    }

                    return (uint) (Result | 0xFFFFE000);
                }

                return (uint) (Result | 0xFFFFFFC0);
            }
            else
            {
                Result = Byte & 0x3F;

                if ((Byte & 0x80) != 0)
                {
                    Result |= ((Byte = await Stream.ReadByteAsync()) & 0x7F) << 6;

                    if ((Byte & 0x80) != 0)
                    {
                        Result |= ((Byte = await Stream.ReadByteAsync()) & 0x7F) << 13;

                        if ((Byte & 0x80) != 0)
                        {
                            Result |= ((Byte = await Stream.ReadByteAsync()) & 0x7F) << 20;

                            if ((Byte & 0x80) != 0)
                            {
                                Result |= ((Byte = await Stream.ReadByteAsync()) & 0x7F) << 27;
                            }
                        }
                    }
                }
            }

            return (uint) Result;
        }
    }
}
