using System;
using System.Collections;
using System.Collections.Generic;

namespace CSDis
{
    enum DataPrefix : byte
    {
        SIMPLE_STRING = 0x2B, // +
        ERROR = 0x2D,   // -
        INT = 0x3A, // :
        BULK_STRING = 0x24, // $
        ARRAY = 0x2A, // *
    }

    enum Command : byte
    {
        KEY_EXISTS = 0x61,
        TYPE = 0x62,
        GET = 0x63,
        SET = 0x64,
        DELETE_KEY = 0x65,
        DELETE_DB = 0x66,
        FLUSH_DB = 0x67,
        CREATE = 0x68,
        MOVE = 0x69,
        DB_EXISTS = 0x70
    }

    abstract class CSSPData
    {
        public abstract DataPrefix GetDataPrefix();
        public abstract object GetData();
    }
    class SStringData : CSSPData
    {
        private string _data;
        public SStringData(string data)
        {
            _data = data;
        }
        public override string GetData()
        {
            return _data;
        }
        public override DataPrefix GetDataPrefix()
        {
            return DataPrefix.SIMPLE_STRING;
        }
    }

    class ErrorData : CSSPData
    {
        private string _data;
        public ErrorData(string data)
        {
            _data = data;
        }
        public override string GetData()
        {
            return _data;
        }
        public override DataPrefix GetDataPrefix()
        {
            return DataPrefix.ERROR;
        }
    }

    class BStringData : CSSPData
    {
        private string _data;
        public BStringData(string data)
        {
            _data = data;
        }
        public override string GetData()
        {
            return _data;
        }
        public override DataPrefix GetDataPrefix()
        {
            return DataPrefix.BULK_STRING;
        }
    }

    class IntData : CSSPData
    {
        private int _data;
        public IntData(int data)
        {
            _data = data;
        }
        public override object GetData()
        {
            return _data;
        }
        public override DataPrefix GetDataPrefix()
        {
            return DataPrefix.INT;
        }
    }

    class ArrayData : CSSPData
    {
        private CSSPData[] _data;
        public ArrayData(CSSPData[] data)
        {
            _data = data;
        }
        public override CSSPData[] GetData()
        {
            return _data;
        }

        public override DataPrefix GetDataPrefix()
        {
            return DataPrefix.ARRAY;
        }
    }
    class CSSPMessage
    {
        private Command _cmd;
        private SStringData _key;
        private CSSPData _val;
        public CSSPMessage(Span<byte> buffer)
        {

        }
    } 

    class ProtocolHandler
    {
        public CSSPMessage ParseBuffer(Span<byte> buffer)
        {
            
        }

        public bool ExecuteCSSPMessage(CSSPMessage message)
        {

        }
    }
}
