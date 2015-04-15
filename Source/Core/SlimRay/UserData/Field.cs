﻿
namespace SlimRay.UserData
{
    public class Field : IField
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public FieldType Type { get; set; }
        public IData Data { get; set; }
    }
}
