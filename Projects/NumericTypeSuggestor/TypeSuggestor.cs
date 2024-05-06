using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NumericTypeSuggestor
{
    internal class TypeSuggestor
    {
        public const string BigInteger = "BigInteger";
        public const string ULong = "ulong";
        public const string UInt = "uint";
        public const string UShort = "ushort";
        public const string Byte = "byte";
        public const string Int = "int";
        public const string Long = "long";
        public const string Float = "float";
        public const string Double = "double";
        public const string Short = "short";
        public const string SByte = "sbyte";
        public const string Decimal = "decimal";
        public const string ImpossibleRep =
            "Impossible representation";

        public static string GetName(
            BigInteger minValue,
            BigInteger maxValue,
            bool integralOnly,
            bool mustBePrecise
            )
        {
            return  integralOnly ?
                GetIntegralNumberName(minValue, maxValue ) :
                GetFloatingPointNumberName(
                    minValue, maxValue, mustBePrecise);
        }

        private static string GetFloatingPointNumberName(BigInteger minValue, BigInteger maxValue, bool mustBePrecise)
        {
            return mustBePrecise ?
                GetPreciseFloatingPointNumberName(minValue, maxValue) :
                GetFloatingPointNumberName(minValue, maxValue);
        }

        private static string GetFloatingPointNumberName(BigInteger minValue, BigInteger maxValue)
        {
            if (minValue >= new BigInteger(float.MinValue) &&
                maxValue <= new BigInteger(float.MaxValue))
            {
                return Float;
            }
            if (minValue >= new BigInteger(double.MinValue) &&
                maxValue <= new BigInteger(double.MaxValue))
            {
                return Double;
            }
            return ImpossibleRep;
        }

        private static string GetPreciseFloatingPointNumberName(BigInteger minValue, BigInteger maxValue)
        {
            if(minValue >= new BigInteger(decimal.MinValue) && 
                maxValue <= new BigInteger(decimal.MaxValue))
            {
                return Decimal;
            }

            return ImpossibleRep;
        }

        private static string GetIntegralNumberName(BigInteger minValue, BigInteger maxValue)
        {
            return minValue >= 0 ?
                GetUnsignedIntegeralNumberName(maxValue) :
                GetSignedIntegralNumberName(minValue, maxValue);
        }

        private static string GetSignedIntegralNumberName(BigInteger minValue, BigInteger maxValue)
        {
            if(minValue >= sbyte.MinValue && 
                maxValue <= sbyte.MaxValue)
            {
                return SByte;
            }

            if (minValue >= short.MinValue &&
                maxValue <= short.MaxValue)
            {
                return Short;
            }
            if (minValue >= int.MinValue &&
                maxValue <= int.MaxValue)
            {
                return Int;
            }
            if (minValue >= long.MinValue &&
                maxValue <= long.MaxValue)
            {
                return Long;
            }

            return BigInteger;
        }

        private static string GetUnsignedIntegeralNumberName(BigInteger maxValue)
        {
            if(maxValue <= byte.MaxValue)
            {
                return Byte;
            }
            if (maxValue <= ushort.MaxValue)
            {
                return UShort;
            }
            if (maxValue <= uint.MaxValue)
            {
                return UInt;
            }
            if (maxValue <= ulong.MaxValue)
            {
                return ULong;
            }
            return BigInteger;
        }
    }
}
