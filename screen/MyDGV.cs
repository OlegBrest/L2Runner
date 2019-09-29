
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L2Runner
{
    /// <summary>
    ///  Унаследованый от DataGridView класс, 
    ///  в котором просто получаем доступ к protected свойству 
    /// </summary>
    [Description("Data Grid View с установленым свойством DoubleBuffered = true")]
    public class MyDGrV : DataGridView
    {
        public MyDGrV()
        {
            // и устанавливаем значение true при создании экземпляра класса
            this.DoubleBuffered = true;
            // или с помощью метода SetStyle
            this.SetStyle(ControlStyles.DoubleBuffer |
                ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }
    }
}
