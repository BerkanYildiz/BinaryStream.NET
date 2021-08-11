namespace BinaryStream.NET.Extensions
{
    using System;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    using Ionic.Zlib;

    public static partial class StreamWriter
    {
        /// <summary>
        /// Writes a byte value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async ValueTask WriteByteAsync(this Stream Stream, byte Value)
        {
            await Stream.WriteAsync(new byte[sizeof(byte)] { Value }, 0, sizeof(byte));
        }
        /// <summary>
        /// Writes a signed byte value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async ValueTask WriteSignedByteAsync(this Stream Stream, sbyte Value)
        {
            await Stream.WriteAsync(new byte[sizeof(sbyte)] { (byte) Value }, 0, sizeof(sbyte));
        }

        /// <summary>
        /// Writes a boolean value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async ValueTask WriteBoolAsync(this Stream Stream, bool Value)
        {
            var Buffer = BitConverter.GetBytes(Value);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            await Stream.WriteAsync(Buffer, 0, Buffer.Length);
        }

        /// <summary>
        /// Writes a char value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async ValueTask WriteCharAsync(this Stream Stream, char Value)
        {
            var Buffer = BitConverter.GetBytes(Value);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            await Stream.WriteAsync(Buffer, 0, Buffer.Length);
        }

        /// <summary>
        /// Writes a short value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async ValueTask WriteShortAsync(this Stream Stream, short Value)
        {
            var Buffer = BitConverter.GetBytes(Value);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            await Stream.WriteAsync(Buffer, 0, Buffer.Length);
        }

        /// <summary>
        /// Writes an unsigned short value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async ValueTask WriteUnsignedShortAsync(this Stream Stream, ushort Value)
        {
            var Buffer = BitConverter.GetBytes(Value);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            await Stream.WriteAsync(Buffer, 0, Buffer.Length);
        }

        /// <summary>
        /// Writes an integer value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async ValueTask WriteIntegerAsync(this Stream Stream, int Value)
        {
            var Buffer = BitConverter.GetBytes(Value);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            await Stream.WriteAsync(Buffer, 0, Buffer.Length);
        }

        /// <summary>
        /// Writes an unsigned integer value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async ValueTask WriteUnsignedIntegerAsync(this Stream Stream, uint Value)
        {
            var Buffer = BitConverter.GetBytes(Value);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            await Stream.WriteAsync(Buffer, 0, Buffer.Length);
        }

        /// <summary>
        /// Writes a long value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async ValueTask WriteLongAsync(this Stream Stream, long Value)
        {
            var Buffer = BitConverter.GetBytes(Value);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            await Stream.WriteAsync(Buffer, 0, Buffer.Length);
        }

        /// <summary>
        /// Writes an unsigned long value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async ValueTask WriteUnsignedLongAsync(this Stream Stream, ulong Value)
        {
            var Buffer = BitConverter.GetBytes(Value);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            await Stream.WriteAsync(Buffer, 0, Buffer.Length);
        }

        /// <summary>
        /// Writes a double value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async ValueTask WriteDoubleAsync(this Stream Stream, double Value)
        {
            var Buffer = BitConverter.GetBytes(Value);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            await Stream.WriteAsync(Buffer, 0, Buffer.Length);
        }

        /// <summary>
        /// Writes a single value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async ValueTask WriteSingleAsync(this Stream Stream, float Value)
        {
            var Buffer = BitConverter.GetBytes(Value);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            await Stream.WriteAsync(Buffer, 0, Buffer.Length);
        }

        /// <summary>
        /// Writes an enum value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async ValueTask WriteEnumAsync<T>(this Stream Stream, T Value) where T : Enum
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
                    await Stream.WriteShortAsync((short) Convert.ChangeType(Value, Value.GetTypeCode()));
                    break;

                case TypeCode.UInt16:
                    await Stream.WriteUnsignedShortAsync((ushort) Convert.ChangeType(Value, Value.GetTypeCode()));
                    break;

                case TypeCode.Int32:
                    await Stream.WriteIntegerAsync((int) Convert.ChangeType(Value, Value.GetTypeCode()));
                    break;

                case TypeCode.UInt32:
                    await Stream.WriteUnsignedIntegerAsync((uint) Convert.ChangeType(Value, Value.GetTypeCode()));
                    break;

                case TypeCode.Int64:
                    await Stream.WriteLongAsync((long) Convert.ChangeType(Value, Value.GetTypeCode()));
                    break;

                case TypeCode.UInt64:
                    await Stream.WriteUnsignedLongAsync((ulong) Convert.ChangeType(Value, Value.GetTypeCode()));
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
        public static async ValueTask WriteArrayAsync<T>(this Stream Stream, T[] Value, Func<Stream, T, Task> EntryEncoder)
        {
            if (Value == null)
            {
                await Stream.WriteIntegerAsync(-1);
                return;
            }

            await Stream.WriteIntegerAsync(Value.Length);

            for (var EntryId = 0; EntryId < Value.Length; EntryId++)
            {
                await EntryEncoder(Stream, Value[EntryId]);
            }
        }

        /// <summary>
        /// Writes an array to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async ValueTask WriteBufferAsync(this Stream Stream, byte[] Value)
        {
            if (Value == null)
            {
                await Stream.WriteIntegerAsync(-1);
                return;
            }

            await Stream.WriteIntegerAsync(Value.Length);

            if (Value.Length != 0)
                await Stream.WriteAsync(Value, 0, Value.Length);
        }

        /// <summary>
        /// Writes a compressed array to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async ValueTask WriteCompressedBufferAsync(this Stream Stream, byte[] Value)
        {
            await Stream.WriteBufferAsync(Value == null ? null : ZlibStream.CompressBuffer(Value));
        }

        /// <summary>
        /// Writes a string value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        /// <param name="Encoding">The string encoding.</param>
        public static async ValueTask WriteStringAsync(this Stream Stream, string Value, Encoding Encoding = null)
        {
            if (Encoding == null || Encoding.Equals(Encoding.Unicode))
            {
                Encoding = Encoding.BigEndianUnicode;
            }

            await Stream.WriteBufferAsync(Value == null ? null : Encoding.GetBytes(Value));
        }
        
        /// <summary>
        /// Writes a compressed string value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        /// <param name="Encoding">The string encoding.</param>
        public static async ValueTask WriteCompressedStringAsync(this Stream Stream, string Value, Encoding Encoding = null)
        {
            if (Encoding == null || Encoding.Equals(Encoding.Unicode))
            {
                Encoding = Encoding.BigEndianUnicode;
            }

            await Stream.WriteCompressedBufferAsync(Value == null ? null : Encoding.GetBytes(Value));
        }

        /// <summary>
        /// Writes a <see cref="DateTime"/> value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async ValueTask WriteDateTimeAsync(this Stream Stream, DateTime Value)
        {
            if (Value.Kind != DateTimeKind.Utc)
            {
                Value = Value.ToUniversalTime();
            }

            await Stream.WriteLongAsync(Value.Ticks);
        }

        /// <summary>
        /// Writes a <see cref="DateTimeOffset"/> value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async ValueTask WriteDateTimeOffsetAsync(this Stream Stream, DateTimeOffset Value)
        {
            await Stream.WriteLongAsync(Value.Ticks);
            await Stream.WriteTimeSpanAsync(Value.Offset);
        }

        /// <summary>
        /// Writes a <see cref="TimeSpan"/> value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async ValueTask WriteTimeSpanAsync(this Stream Stream, TimeSpan Value)
        {
            await Stream.WriteLongAsync(Value.Ticks);
        }

        /// <summary>
        /// Writes a <see cref="Guid"/> value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async ValueTask WriteGuidAsync(this Stream Stream, Guid Value)
        {
            await Stream.WriteBufferAsync(Value.ToByteArray());
        }

        /// <summary>
        /// Writes a compressed integer to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async ValueTask WriteCompressedIntegerAsync(this Stream Stream, int Value)
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
                                await Stream.WriteAsync(new byte[]
                                {
                                    (byte) (Value & 0x3F | 0x80),
                                    (byte) ((Value >> 6) & 0x7F | 0x80),
                                    (byte) ((Value >> 13) & 0x7F | 0x80),
                                    (byte) ((Value >> 20) & 0x7F | 0x80),
                                    (byte) ((Value >> 27) & 0xF)
                                }, 0, 5);

                                return;
                            }

                            await Stream.WriteAsync(new byte[]
                            {
                                (byte) (Value & 0x3F | 0x80),
                                (byte) ((Value >> 6) & 0x7F | 0x80),
                                (byte) ((Value >> 13) & 0x7F | 0x80),
                                (byte) ((Value >> 20) & 0x7F)
                            }, 0, 4);

                            return;
                        }

                        await Stream.WriteAsync(new byte[]
                        {
                            (byte) (Value & 0x3F | 0x80),
                            (byte) ((Value >> 6) & 0x7F | 0x80),
                            (byte) ((Value >> 13) & 0x7F)
                        }, 0, 3);

                        return;
                    }

                    await Stream.WriteAsync(new byte[]
                    {
                        (byte) (Value & 0x3F | 0x80),
                        (byte) ((Value >> 6) & 0x7F)
                    }, 0, 2);

                    return;
                }

                await Stream.WriteAsync(new byte[]
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
                                await Stream.WriteAsync(new byte[]
                                {
                                    (byte) (Value & 0x3F | 0xC0),
                                    (byte) ((Value >> 6) & 0x7F | 0x80),
                                    (byte) ((Value >> 13) & 0x7F | 0x80),
                                    (byte) ((Value >> 20) & 0x7F | 0x80),
                                    (byte) ((Value >> 27) & 0xF)
                                }, 0, 5);

                                return;
                            }

                            await Stream.WriteAsync(new byte[]
                            {
                                (byte) (Value & 0x3F | 0xC0),
                                (byte) ((Value >> 6) & 0x7F | 0x80),
                                (byte) ((Value >> 13) & 0x7F | 0x80),
                                (byte) ((Value >> 20) & 0x7F)
                            }, 0, 4);

                            return;
                        }

                        await Stream.WriteAsync(new byte[]
                        {
                            (byte) (Value & 0x3F | 0xC0),
                            (byte) ((Value >> 6) & 0x7F | 0x80),
                            (byte) ((Value >> 13) & 0x7F),
                        }, 0, 3);

                        return;
                    }

                    await Stream.WriteAsync(new byte[]
                    {
                        (byte) (Value & 0x3F | 0xC0),
                        (byte) ((Value >> 6) & 0x7F),
                    }, 0, 2);

                    return;
                }

                await Stream.WriteAsync(new byte[]
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
        public static async ValueTask WriteCompressedUnsignedIntegerAsync(this Stream Stream, uint Value)
        {
            if (Value >= 0x40)
            {
                if (Value >= 0x2000)
                {
                    if (Value >= 0x100000)
                    {
                        if (Value >= 0x8000000)
                        {
                            await Stream.WriteAsync(new byte[]
                            {
                                (byte) (Value & 0x3F | 0x80),
                                (byte) ((Value >> 6) & 0x7F | 0x80),
                                (byte) ((Value >> 13) & 0x7F | 0x80),
                                (byte) ((Value >> 20) & 0x7F | 0x80),
                                (byte) ((Value >> 27) & 0xF)
                            }, 0, 5);

                            return;
                        }

                        await Stream.WriteAsync(new byte[]
                        {
                            (byte) (Value & 0x3F | 0x80),
                            (byte) ((Value >> 6) & 0x7F | 0x80),
                            (byte) ((Value >> 13) & 0x7F | 0x80),
                            (byte) ((Value >> 20) & 0x7F)
                        }, 0, 4);

                        return;
                    }

                    await Stream.WriteAsync(new byte[]
                    {
                        (byte) (Value & 0x3F | 0x80),
                        (byte) ((Value >> 6) & 0x7F | 0x80),
                        (byte) ((Value >> 13) & 0x7F)
                    }, 0, 3);

                    return;
                }

                await Stream.WriteAsync(new byte[]
                {
                    (byte) (Value & 0x3F | 0x80),
                    (byte) ((Value >> 6) & 0x7F)
                }, 0, 2);

                return;
            }

            await Stream.WriteAsync(new byte[]
            {
                (byte) (Value & 0x3F),
            }, 0, 1);
        }
    }
}
