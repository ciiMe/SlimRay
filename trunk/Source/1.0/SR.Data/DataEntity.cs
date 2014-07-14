using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SR.Data
{
    public interface IDataEntity : IData
    {
        byte ValueByte(IField field);
        int ValueInt32(IField field);
        long ValueInt64(IField field);

        char ValueChar(IField field);
        string ValueString(IField field);

        bool ValueBool(IField field);
    }
}
