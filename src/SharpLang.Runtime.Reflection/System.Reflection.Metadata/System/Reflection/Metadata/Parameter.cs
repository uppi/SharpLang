// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Diagnostics;

namespace System.Reflection.Metadata
{
    struct Parameter
    {
        private readonly MetadataReader reader;

        // Workaround: JIT doesn't generate good code for nested structures, so use RowId.
        private readonly uint rowId;

        internal Parameter(MetadataReader reader, ParameterHandle handle)
        {
            DebugCorlib.Assert(reader != null);
            DebugCorlib.Assert(!handle.IsNil);

            this.reader = reader;
            this.rowId = handle.RowId;
        }

        private ParameterHandle Handle
        {
            get { return ParameterHandle.FromRowId(rowId); }
        }

        public ParameterAttributes Attributes
        {
            get
            {
                return reader.ParamTable.GetFlags(Handle);
            }
        }

        public int SequenceNumber
        {
            get
            {
                return reader.ParamTable.GetSequence(Handle);
            }
        }

        public StringHandle Name
        {
            get
            {
                return reader.ParamTable.GetName(Handle);
            }
        }

        public ConstantHandle GetDefaultValue()
        {
            return reader.ConstantTable.FindConstant(Handle);
        }

        public BlobHandle GetMarshallingDescriptor()
        {
            uint marshalRowId = reader.FieldMarshalTable.FindFieldMarshalRowId(Handle);
            if (marshalRowId == 0)
            {
                return default(BlobHandle);
            }

            return reader.FieldMarshalTable.GetNativeType(marshalRowId);
        }

        public CustomAttributeHandleCollection GetCustomAttributes()
        {
            return new CustomAttributeHandleCollection(reader, Handle);
        }
    }
}