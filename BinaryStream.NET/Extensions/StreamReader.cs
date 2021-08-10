namespace BinaryStream.NET.Extensions
{
    using System;
    using System.IO;
    using System.Text;

    using Ionic.Zlib;

    public static partial class StreamReader
    {
        /// <summary>
        /// Reads a byte value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        public static byte ReadByte(this Stream Stream)
        {
            var Buffer = new byte[sizeof(byte)];
            Stream.Read(Buffer);
            return Buffer[0];
        }

        /// <summary>
        /// Reads a signed byte value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        public static sbyte ReadSignedByte(this Stream Stream)
        {
            var Buffer = new byte[sizeof(sbyte)];
            Stream.Read(Buffer);
            return (sbyte) Buffer[0];
        }

        /// <summary>
        /// Reads a boolean value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        public static bool ReadBool(this Stream Stream)
        {
            var Buffer = new byte[sizeof(bool)];
            Stream.Read(Buffer);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            return BitConverter.ToBoolean(Buffer);
        }

        /// <summary>
        /// Reads a char value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        public static char ReadChar(this Stream Stream)
        {
            var Buffer = new byte[sizeof(char)];
            Stream.Read(Buffer);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            return BitConverter.ToChar(Buffer);
        }

        /// <summary>
        /// Reads a short value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        public static short ReadShort(this Stream Stream)
        {
            var Buffer = new byte[sizeof(short)];
            Stream.Read(Buffer);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            return BitConverter.ToInt16(Buffer);
        }

        /// <summary>
        /// Reads an unsigned short value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        public static ushort ReadUnsignedShort(this Stream Stream)
        {
            var Buffer = new byte[sizeof(ushort)];
            Stream.Read(Buffer);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            return BitConverter.ToUInt16(Buffer);
        }

        /// <summary>
        /// Reads an integer value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        public static int ReadInteger(this Stream Stream)
        {
            var Buffer = new byte[sizeof(int)];
            Stream.Read(Buffer);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            return BitConverter.ToInt32(Buffer);
        }

        /// <summary>
        /// Reads an unsigned integer value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        public static uint ReadUnsignedInteger(this Stream Stream)
        {
            var Buffer = new byte[sizeof(uint)];
            Stream.Read(Buffer);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            return BitConverter.ToUInt32(Buffer);
        }

        /// <summary>
        /// Reads a long value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        public static long ReadLong(this Stream Stream)
        {
            var Buffer = new byte[sizeof(long)];
            Stream.Read(Buffer);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            return BitConverter.ToInt64(Buffer);
        }

        /// <summary>
        /// Reads an unsigned long value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        public static ulong ReadUnsignedLong(this Stream Stream)
        {
            var Buffer = new byte[sizeof(ulong)];
            Stream.Read(Buffer);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            return BitConverter.ToUInt64(Buffer);
        }

        /// <summary>
        /// Reads a double value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        public static double ReadDouble(this Stream Stream)
        {
            var Buffer = new byte[sizeof(double)];
            Stream.Read(Buffer);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            return BitConverter.ToDouble(Buffer);
        }

        /// <summary>
        /// Reads a single value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        public static float ReadSingle(this Stream Stream)
        {
            var Buffer = new byte[sizeof(float)];
            Stream.Read(Buffer);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            return BitConverter.ToSingle(Buffer);
        }

        /// <summary>
        /// Reads an enum value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        public static T ReadEnum<T>(this Stream Stream) where T : Enum
        {
            switch (Type.GetTypeCode(typeof(T)))
            {
                case TypeCode.Byte:
                    return (T) Enum.ToObject(typeof(T), (byte) Stream.ReadByte());

                case TypeCode.SByte:
                    return (T) Enum.ToObject(typeof(T), (sbyte) Stream.ReadByte());
                    
                case TypeCode.Int16:
                    return (T) Enum.ToObject(typeof(T), Stream.ReadShort());

                case TypeCode.UInt16:
                    return (T) Enum.ToObject(typeof(T), Stream.ReadUnsignedShort());

                case TypeCode.Int32:
                    return (T) Enum.ToObject(typeof(T),  Stream.ReadInteger());

                case TypeCode.UInt32:
                    return (T) Enum.ToObject(typeof(T),  Stream.ReadUnsignedInteger());

                case TypeCode.Int64:
                    return (T) Enum.ToObject(typeof(T),  Stream.ReadLong());

                case TypeCode.UInt64:
                    return (T) Enum.ToObject(typeof(T),  Stream.ReadUnsignedLong());

                default:
                    throw new InvalidOperationException("This underlying type of enum is not supported");
            }
        }

        /// <summary>
        /// Reads an array from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="EntryDecoder">The entry decoder.</param>
        public static T[] ReadArray<T>(this Stream Stream, Func<Stream, T> EntryDecoder)
        {
            var NumberOfEntries = Stream.ReadInteger();

            if (NumberOfEntries == -1)
            {
                return null;
            }

            if (NumberOfEntries == 0)
            {
                return new T[0];
            }

            var Entries = new T[NumberOfEntries];

            for (var EntryId = 0; EntryId < NumberOfEntries; EntryId++)
            {
                Entries[EntryId] = EntryDecoder(Stream);
            }

            return Entries;
        }

        /// <summary>
        /// Reads an array from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        public static byte[] ReadBuffer(this Stream Stream)
        {
            var NumberOfBytes = Stream.ReadInteger();

            if (NumberOfBytes == -1)
            {
                return null;
            }

            var Buffer = new byte[NumberOfBytes];

            if (NumberOfBytes != 0)
                Stream.Read(Buffer);

            return Buffer;
        }

        /// <summary>
        /// Writes a compressed array to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        public static byte[] ReadCompressedBuffer(this Stream Stream)
        {
            var CompressedBuffer = Stream.ReadBuffer();

            if (CompressedBuffer == null)
            {
                return null;
            }

            if (CompressedBuffer.Length == 0)
            {
                return new byte[0];
            }

            return ZlibStream.UncompressBuffer(CompressedBuffer);
        }

        /// <summary>
        /// Reads a string value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Encoding">The string encoding.</param>
        public static string ReadString(this Stream Stream, Encoding Encoding = null)
        {
            if (Encoding == null || Encoding.Equals(Encoding.Unicode))
            {
                Encoding = Encoding.BigEndianUnicode;
            }

            var Buffer = Stream.ReadBuffer();

            if (Buffer == null)
            {
                return null;
            }

            if (Buffer.Length == 0)
            {
                return string.Empty;
            }

            return Encoding.GetString(Buffer);
        }

        /// <summary>
        /// Reads a compressed string value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Encoding">The string encoding.</param>
        public static string ReadCompressedString(this Stream Stream, Encoding Encoding = null)
        {
            if (Encoding == null || Encoding.Equals(Encoding.Unicode))
            {
                Encoding = Encoding.BigEndianUnicode;
            }

            var Buffer = Stream.ReadCompressedBuffer();

            if (Buffer == null)
            {
                return null;
            }

            if (Buffer.Length == 0)
            {
                return string.Empty;
            }

            return Encoding.GetString(Buffer);
        }

        /// <summary>
        /// Reads a <see cref="DateTime"/> value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <returns>A datetime that is expected to be UTC.</returns>
        public static DateTime ReadDateTime(this Stream Stream)
        {
            var Ticks = Stream.ReadLong();
            var Value = new DateTime(Ticks, DateTimeKind.Utc);
            return Value;
        }

        /// <summary>
        /// Reads a <see cref="DateTimeOffset"/> value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <returns>A datetime that is expected to be UTC.</returns>
        public static DateTimeOffset ReadDateTimeOffset(this Stream Stream)
        {
            var Ticks = Stream.ReadLong();
            var Offset = Stream.ReadTimeSpan();
            var Value = new DateTimeOffset(Ticks, Offset);
            return Value;
        }

        /// <summary>
        /// Reads a <see cref="TimeSpan"/> value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        public static TimeSpan ReadTimeSpan(this Stream Stream)
        {
            var Ticks = Stream.ReadLong();
            return new TimeSpan(Ticks);
        }

        /// <summary>
        /// Reads a <see cref="Guid"/> value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        public static Guid ReadGuid(this Stream Stream)
        {
            return new Guid(Stream.ReadBuffer());
        }

        /// <summary>
        /// Reads a compressed integer value from the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        public static int ReadCompressedInteger(this Stream Stream)
        {
            var Byte = Stream.ReadByte();
            int Result;

            if ((Byte & 0x40) != 0)
            {
                Result = Byte & 0x3F;

                if ((Byte & 0x80) != 0)
                {
                    Result |= ((Byte = Stream.ReadByte()) & 0x7F) << 6;

                    if ((Byte & 0x80) != 0)
                    {
                        Result |= ((Byte = Stream.ReadByte()) & 0x7F) << 13;

                        if ((Byte & 0x80) != 0)
                        {
                            Result |= ((Byte = Stream.ReadByte()) & 0x7F) << 20;

                            if ((Byte & 0x80) != 0)
                            {
                                Result |= ((Byte = Stream.ReadByte()) & 0x7F) << 27;
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
                    Result |= ((Byte = Stream.ReadByte()) & 0x7F) << 6;

                    if ((Byte & 0x80) != 0)
                    {
                        Result |= ((Byte = Stream.ReadByte()) & 0x7F) << 13;

                        if ((Byte & 0x80) != 0)
                        {
                            Result |= ((Byte = Stream.ReadByte()) & 0x7F) << 20;

                            if ((Byte & 0x80) != 0)
                            {
                                Result |= ((Byte = Stream.ReadByte()) & 0x7F) << 27;
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
        public static uint ReadCompressedUnsignedInteger(this Stream Stream)
        {
            var Byte = Stream.ReadByte();
            int Result;

            if ((Byte & 0x40) != 0)
            {
                Result = Byte & 0x3F;

                if ((Byte & 0x80) != 0)
                {
                    Result |= ((Byte = Stream.ReadByte()) & 0x7F) << 6;

                    if ((Byte & 0x80) != 0)
                    {
                        Result |= ((Byte = Stream.ReadByte()) & 0x7F) << 13;

                        if ((Byte & 0x80) != 0)
                        {
                            Result |= ((Byte = Stream.ReadByte()) & 0x7F) << 20;

                            if ((Byte & 0x80) != 0)
                            {
                                Result |= ((Byte = Stream.ReadByte()) & 0x7F) << 27;
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
                    Result |= ((Byte = Stream.ReadByte()) & 0x7F) << 6;

                    if ((Byte & 0x80) != 0)
                    {
                        Result |= ((Byte = Stream.ReadByte()) & 0x7F) << 13;

                        if ((Byte & 0x80) != 0)
                        {
                            Result |= ((Byte = Stream.ReadByte()) & 0x7F) << 20;

                            if ((Byte & 0x80) != 0)
                            {
                                Result |= ((Byte = Stream.ReadByte()) & 0x7F) << 27;
                            }
                        }
                    }
                }
            }

            return (uint) Result;
        }
    }
}
