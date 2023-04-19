using UnityEngine;
using Code.Data.Static;

namespace Code.Service
{
    public class FieldCheckService
    {
        public bool FieldCheck(CellType[,] statusField)
        {
            int value1 = 0;
            int value2 = 0;
            int value3 = 0;
            int value4 = 0;
            for (int i = 0; i < ConstData.FIELD_SIZE; i++)
            {
                CellCheck(ref value3, statusField, i, i);
                CellCheck(ref value4, statusField, i, ConstData.FIELD_SIZE - i - 1);
                value1 = 0;
                value2 = 0;
                for (int j = 0; j < ConstData.FIELD_SIZE; j++)
                {
                    CellCheck(ref value1, statusField, i, j);
                    CellCheck(ref value2, statusField, j, i);
                }
                if (Mathf.Abs(value1) >= ConstData.VICTORY_POINTS ||
                    Mathf.Abs(value2) >= ConstData.VICTORY_POINTS)
                    return true;
            }
            if (Mathf.Abs(value3) >= ConstData.VICTORY_POINTS ||
                Mathf.Abs(value4) >= ConstData.VICTORY_POINTS)
                return true;
            return false;
        }


        private void CellCheck(ref int value, CellType[,] statusField, int i, int j)
        {
            switch (statusField[i, j])
            {
                case CellType.Cross:
                    {
                        value--;
                        break;
                    }
                case CellType.Zero:
                    {
                        value++;
                        break;
                    }
            }
        }
    }
}