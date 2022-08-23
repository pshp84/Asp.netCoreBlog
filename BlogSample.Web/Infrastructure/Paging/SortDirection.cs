using System.Runtime.Serialization;

namespace BlogSample.Web.Infrastructure.Paging;

[DataContract]
public enum SortDirection
{
    [EnumMember]
    Ascending,

    [EnumMember]
    Descending
}