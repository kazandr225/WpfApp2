using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfApp2
{
    public partial class Product
    {

        public string ProdAmount
        {
            get
            {
                return "Количество товара: " + Amount_Product;
            }
        }

        public string Name
        {
            get
            {
                return Name_Product + "/" + Kind.Category;
            }
        }

        public SolidColorBrush KindColor
        {
            get
            {
                switch (id_Kind)
                {
                    case 1:
                        return Brushes.Ivory;
                        case 2:
                            return Brushes.LightCoral;
                        case 3:
                            return Brushes.LightGreen;
                        case 4:
                            return Brushes.Aqua;
                    default:
                        return Brushes.White;
                }
            }
        }
    }
}
