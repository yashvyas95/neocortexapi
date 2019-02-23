////////////////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2015 Frankfurt University of Applied Sciences / daenet GmbH
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;

namespace NeoCortexApi.Encoders
{
    /// <summary>
    /// Predefined types
    /// </summary>
    public class FieldMetaType
    {
        public const string STRING = "string";

        public const string DATETIME = "datetime";

        public const string INTEGER = "int";

        public const string FLOAT = "float";

        public const string BOOLEAN = "bool";

        public const string LIST = "list";

        public const string COORD = "coord";

        public const string GEO = "geo";

        /* Sparse Array (i.e. 0, 2, 3) */
        public const string SARR = "sarr";

        /* Dense Array (i.e. 1, 1, 0, 1) */
        public const string DARR = "darr";

        /**
         * String representation to be used when a display
         * String is required.
         */
        private string m_FieldTypeString;

        /** Private constructor */
        private FieldMetaType(String s)
        {
            this.m_FieldTypeString = s;
        }

        /**
         * Returns the {@link Encoder} matching this field type.
         * @return
         */
        public EncoderBase NewEncoder()
        {
            throw new NotImplementedException();
            //switch (this.m_FieldTypeString)
            //{
            //    case LIST:
            //    case STRING: return SDRCategoryEncoder.builder().build();
            //    case DATETIME: return DateEncoder.builder().build();
            //    case BOOLEAN: return ScalarEncoder.builder().build();
            //    case COORD: return CoordinateEncoder.builder().build();
            //    case GEO: return GeospatialCoordinateEncoder.geobuilder().build();
            //    case INTEGER:
            //    case FLOAT: return RandomDistributedScalarEncoder.builder().build();
            //    case DARR:
            //    case SARR: return SDRPassThroughEncoder.sptBuilder().build();
            //    default: return null;
            //}
        }

        /**
         * Returns the input type for the {@code FieldMetaType} that this is...
         * @param input
         * @param enc
         * @return
         */

        //public  T decodeType(String input, Encoder<?> enc)
        //{
        //    switch (this.m_FieldTypeString)
        //    {
        //        case LIST:
        //        case STRING: return (T)input;
        //        case DATETIME: return (T)((DateEncoder)enc).parse(input);
        //        case BOOLEAN: return (T)(Boolean.valueOf(input) == true ? new Double(1) : new Double(0));
        //        case COORD:
        //        case GEO:
        //            {
        //                String[] parts = input.split("[\\s]*\\;[\\s]*");
        //                return (T)new Tuple(Double.parseDouble(parts[0]), Double.parseDouble(parts[1]), Double.parseDouble(parts[2]));
        //            }
        //        case INTEGER:
        //        case FLOAT: return (T)new Double(input);
        //        case SARR:
        //        case DARR:
        //            {
        //                return (T)Arrays.stream(input.replace("[", "").replace("]", "")
        //                    .split("[\\s]*\\,[\\s]*")).mapToInt(Integer::parseInt).toArray();
        //            }
        //        default: return null;
        //    }
        //}

        /**
         * Returns the display string
         * @return the display string
         */
        public string Display()
        {
            return m_FieldTypeString;
        }

        /**
         * Parses the specified String and returns a {@link FieldMetaType}
         * representing the passed in value.
         * 
         * @param s  the type in string form
         * @return the FieldMetaType indicated or the default: {@link FieldMetaType#FLOAT}.
         */
        public static FieldMetaType FromString(string s)
        {
            if (String.IsNullOrEmpty(s))
                throw new ArgumentException();

            string val = s.ToLower();
            switch (val)
            {
                case "char":
                case "string":
                case "category":
                    {
                        return new FieldMetaType(STRING);
                    }
                case "date":
                case "date time":
                case "datetime":
                case "time":
                    {
                        return new FieldMetaType(DATETIME);
                    }
                case "int":
                case "integer":
                case "long":
                    {
                        return new FieldMetaType(INTEGER);
                    }
                case "double":
                case "float":
                case "number":
                case "numeral":
                case "num":
                case "scalar":
                case "floating point":
                    {
                        return new FieldMetaType(FLOAT);
                    }
                case "bool":
                case "boolean":
                    {
                        return new FieldMetaType(BOOLEAN);
                    }
                case "list":
                    {
                        return new FieldMetaType(LIST);
                    }
                case "geo":
                    {
                        return new FieldMetaType(GEO);
                    }
                case "coord":
                    {
                        return new FieldMetaType(COORD);
                    }
                case "sarr":
                    {
                        return new FieldMetaType(SARR);
                    }
                case "darr":
                    {
                        return new FieldMetaType(DARR);
                    }

                default: return new FieldMetaType(FLOAT);
            }
        }
    }

}
