using System.Globalization;

namespace ProductsManagement.BLL.Helpers;

public class FloatHelpers
{
    public static float ConvertToFloat(string amount)
    {
        if (float.TryParse(amount, NumberStyles.Float, CultureInfo.InvariantCulture, out float result))
        {
            return result;
        }

        return 0.0f;
    }

    public static float? ConvertToFloatNullable(string amount)
    {
        if (float.TryParse(amount, NumberStyles.Float, CultureInfo.InvariantCulture, out float result))
        {
            return result;
        }

        return null;
    }
}