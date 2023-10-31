using System;
namespace Helpers
{
    public static class EnumCycle
    {
        public static TEnum CycleToNextOption<TEnum>(TEnum currentOption) where TEnum : Enum
        {
            var enumValues = Enum.GetValues(typeof(TEnum));
            var currentIndex = Array.IndexOf(enumValues, currentOption);
            var nextIndex = (currentIndex + 1) % enumValues.Length;
            return (TEnum)enumValues.GetValue(nextIndex);
        }
    
        public static TEnum CycleToPrevOption<TEnum>(TEnum currentOption) where TEnum : Enum
        {
            var enumValues = Enum.GetValues(typeof(TEnum));
            var currentIndex = Array.IndexOf(enumValues, currentOption);
            var nextIndex = currentIndex > 0 ? (currentIndex - 1) : enumValues.Length - 1;
            return (TEnum)enumValues.GetValue(nextIndex);
        }
        
    }
}