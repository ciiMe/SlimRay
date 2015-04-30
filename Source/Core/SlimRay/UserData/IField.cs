﻿
namespace SlimRay.UserData
{
    public interface IField
    {
        /// <summary>
        /// The data that this filed belongs to.
        /// </summary>
        IData Data { get; set; }

        int ID { get; set; }
        string Name { get; set; }
        string Description { get; set; }

        FieldType Type { get; set; }
    }
}