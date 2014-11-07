﻿
namespace SlimRay.Data
{
    public interface ISimpleField
    {
        /// <summary>
        /// The data that this filed belongs to.
        /// </summary>
        ISimpleData Data { get; set; }

        DataType Type { get; set; }

        string Name { get; set; }
        string Description { get; set; }

        void Link(ISimpleData data, FieldLinkRelation relation);
    }
}
