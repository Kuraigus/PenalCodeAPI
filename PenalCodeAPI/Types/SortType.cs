namespace PenalCodeAPI.Type
{
        enum SortType
        {
            Name,
            CreateDate,
            UpdateDate,
            CreateUserId,
            UpdateUserId,
            StatusId,
            Penalty,
            PrisonTime,
            none
        }

        static class SortOptionsExtensions
        {
            public static SortType FromString(this SortType sortType, string sortOption)
            {
                var sortOptionsValues = Enum.GetValues(typeof(SortType));

                foreach (SortType option in sortOptionsValues)
                {
                    if (option.ToString() == sortOption)
                        return option;
                }

                return SortType.none;
            }
        }
}
