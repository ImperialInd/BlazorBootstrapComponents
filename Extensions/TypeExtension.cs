using System;
using System.Linq;

namespace BlazorBootstrapComponents.Extensions;

public static class TypeExtension
{
    public static bool IsNumber(this Type type)
    {
        switch (Type.GetTypeCode(type))
        {
            case TypeCode.Byte:
            case TypeCode.SByte:
            case TypeCode.UInt16:
            case TypeCode.UInt32:
            case TypeCode.UInt64:
            case TypeCode.Int16:
            case TypeCode.Int32:
            case TypeCode.Int64:
            case TypeCode.Decimal:
            case TypeCode.Double:
            case TypeCode.Single:
                return true;
            default:
                return false;
        }
    }

	public static T ChangeTypeLinqVariant<T>(this object value)
	{
		return (new[] { value }).Cast<T>().Single();
	}

}
