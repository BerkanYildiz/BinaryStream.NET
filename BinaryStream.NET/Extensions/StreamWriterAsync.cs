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
        public static async Task WriteByteAsync(this Stream Stream, byte Value)
        {
            await Stream.WriteAsync(new byte[1] { Value });
        }
        /// <summary>
        /// Writes a signed byte value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async Task WriteSignedByteAsync(this Stream Stream, sbyte Value)
        {
            await Stream.WriteAsync(new byte[1] { (byte) Value });
        }

        /// <summary>
        /// Writes a boolean value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async Task WriteBoolAsync(this Stream Stream, bool Value)
        {
            var Buffer = BitConverter.GetBytes(Value);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            await Stream.WriteAsync(Buffer);
        }

        /// <summary>
        /// Writes a char value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async Task WriteCharAsync(this Stream Stream, char Value)
        {
            var Buffer = BitConverter.GetBytes(Value);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            await Stream.WriteAsync(Buffer);
        }

        /// <summary>
        /// Writes a short value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async Task WriteShortAsync(this Stream Stream, short Value)
        {
            var Buffer = BitConverter.GetBytes(Value);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            await Stream.WriteAsync(Buffer);
        }

        /// <summary>
        /// Writes an unsigned short value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async Task WriteUnsignedShortAsync(this Stream Stream, ushort Value)
        {
            var Buffer = BitConverter.GetBytes(Value);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            await Stream.WriteAsync(Buffer);
        }

        /// <summary>
        /// Writes an integer value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async Task WriteIntegerAsync(this Stream Stream, int Value)
        {
            var Buffer = BitConverter.GetBytes(Value);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            await Stream.WriteAsync(Buffer);
        }

        /// <summary>
        /// Writes an unsigned integer value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async Task WriteUnsignedIntegerAsync(this Stream Stream, uint Value)
        {
            var Buffer = BitConverter.GetBytes(Value);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            await Stream.WriteAsync(Buffer);
        }

        /// <summary>
        /// Writes a long value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async Task WriteLongAsync(this Stream Stream, long Value)
        {
            var Buffer = BitConverter.GetBytes(Value);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            await Stream.WriteAsync(Buffer);
        }

        /// <summary>
        /// Writes an unsigned long value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async Task WriteUnsignedLongAsync(this Stream Stream, ulong Value)
        {
            var Buffer = BitConverter.GetBytes(Value);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            await Stream.WriteAsync(Buffer);
        }

        /// <summary>
        /// Writes a double value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async Task WriteDoubleAsync(this Stream Stream, double Value)
        {
            var Buffer = BitConverter.GetBytes(Value);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            await Stream.WriteAsync(Buffer);
        }

        /// <summary>
        /// Writes a single value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async Task WriteSingleAsync(this Stream Stream, float Value)
        {
            var Buffer = BitConverter.GetBytes(Value);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);

            await Stream.WriteAsync(Buffer);
        }

        /// <summary>
        /// Writes an enum value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async Task WriteEnumAsync<T>(this Stream Stream, T Value) where T : Enum
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
        public static async Task WriteArrayAsync<T>(this Stream Stream, T[] Value, Func<Stream, T, Task> EntryEncoder)
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
        public static async Task WriteBufferAsync(this Stream Stream, byte[] Value)
        {
            if (Value == null)
            {
                await Stream.WriteIntegerAsync(-1);
                return;
            }

            await Stream.WriteIntegerAsync(Value.Length);

            if (Value.Length != 0)
                await Stream.WriteAsync(Value);
        }

        /// <summary>
        /// Writes a compressed array to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async Task WriteCompressedBufferAsync(this Stream Stream, byte[] Value)
        {
            await Stream.WriteBufferAsync(Value == null ? null : ZlibStream.CompressBuffer(Value));
        }

        /// <summary>
        /// Writes a string value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        /// <param name="Encoding">The string encoding.</param>
        public static async Task WriteStringAsync(this Stream Stream, string Value, Encoding Encoding = null)
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
        public static async Task WriteCompressedStringAsync(this Stream Stream, string Value, Encoding Encoding = null)
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
        public static async Task WriteDateTimeAsync(this Stream Stream, DateTime Value)
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
        public static async Task WriteDateTimeOffsetAsync(this Stream Stream, DateTimeOffset Value)
        {
            await Stream.WriteLongAsync(Value.Ticks);
            await Stream.WriteTimeSpanAsync(Value.Offset);
        }

        /// <summary>
        /// Writes a <see cref="TimeSpan"/> value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async Task WriteTimeSpanAsync(this Stream Stream, TimeSpan Value)
        {
            await Stream.WriteLongAsync(Value.Ticks);
        }

        /// <summary>
        /// Writes a <see cref="Guid"/> value to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async Task WriteGuidAsync(this Stream Stream, Guid Value)
        {
            await Stream.WriteBufferAsync(Value.ToByteArray());
        }

        /// <summary>
        /// Writes a compressed integer to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async Task WriteCompressedIntegerAsync(this Stream Stream, int Value)
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
                                });

                                return;
                            }

                            await Stream.WriteAsync(new byte[]
                            {
                                (byte) (Value & 0x3F | 0x80),
                                (byte) ((Value >> 6) & 0x7F | 0x80),
                                (byte) ((Value >> 13) & 0x7F | 0x80),
                                (byte) ((Value >> 20) & 0x7F)
                            });

                            return;
                        }

                        await Stream.WriteAsync(new byte[]
                        {
                            (byte) (Value & 0x3F | 0x80),
                            (byte) ((Value >> 6) & 0x7F | 0x80),
                            (byte) ((Value >> 13) & 0x7F)
                        });

                        return;
                    }

                    await Stream.WriteAsync(new byte[]
                    {
                        (byte) (Value & 0x3F | 0x80),
                        (byte) ((Value >> 6) & 0x7F)
                    });

                    return;
                }

                await Stream.WriteAsync(new byte[]
                {
                    (byte) (Value & 0x3F),
                });
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
                                });

                                return;
                            }

                            await Stream.WriteAsync(new byte[]
                            {
                                (byte) (Value & 0x3F | 0xC0),
                                (byte) ((Value >> 6) & 0x7F | 0x80),
                                (byte) ((Value >> 13) & 0x7F | 0x80),
                                (byte) ((Value >> 20) & 0x7F)
                            });

                            return;
                        }

                        await Stream.WriteAsync(new byte[]
                        {
                            (byte) (Value & 0x3F | 0xC0),
                            (byte) ((Value >> 6) & 0x7F | 0x80),
                            (byte) ((Value >> 13) & 0x7F),
                        });

                        return;
                    }

                    await Stream.WriteAsync(new byte[]
                    {
                        (byte) (Value & 0x3F | 0xC0),
                        (byte) ((Value >> 6) & 0x7F),
                    });

                    return;
                }

                await Stream.WriteAsync(new byte[]
                {
                    (byte) (Value & 0x3F | 0x40),
                });
            }
        }

        /// <summary>
        /// Writes a compressed unsigned integer to the stream.
        /// </summary>
        /// <param name="Stream">The stream.</param>
        /// <param name="Value">The value to write.</param>
        public static async Task WriteCompressedUnsignedIntegerAsync(this Stream Stream, uint Value)
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
                            });

                            return;
                        }

                        await Stream.WriteAsync(new byte[]
                        {
                            (byte) (Value & 0x3F | 0x80),
                            (byte) ((Value >> 6) & 0x7F | 0x80),
                            (byte) ((Value >> 13) & 0x7F | 0x80),
                            (byte) ((Value >> 20) & 0x7F)
                        });

                        return;
                    }

                    await Stream.WriteAsync(new byte[]
                    {
                        (byte) (Value & 0x3F | 0x80),
                        (byte) ((Value >> 6) & 0x7F | 0x80),
                        (byte) ((Value >> 13) & 0x7F)
                    });

                    return;
                }

                await Stream.WriteAsync(new byte[]
                {
                    (byte) (Value & 0x3F | 0x80),
                    (byte) ((Value >> 6) & 0x7F)
                });

                return;
            }

            await Stream.WriteAsync(new byte[]
            {
                (byte) (Value & 0x3F),
            });
        }
    }
}
