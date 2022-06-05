namespace BinaryStream.NET.Extensions
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Mail;
    using System.Text;

    using Ionic.Zlib;

    public static partial class StreamWriter
    {
        /// <summary>
        /// Writes a byte value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static void WriteByte(this Stream Stream, byte Value)
        {
            Stream.Write(new byte[sizeof(byte)] { Value }, 0, sizeof(byte));
        }

        /// <summary>
        /// Writes a signed byte value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static void WriteSignedByte(this Stream Stream, sbyte Value)
        {
            Stream.Write(new byte[sizeof(sbyte)] { (byte) Value }, 0, sizeof(sbyte));
        }

        /// <summary>
        /// Writes a boolean value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static void WriteBool(this Stream Stream, bool Value)
        {
            var Buffer = BitConverter.GetBytes(Value);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            Stream.Write(Buffer, 0, Buffer.Length);
        }

        /// <summary>
        /// Writes a char value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static void WriteChar(this Stream Stream, char Value)
        {
            var Buffer = BitConverter.GetBytes(Value);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            Stream.Write(Buffer, 0, Buffer.Length);
        }

        /// <summary>
        /// Writes a short value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static void WriteShort(this Stream Stream, short Value)
        {
            var Buffer = BitConverter.GetBytes(Value);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            Stream.Write(Buffer, 0, Buffer.Length);
        }

        /// <summary>
        /// Writes an unsigned short value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static void WriteUnsignedShort(this Stream Stream, ushort Value)
        {
            var Buffer = BitConverter.GetBytes(Value);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            Stream.Write(Buffer, 0, Buffer.Length);
        }

        /// <summary>
        /// Writes an integer value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static void WriteInteger(this Stream Stream, int Value)
        {
            var Buffer = BitConverter.GetBytes(Value);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            Stream.Write(Buffer, 0, Buffer.Length);
        }

        /// <summary>
        /// Writes an unsigned integer value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static void WriteUnsignedInteger(this Stream Stream, uint Value)
        {
            var Buffer = BitConverter.GetBytes(Value);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            Stream.Write(Buffer, 0, Buffer.Length);
        }

        /// <summary>
        /// Writes a long value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static void WriteLong(this Stream Stream, long Value)
        {
            var Buffer = BitConverter.GetBytes(Value);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            Stream.Write(Buffer, 0, Buffer.Length);
        }

        /// <summary>
        /// Writes an unsigned long value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static void WriteUnsignedLong(this Stream Stream, ulong Value)
        {
            var Buffer = BitConverter.GetBytes(Value);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            Stream.Write(Buffer, 0, Buffer.Length);
        }

        /// <summary>
        /// Writes a double value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static void WriteDouble(this Stream Stream, double Value)
        {
            var Buffer = BitConverter.GetBytes(Value);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            Stream.Write(Buffer, 0, Buffer.Length);
        }

        /// <summary>
        /// Writes a single value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static void WriteSingle(this Stream Stream, float Value)
        {
            var Buffer = BitConverter.GetBytes(Value);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            Stream.Write(Buffer, 0, Buffer.Length);
        }

        /// <summary>
        /// Writes an enum value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static void WriteEnum<T>(this Stream Stream, T Value) where T : Enum
        {
            switch (Type.GetTypeCode(typeof(T)))
            {
                case TypeCode.Byte:
                    Stream.WriteByte((byte) Convert.ChangeType(Value, Value.GetTypeCode()));
                    break;

                case TypeCode.SByte:
                    Stream.WriteByte((byte) Convert.ChangeType(Value, Value.GetTypeCode()));
                    break;

                case TypeCode.Int16:
                    Stream.WriteShort((short) Convert.ChangeType(Value, Value.GetTypeCode()));
                    break;

                case TypeCode.UInt16:
                    Stream.WriteUnsignedShort((ushort) Convert.ChangeType(Value, Value.GetTypeCode()));
                    break;

                case TypeCode.Int32:
                    Stream.WriteInteger((int) Convert.ChangeType(Value, Value.GetTypeCode()));
                    break;

                case TypeCode.UInt32:
                    Stream.WriteUnsignedInteger((uint) Convert.ChangeType(Value, Value.GetTypeCode()));
                    break;

                case TypeCode.Int64:
                    Stream.WriteLong((long) Convert.ChangeType(Value, Value.GetTypeCode()));
                    break;

                case TypeCode.UInt64:
                    Stream.WriteUnsignedLong((ulong) Convert.ChangeType(Value, Value.GetTypeCode()));
                    break;

                default:
                    throw new InvalidOperationException("This underlying type of enum is not supported");
            }
        }

        /// <summary>
        /// Writes an array to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        /// <param name="EntryEncoder">The entry encoder.</param>
        public static void WriteArray<T>(this Stream Stream, T[] Value, Action<Stream, T> EntryEncoder)
        {
            if (Value == null)
            {
                Stream.WriteLong(-1);
                return;
            }

            Stream.WriteLong(Value.LongLength);

            foreach (var Entry in Value)
                EntryEncoder(Stream, Entry);
        }

        /// <summary>
        /// Writes an enumerable to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        /// <param name="EntryEncoder">The entry encoder.</param>
        public static void WriteEnumerable<T>(this Stream Stream, IEnumerable<T> Value, Action<Stream, T> EntryEncoder)
        {
            if (Value == null)
            {
                Stream.WriteInteger(-1);
                return;
            }

            Stream.WriteInteger(Value.Count());

            foreach (var Entry in Value)
                EntryEncoder(Stream, Entry);
        }

        /// <summary>
        /// Writes a collection to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        /// <param name="EntryEncoder">The entry encoder.</param>
        public static void WriteCollection<T>(this Stream Stream, ICollection<T> Value, Action<Stream, T> EntryEncoder)
        {
            if (Value == null)
            {
                Stream.WriteInteger(-1);
                return;
            }
            
            Stream.WriteInteger(Value.Count);

            foreach (var Entry in Value)
                EntryEncoder(Stream, Entry);
        }

        /// <summary>
        /// Writes an array to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static void WriteBuffer(this Stream Stream, byte[] Value)
        {
            if (Value == null)
            {
                Stream.WriteInteger(-1);
                return;
            }

            Stream.WriteInteger(Value.Length);
            
            if (Value.Length != 0)
                Stream.Write(Value, 0, Value.Length);
        }

        /// <summary>
        /// Writes a compressed array to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static void WriteCompressedBuffer(this Stream Stream, byte[] Value)
        {
            Stream.WriteBuffer(Value == null ? null : ZlibStream.CompressBuffer(Value));
        }

        /// <summary>
        /// Writes a string value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        /// <param name="Encoding">The string encoding.</param>
        public static void WriteString(this Stream Stream, string Value, Encoding Encoding = null)
        {
            if (Encoding == null || Encoding.Equals(Encoding.Unicode))
            {
                Encoding = Encoding.BigEndianUnicode;
            }

            Stream.WriteBuffer(Value == null ? null : Encoding.GetBytes(Value));
        }

        /// <summary>
        /// Writes a compressed string value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        /// <param name="Encoding">The string encoding.</param>
        public static void WriteCompressedString(this Stream Stream, string Value, Encoding Encoding = null)
        {
            if (Encoding == null || Encoding.Equals(Encoding.Unicode))
                Encoding = Encoding.BigEndianUnicode;

            Stream.WriteCompressedBuffer(Value == null ? null : Encoding.GetBytes(Value));
        }

        /// <summary>
        /// Writes a <see cref="DateTime"/> value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static void WriteDateTime(this Stream Stream, DateTime Value)
        {
            if (Value.Kind != DateTimeKind.Utc)
                Value = Value.ToUniversalTime();

            Stream.WriteLong(Value.Ticks);
        }
        
        /// <summary>
        /// Writes a <see cref="DateTimeOffset"/> value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static void WriteDateTimeOffset(this Stream Stream, DateTimeOffset Value)
        {
            Stream.WriteLong(Value.Ticks);
            Stream.WriteTimeSpan(Value.Offset);
        }

        /// <summary>
        /// Writes a <see cref="TimeSpan"/> value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static void WriteTimeSpan(this Stream Stream, TimeSpan Value)
        {
            Stream.WriteLong(Value.Ticks);
        }

        /// <summary>
        /// Writes a <see cref="Guid"/> value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static void WriteGuid(this Stream Stream, Guid Value)
        {
            Stream.WriteBuffer(Value.ToByteArray());
        }

        /// <summary>
        /// Writes a compressed integer to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static void WriteCompressedInteger(this Stream Stream, int Value)
        {
            if (Value >= 0)
            {
                if (Value >= 0x40)
                {
                    if (Value >= 0x2000)
                    {
                        if (Value >= 0x100000)
                        {
                            if (Value >= 0x8000000)
                            {
                                Stream.Write(new byte[]
                                {
                                    (byte) (Value & 0x3F | 0x80),
                                    (byte) ((Value >> 6) & 0x7F | 0x80),
                                    (byte) ((Value >> 13) & 0x7F | 0x80),
                                    (byte) ((Value >> 20) & 0x7F | 0x80),
                                    (byte) ((Value >> 27) & 0xF)
                                }, 0, 5);

                                return;
                            }

                            Stream.Write(new byte[]
                            {
                                (byte) (Value & 0x3F | 0x80),
                                (byte) ((Value >> 6) & 0x7F | 0x80),
                                (byte) ((Value >> 13) & 0x7F | 0x80),
                                (byte) ((Value >> 20) & 0x7F)
                            }, 0, 4);

                            return;
                        }

                        Stream.Write(new byte[]
                        {
                            (byte) (Value & 0x3F | 0x80),
                            (byte) ((Value >> 6) & 0x7F | 0x80),
                            (byte) ((Value >> 13) & 0x7F)
                        }, 0, 3);

                        return;
                    }

                    Stream.Write(new byte[]
                    {
                        (byte) (Value & 0x3F | 0x80),
                        (byte) ((Value >> 6) & 0x7F)
                    }, 0, 2);

                    return;
                }

                Stream.Write(new byte[]
                {
                    (byte) (Value & 0x3F),
                }, 0, 1);
            }
            else
            {
                if (Value <= -0x40)
                {
                    if (Value <= -0x2000)
                    {
                        if (Value <= -0x100000)
                        {
                            if (Value <= -0x8000000)
                            {
                                Stream.Write(new byte[]
                                {
                                    (byte) (Value & 0x3F | 0xC0),
                                    (byte) ((Value >> 6) & 0x7F | 0x80),
                                    (byte) ((Value >> 13) & 0x7F | 0x80),
                                    (byte) ((Value >> 20) & 0x7F | 0x80),
                                    (byte) ((Value >> 27) & 0xF)
                                }, 0, 5);

                                return;
                            }

                            Stream.Write(new byte[]
                            {
                                (byte) (Value & 0x3F | 0xC0),
                                (byte) ((Value >> 6) & 0x7F | 0x80),
                                (byte) ((Value >> 13) & 0x7F | 0x80),
                                (byte) ((Value >> 20) & 0x7F)
                            }, 0, 4);

                            return;
                        }

                        Stream.Write(new byte[]
                        {
                            (byte) (Value & 0x3F | 0xC0),
                            (byte) ((Value >> 6) & 0x7F | 0x80),
                            (byte) ((Value >> 13) & 0x7F),
                        }, 0, 3);

                        return;
                    }

                    Stream.Write(new byte[]
                    {
                        (byte) (Value & 0x3F | 0xC0),
                        (byte) ((Value >> 6) & 0x7F),
                    }, 0, 2);

                    return;
                }

                Stream.Write(new byte[]
                {
                    (byte) (Value & 0x3F | 0x40),
                }, 0, 1);
            }
        }

        /// <summary>
        /// Writes a compressed unsigned integer to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static void WriteCompressedUnsignedInteger(this Stream Stream, uint Value)
        {
            if (Value >= 0x40)
            {
                if (Value >= 0x2000)
                {
                    if (Value >= 0x100000)
                    {
                        if (Value >= 0x8000000)
                        {
                            Stream.Write(new byte[]
                            {
                                (byte) (Value & 0x3F | 0x80),
                                (byte) ((Value >> 6) & 0x7F | 0x80),
                                (byte) ((Value >> 13) & 0x7F | 0x80),
                                (byte) ((Value >> 20) & 0x7F | 0x80),
                                (byte) ((Value >> 27) & 0xF)
                            }, 0, 5);

                            return;
                        }

                        Stream.Write(new byte[]
                        {
                            (byte) (Value & 0x3F | 0x80),
                            (byte) ((Value >> 6) & 0x7F | 0x80),
                            (byte) ((Value >> 13) & 0x7F | 0x80),
                            (byte) ((Value >> 20) & 0x7F)
                        }, 0, 4);

                        return;
                    }

                    Stream.Write(new byte[]
                    {
                        (byte) (Value & 0x3F | 0x80),
                        (byte) ((Value >> 6) & 0x7F | 0x80),
                        (byte) ((Value >> 13) & 0x7F)
                    }, 0, 3);

                    return;
                }

                Stream.Write(new byte[]
                {
                    (byte) (Value & 0x3F | 0x80),
                    (byte) ((Value >> 6) & 0x7F)
                }, 0, 2);

                return;
            }

            Stream.Write(new byte[]
            {
                (byte) (Value & 0x3F),
            }, 0, 1);
        }
    }
}
