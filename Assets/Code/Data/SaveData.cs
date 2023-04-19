using System;
using Code.Data.Static;

[Serializable]
class SaveData
{
    public CellType[,] statusField = new CellType[ConstData.FIELD_SIZE,
                                                  ConstData.FIELD_SIZE];
}