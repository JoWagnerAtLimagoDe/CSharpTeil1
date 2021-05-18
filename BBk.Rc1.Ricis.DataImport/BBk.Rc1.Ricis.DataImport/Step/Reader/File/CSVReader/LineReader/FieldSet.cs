using System;
using System.Globalization;
using System.Numerics;

namespace BBk.Rc1.Ricis.DataImport.Step.Reader.File.CSVReader.LineReader
{
    public class FieldSet
    {
        private readonly CultureInfo _defaultCurrentCultureInfo = CultureInfo.CurrentCulture;
        private readonly CultureInfo _defaultCultureInfo = CultureInfo.InvariantCulture;
        private readonly NumberFormatInfo _defaultNumberFormatInfo = new NumberFormatInfo();
        private string[] Tokens { get; }
        public string[] Names { set; get; }

        public int ColumnCount => Tokens.Length;


        public FieldSet(string [] tokens, string[] names  = null)
        {
            Tokens = tokens;
            Names = names ?? new string[0];
            
        }
        

        public string ReadString(int position, string defaultValue = null)
        {
            if (Tokens[position] != null)
                return Tokens[position];
            return defaultValue;
        }

        public decimal ReadDecimal(int position, decimal? defaultValue = decimal.Zero, NumberStyles styles = NumberStyles.Float, CultureInfo cultureInfo = null)
        {
            cultureInfo = cultureInfo ?? _defaultCurrentCultureInfo;

            return Tokens[position] != null ? decimal.Parse(Tokens[position], styles, cultureInfo) : defaultValue ?? throw new ArgumentNullException("position " + position);
        }



        public DateTime ReadDateTime(int position, DateTime? defaultValue = null, string format = "yyyyMMdd", CultureInfo cultureInfo = null)
        {
            cultureInfo = cultureInfo ?? _defaultCultureInfo;
            return Tokens[position] != null ? DateTime.ParseExact(Tokens[position], format, cultureInfo) : defaultValue ?? throw new ArgumentNullException("position " + position);
        }

        public TimeSpan ReadTime(int position, TimeSpan? defaultValue = null, string format = "HH:mm:ss", CultureInfo cultureInfo = null)
        {
            cultureInfo = cultureInfo ?? _defaultCultureInfo;

            if (Tokens[position] == null)
                return defaultValue ?? throw new ArgumentNullException("position " + position);
            
            DateTime dateTime = DateTime.ParseExact(Tokens[position], format, cultureInfo);
  
            return dateTime - dateTime.Date ;
        }


        public BigInteger ReadBigInteger(int position, BigInteger? defaultValue = null, NumberFormatInfo numberFormat = null)
        {
            numberFormat = numberFormat ?? _defaultNumberFormatInfo;
            return Tokens[position] != null ? BigInteger.Parse(Tokens[position], numberFormat) : defaultValue ?? throw new ArgumentNullException("position " + position);
        }


        public int ReadInteger(int position, int? defaultValue = null)
        {
            var success = int.TryParse(Tokens[position], out var returnValue);

            return success ? returnValue : defaultValue ?? throw new ArgumentNullException("position " + position);
        }

        public long ReadLong(int position, long? defaultValue = null)
        {
            var success = long.TryParse(Tokens[position], out var returnValue);

            return success ? returnValue : defaultValue ?? throw new ArgumentNullException("position " + position);
        }

        public byte ReadByte(int position, byte? defaultValue = null)
        {
            var success = byte.TryParse(Tokens[position], out var returnValue);

            return success ? returnValue : defaultValue ?? throw new ArgumentNullException("position " + position);
        }

        public sbyte ReadSByte(int position, sbyte? defaultValue = null)
        {
            var success = sbyte.TryParse(Tokens[position], out var returnValue);

            return success ? returnValue : defaultValue ?? throw new ArgumentNullException("position " + position);
        }


        public bool ReadBool(int position, bool? defaultValue = null)
        {
            var success = bool.TryParse(Tokens[position], out var returnValue);

            return success ? returnValue : defaultValue ?? throw new ArgumentNullException("position " + position);
        }
        public short ReadShort(int position, short? defaultValue = null)
        {
            var success = short.TryParse(Tokens[position], out var returnValue);

            return success ? returnValue : defaultValue ?? throw new ArgumentNullException("position " + position);
        }

        public double ReadDouble(int position, double? defaultValue = null, CultureInfo cultureInfo = null)
        {
            cultureInfo = cultureInfo ?? _defaultCultureInfo;

            return Tokens[position] != null ? double.Parse(Tokens[position], cultureInfo) : defaultValue ?? throw new ArgumentNullException("position " + position);
        }

        public float ReadFloat(int position, float? defaultValue = null, CultureInfo cultureInfo = null)
        {
            cultureInfo = cultureInfo ?? _defaultCultureInfo;

            return Tokens[position] != null ? float.Parse(Tokens[position], cultureInfo) : defaultValue ?? throw new ArgumentNullException("position " + position);
        }

        public char ReadChar(int position, char? defaultValue = null)
        {
            var success = char.TryParse(Tokens[position], out var returnValue);

            return success ? returnValue : defaultValue ?? throw new ArgumentNullException("position " + position);
        }

        public ushort ReadUShort(int position, ushort? defaultValue = null)
        {
            var success = ushort.TryParse(Tokens[position], out var returnValue);

            return success ? returnValue : defaultValue ?? throw new ArgumentNullException("position " + position);
        }
        public ulong ReadULong(int position, ulong? defaultValue = null)
        {
            var success = ulong.TryParse(Tokens[position], out var returnValue);

            return success ? returnValue : defaultValue ?? throw new ArgumentNullException("position " + position);
        }

        public string ReadString(string name, string defaultValue = null)
        {
            return ReadString(Array.IndexOf(Names, name), defaultValue);
        }

        public decimal ReadDecimal(string name, decimal? defaultValue = decimal.Zero, NumberStyles styles = NumberStyles.Float, CultureInfo cultureInfo = null)
        {
            return ReadDecimal(Array.IndexOf(Names, name), defaultValue, styles, cultureInfo);
        }

        


        public DateTime ReadDateTime(string name, DateTime? defaultValue = null, string format = "yyyyMMdd", CultureInfo cultureInfo = null)
        {
            return ReadDateTime(Array.IndexOf(Names, name), defaultValue, format, cultureInfo);

        }

        public TimeSpan ReadTime(string name, TimeSpan? defaultValue = null, string format = "HH:mm:ss", CultureInfo cultureInfo = null)
        {
            return ReadTime(Array.IndexOf(Names, name),defaultValue,format,cultureInfo);
        }


        public BigInteger ReadBigInteger(string name, BigInteger? defaultValue = null, NumberFormatInfo numberFormat = null)
        {
            return ReadBigInteger(Array.IndexOf(Names, name), defaultValue, numberFormat);
        }


        public int ReadInteger(string name, int? defaultValue = null)
        {
            return ReadInteger(Array.IndexOf(Names, name), defaultValue);
        }

        public long ReadLong(string name, long? defaultValue = null)
        {
            return ReadLong(Array.IndexOf(Names, name), defaultValue);
        }

        public byte ReadByte(string name, byte? defaultValue = null)
        {
            return ReadByte(Array.IndexOf(Names, name), defaultValue);
        }

        public sbyte ReadSByte(string name, sbyte? defaultValue = null)
        {
            return ReadSByte(Array.IndexOf(Names, name), defaultValue);
        }


        public bool ReadBool(string name, bool? defaultValue = null)
        {
            return ReadBool(Array.IndexOf(Names, name), defaultValue);
        }
        public short ReadShort(string name, short? defaultValue = null)
        {
            return ReadShort(Array.IndexOf(Names, name), defaultValue);
        }

        public double ReadDouble(string name, double? defaultValue = null, CultureInfo cultureInfo = null)
        {
            return ReadDouble(Array.IndexOf(Names, name), defaultValue, cultureInfo);
        }

        public float ReadFloat(string name, float? defaultValue = null, CultureInfo cultureInfo = null)
        {
            return ReadFloat(Array.IndexOf(Names, name), defaultValue, cultureInfo);
        }

        public char ReadChar(string name, char? defaultValue = null)
        {
            return ReadChar(Array.IndexOf(Names, name), defaultValue);
        }

        public ushort ReadUShort(string name, ushort? defaultValue = null)
        {
            return ReadUShort( Array.IndexOf(Names, name), defaultValue);
        }
        public ulong ReadULong(string name, ulong? defaultValue = null)
        {
            return ReadULong(Array.IndexOf(Names, name), defaultValue);
        }

        

    }
}
